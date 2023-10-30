using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp2_TomasBasso.Models;

namespace Tp2_TomasBasso.Ventas
{
    public partial class Frm_Adm_clientes : Form
    {
        public Frm_Adm_clientes()
        {
            InitializeComponent();
            RefrescarGrilla();
        }
        DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2();
        public void RefrescarGrilla()
        {
            var lista = ddbb.CLIENTES.ToList();
            dataGridView1.DataSource = lista;
        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            //try
            {
                CLIENTES cliente = new CLIENTES();

                cliente.NombreCompleto = txt_nombre.Text;
                cliente.Dni = int.Parse(txt_dni.Text);
                cliente.Direccion = txt_direccion.Text;
                cliente.RazonSocial = txt_razonsocial.Text;
                cliente.CUIT = txt_cuit.Text;

                ddbb.CLIENTES.Add(cliente);
                ddbb.SaveChanges();
                RefrescarGrilla();

                MessageBox.Show("El cliente " + txt_nombre.Text + " ha sido agregado con exito!");

                txt_nombre.Text = "";
                txt_direccion.Text = "";
                txt_dni.Text = "";
                txt_razonsocial.Text = "";
                txt_cuit.Text = "";
            }
            //catch
            //{ MessageBox.Show("Error al ingresar nuevo cliente"); }

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            using (var context = new DDBB_SupermercadoEntities2())
            {
                var resultados = context.CLIENTES.Where(item => item.NombreCompleto.Contains(txt_nombre.Text)).ToList();
                if (resultados != null)
                {
                    dataGridView1.DataSource = resultados;
                }
                else { MessageBox.Show("Error al buscar"); }
            }
        }

        private void btn_habilitar_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            using (DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2())
            {
                var Clientes = ddbb.CLIENTES.FirstOrDefault(u => u.NombreCompleto == txt_nombre.Text); //Compara con Clientes id
                if (Clientes != null)
                {
                    ddbb.CLIENTES.Remove(Clientes);
                    ddbb.SaveChanges();
                    MessageBox.Show("Proveedor eliminado con exito!");

                }
                else { MessageBox.Show("Error al eliminar el Proveedor"); }
            }
        }
    }
}
