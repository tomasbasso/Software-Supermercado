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
          
        }
        DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2();
        public void RefrescarGrilla()
        {
            var lista = ddbb.ARTICULOS.ToList();//CREAMOS LISTA CON ARTICULOS
            dataGridView1.DataSource = lista; //MOSTRAMOS EN LA DATAGIRD
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
            dataGridView1.ReadOnly = false; //DESBLOQUEAMOS TABLA
        }


        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            // Muestra un MessageBox de confirmación
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas borrar este artículo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0]; //CLIQUEAMOS LA CELDA A BORRAR
                    int ArticuloId = Convert.ToInt32(selectedRow.Cells["ArticuloID"].Value);//LE ASIGNO A ARTICULO ID EL ARITUCULO SELECCIONADO
                    EliminarArticulo(ArticuloId);
                    RefrescarGrilla();
                    MessageBox.Show("El artículo ha sido borrado con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Seleccione un articulo para eliminar.");
                }
               
            }
           

          
          


        }
        private void EliminarArticulo(int ArticuloId)
        {
                var articulo = ddbb.ARTICULOS.FirstOrDefault(u => u.ArticuloID == ArticuloId); //Compara con articulo id
                if (articulo != null)
                {
                    ddbb.ARTICULOS.Remove(articulo);
                    ddbb.SaveChanges();
                   

                }
                else { MessageBox.Show("Error al eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error); ; }
            
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
                else { MessageBox.Show("Error al buscar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error); ; } 

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

               
                txt_detalle.Clear();
                txt_presentacion.Clear();
                txt_precioc.Clear();
                txt_preciov.Clear();
                txt_cantidad.Clear();
            }
            catch { MessageBox.Show("Error al ingresar nuevo articulo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error); ; }
        }

        //////////////////////////////////////////////VALIDACION//////////////////////////////////////////////////////////////////////
        ///
        private void txt_precioc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número, la tecla de retroceso (Backspace) o un signo negativo "-"
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',')
            {
                e.Handled = true; // Detiene la entrada de caracteres no válidos
            }
            // Verifica si el cuadro de texto ya contiene un signo negativo "-" en la posición inicial
            else if ((e.KeyChar == '-' && txt_precioc.Text.Contains("-")) || (e.KeyChar == '-' && txt_precioc.SelectionStart != 0))
            {
                e.Handled = true; // No permite ingresar un segundo signo negativo
            }
        }

        private void txt_precioc_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txt_precioc.Text, out decimal precio))
            {
                if (precio > 0)
                { }
                else
                {
                    MessageBox.Show("El número es negativo o no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_precioc.Clear(); // Limpia el TextBox en caso de un número negativo
                }
            }
        }

        private void txt_preciov_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txt_preciov.Text, out decimal precio))
            {
                if (precio > 0)
                { }
                else
                {
                    MessageBox.Show("El número es negativo o no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_preciov.Clear(); // Limpia el TextBox en caso de un número negativo
                }
            }
        }

        private void txt_preciov_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número, la tecla de retroceso (Backspace) o un signo negativo "-"
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',')
            {
                e.Handled = true; // Detiene la entrada de caracteres no válidos
            }
            // Verifica si el cuadro de texto ya contiene un signo negativo "-" en la posición inicial
            else if ((e.KeyChar == '-' && txt_preciov.Text.Contains("-")) || (e.KeyChar == '-' && txt_preciov.SelectionStart != 0))
            {
                e.Handled = true; // No permite ingresar un segundo signo negativo
            }
        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txt_cantidad.Text, out decimal precio))
            {
                if (precio > 0)
                { }
                else
                {
                    MessageBox.Show("El número es negativo o no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cantidad.Clear(); // Limpia el TextBox en caso de un número negativo
                }
            }
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número, la tecla de retroceso (Backspace) o un signo negativo "-"
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',')
            {
                e.Handled = true; // Detiene la entrada de caracteres no válidos
            }
            // Verifica si el cuadro de texto ya contiene un signo negativo "-" en la posición inicial
            else if ((e.KeyChar == '-' && txt_cantidad.Text.Contains("-")) || (e.KeyChar == '-' && txt_cantidad.SelectionStart != 0))
            {
                e.Handled = true; // No permite ingresar un segundo signo negativo
            }
        }
    }
    }
    

