using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp2_TomasBasso.Models;

namespace Tp2_TomasBasso.Articulos
{
    public partial class Frm_Articulos : Form
    {
        public Frm_Articulos()
        {
            InitializeComponent();
        }

        private void Frm_Articulos_Load(object sender, EventArgs e)
        {
            RefrescarGrilla();
            this.WindowState = FormWindowState.Maximized;
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle buttonRectangle = Btn_guardar.ClientRectangle;
            buttonRectangle.Inflate(0,0);
            buttonPath.AddEllipse(buttonRectangle);
            Btn_guardar.Region = new Region(buttonPath);

        }
        DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2();
        public void RefrescarGrilla()
        {
            var lista = ddbb.ARTICULOS.ToList();
            dataGridView1.DataSource = lista;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            
            ddbb.SaveChanges();
            RefrescarGrilla();
            dataGridView1.ReadOnly = true;
        }

        private void btn_habilitar_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            Frm_MENU frm_MENU = new Frm_MENU();
            this.Hide();
            frm_MENU.Show();
        }


        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int ArticuloId = Convert.ToInt32(selectedRow.Cells["ArticuloID"].Value);//LE ASIGNO A USUARIO ID EL EMPLEADO SELECCIONADO
                EliminarArticulo(ArticuloId);
                RefrescarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione un articulo para eliminar.");
            }


        }
        private void EliminarArticulo(int ArticuloId)
        {
                var articulo = ddbb.ARTICULOS.FirstOrDefault(u => u.ArticuloID == ArticuloId); //Compara con articulo id
                if (articulo != null)
                {
                    ddbb.ARTICULOS.Remove(articulo);
                    ddbb.SaveChanges();
                    MessageBox.Show("Articulo eliminado con exito!");

                }
                else { MessageBox.Show("Error al eliminar el articulo"); }
            
        }

        private void btn_buscar_Click_1(object sender, EventArgs e)
        {
            using (var context = new DDBB_SupermercadoEntities2())
            {

                var resultados = context.ARTICULOS.Where(item => item.Detalle.Contains(txt_detalle.Text)).ToList();
                if (resultados != null)
                {
                    dataGridView1.DataSource = resultados;
                }
                else { MessageBox.Show("Error al buscar"); }

            }
        }

        private void btn_agregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                ARTICULO articulo = new ARTICULO();

                articulo.Detalle = txt_detalle.Text;
                articulo.Presentacion = txt_presentacion.Text;
                articulo.PrecioCompra = int.Parse(txt_precioc.Text);
                articulo.PrecioVenta = int.Parse(txt_preciov.Text);
                articulo.Cantidad= int.Parse(txt_cantidad.Text);
                ;

                ddbb.ARTICULOS.Add(articulo);
                ddbb.SaveChanges();
                RefrescarGrilla();

                MessageBox.Show("El articulo " + txt_presentacion.Text + " ha sido agregado con exito!");

               
                txt_detalle.Text = "";
                txt_presentacion.Text = "";
                txt_precioc.Text = "";
                txt_preciov.Text = "";
                txt_cantidad.Text = "";
            }
            catch { MessageBox.Show("Error al ingresar nuevo articulo"); }
        }
    }
}
