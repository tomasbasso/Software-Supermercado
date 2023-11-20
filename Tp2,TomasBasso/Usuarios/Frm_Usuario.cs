using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp2_TomasBasso.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Tp2_TomasBasso
{
    public partial class Frm_Usuario : Form
    {
        DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2();
        public Frm_Usuario()
        {
            InitializeComponent();

        }

        public void RefrescarGrilla()
        {           
            var lista = ddbb.USUARIOS.ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Contraseña"].Visible = false;
            dataGridView1.Columns["UsuarioID"].Visible = false;
        }
        private void Frm_Usuario_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            RefrescarGrilla();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
        }

/////////////////////////////////////////////AGREGAR////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            using (DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2())
            {

                var dni = ddbb.USUARIOS.FirstOrDefault(u => u.NombreUsuario == txt_nombre.Text);
                if (dni != null)
                {
                    MessageBox.Show("Ya existe un usuario con ese nombre");
                }
                else
                {

                    try
                    {
                        USUARIOS user = new USUARIOS();
                        user.NombreUsuario = txt_nombre.Text;
                        user.Celular = txt_celular.Text;
                        user.Email = txt_email.Text;
                        user.Acceso = cmb_acceso.Text;
                        user.Contraseña = txt_contraseña.Text;

                        ddbb.USUARIOS.Add(user);
                        ddbb.SaveChanges();
                        RefrescarGrilla();

                        MessageBox.Show("El usuario " + txt_nombre.Text + " ha sido agregado con exito!");

                        txt_nombre.Text = "";
                        txt_contraseña.Text = "";
                    
                        txt_celular.Text = "";
                        txt_email.Text = "";
                    }
                    catch { MessageBox.Show("Error al ingresar nuevo usuario"); }
                }
            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////BUSCAR////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            using (DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2())

            using (var context = new DDBB_SupermercadoEntities2())
            {

                var resultados = context.USUARIOS.Where(item => item.NombreUsuario.Contains(txt_nombre.Text)).ToList();
                if (resultados != null)
                {
                    dataGridView1.DataSource = resultados;
                }
                else { MessageBox.Show("Error al buscar"); }

            }
        }
 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

 ////////////////////////////////////////////EDITAR//////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            // Muestra un MessageBox de confirmación
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                ddbb.SaveChanges();
                RefrescarGrilla();
                dataGridView1.ReadOnly = true;
            }
        }

        private void btn_habilitar_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
        }

/////////////////////////////////////////ELIMINAR/////////////////////////////////////////////////////////////////////////////////////
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            // Muestra un MessageBox de confirmación
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas borrar este artículo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                using (DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2())
                {

                    if (dataGridView1.SelectedRows.Count > 0)
                    {

                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                        int usuarioId = Convert.ToInt32(selectedRow.Cells["UsuarioID"].Value);//LE ASIGNO A USUARIO ID EL EMPLEADO SELECCIONADO
                        EliminarUsuario(usuarioId);
                        RefrescarGrilla();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un usuario para eliminar.");
                    }
                }
            }
            }
        private void EliminarUsuario(int usuarioId)
        {
            using (DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2()) 
            {
                var usuario = ddbb.USUARIOS.FirstOrDefault(u => u.UsuarioID == usuarioId); //Compara con usuario id
                if (usuario != null)
                {
                    ddbb.USUARIOS.Remove(usuario);
                    ddbb.SaveChanges();
                    MessageBox.Show("Usuario eliminado con exito!");

                } else { MessageBox.Show("Error al eliminar el usuario"); }
            }
        }

        private void dataGridView1_DefaultCellStyleChanged(object sender, EventArgs e)
        {

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
    
    

