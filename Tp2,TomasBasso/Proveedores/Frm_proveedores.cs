using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp2_TomasBasso.Models;

namespace Tp2_TomasBasso.Proveedores
{
    public partial class Frm_proveedores : Form
    {
        DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2();
        public Frm_proveedores()
        {
            InitializeComponent();
            
        }
        public void RefrescarGrilla()
        {
            var lista = ddbb.PROVEEDORES.ToList();
            dataGridView1.DataSource = lista;
        }



        private void btn_volver_Click(object sender, EventArgs e)
        {
            Frm_MenuAdmin frm_MENU = new Frm_MenuAdmin();
            this.Hide();
            frm_MENU.Show();
        }


        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            // Muestra un MessageBox de confirmación
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                ddbb.SaveChanges();
                RefrescarGrilla();
                dataGridView1.ReadOnly = true; //BLOQUEAMOS TABLA
                MessageBox.Show("Los cambios han sido guardados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_habilitar_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
        }
        private void EliminarUsuario(int Proveedorid)
        {
            using (DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2())
            {
                var Articulo = ddbb.PROVEEDORES.FirstOrDefault(u => u.ProveedorID == Proveedorid); //Compara con Articulo id
                if (Articulo != null)
                {
                    ddbb.PROVEEDORES.Remove(Articulo);
                    ddbb.SaveChanges();
                    MessageBox.Show("Proveedor eliminado con exito!");

                }
                else { MessageBox.Show("Error al eliminar el Proveedor"); }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            // Muestra un MessageBox de confirmación
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas borrar este artículo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int Provedorid = Convert.ToInt32(selectedRow.Cells["ProveedorID"].Value);//LE ASIGNO A USUARIO ID EL EMPLEADO SELECCIONADO
                    EliminarUsuario(Provedorid);
                    RefrescarGrilla();
                }
                else
                {
                    MessageBox.Show("Seleccione un proveedor para eliminar.");
                }
            }
        }

        private void btn_agregar_Click_1(object sender, EventArgs e)
        {
            
                PROVEEDOR Prove = new PROVEEDOR();

                
                Prove.Nombre = txt_nombre.Text;
                Prove.CUIT = txt_Cuit.Text;
                Prove.Email = txt_email.Text;
                Prove.Celular = txt_celular.Text;
                Prove.Rubro = txt_rubro.Text;
                Prove.Direccion = txt_direccion.Text;


                ddbb.PROVEEDORES.Add(Prove);
                ddbb.SaveChanges();
                RefrescarGrilla();

                MessageBox.Show("El proveedor " + txt_nombre.Text + " ha sido agregado con exito!");

                txt_nombre.Clear();
                txt_rubro.Clear();
                txt_celular.Clear();
                txt_email.Clear();
                txt_Cuit.Clear();
                txt_direccion.Clear();
            
            
        }

        private void btn_buscar_Click_1(object sender, EventArgs e)
        {
            using (var context = new DDBB_SupermercadoEntities2())
            {

                var resultados = context.PROVEEDORES.Where(item => item.Nombre.Contains(txt_nombre.Text)).ToList();
                if (resultados != null)
                {
                    dataGridView1.DataSource = resultados;
                }
                else { MessageBox.Show("Error al buscar"); }

            }
        }

        private void Frm_proveedores_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            RefrescarGrilla();
        }
    }
    
}
