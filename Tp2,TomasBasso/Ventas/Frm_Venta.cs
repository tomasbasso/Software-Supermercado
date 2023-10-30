
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp2_TomasBasso.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using QuestPDF.Fluent;
//using QuestPDF.Helpers;
//using QuestPDF.Infrastructure;
//using QuestPDF.Previewer;
using System.IO;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Drawing.Printing;

namespace Tp2_TomasBasso.Venta
{
    public partial class Frm_venta : Form
    {
      

        public Frm_venta()
        {
            InitializeComponent();
        }
        DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2();
        private void Frm_venta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dDBB_SupermercadoDataSet.ARTICULO' Puede moverla o quitarla según sea necesario.
            this.WindowState = FormWindowState.Maximized;


        }

        private void textBoxid_Enter(object sender, EventArgs e)
        {

        }
        int cantidad = 1;
        int total = 0;

        private void AgregarArticulo()
        {
            int articuloId;
            if (int.TryParse(textBoxid.Text, out articuloId))
            {
                using (var dbContext = new DDBB_SupermercadoEntities2()) // Reemplaza "TuDbContext" con el nombre de tu contexto de Entity Framework
                {
                    ARTICULO ART = new ARTICULO();
                    var articulo = dbContext.ARTICULOS.FirstOrDefault(a => a.ArticuloID == articuloId);
                    //dataGridView1.Columns.Add("Detalle","Presentacion","Precio","Cantidad");

                    if (articulo != null)
                    {
                        cantidad = 1;
                        dataGridView.Rows.Add(articulo.Detalle, articulo.Presentacion, articulo.PrecioVenta, cantidad, "+");
                        total += articulo.PrecioVenta * cantidad;

                    }
                    else
                    {
                        MessageBox.Show("Artículo no encontrado");
                    }

                }
                CalcularTotal();
            }
            else
            {
                MessageBox.Show("ID de artículo inválido");
            }
        }






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CalcularTotal()
        {
            decimal total = 0;

            // Itera a través de las filas del DataGridView y suma los precios multiplicados por la cantidad.
            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                if (fila.Cells["Precio"].Value != null &&
                    fila.Cells["Cantidad"].Value != null)
                {
                    if (decimal.TryParse(fila.Cells["Precio"].Value.ToString(), out decimal precio) &&
                        int.TryParse(fila.Cells["Cantidad"].Value.ToString(), out int cantidad))
                    {
                        total += precio * cantidad;
                    }
                }
            }

            // Actualiza el texto del Label con el total calculado.
            label3.Text = total.ToString("0.00");
        }


        private void btn_buscar_Click(object sender, EventArgs e)
        {
            //BuscarArticulo buscar = new BuscarArticulo();
            //buscar.Show();

        }

       

        

                  

        private void btn_buscarclie_Click(object sender, EventArgs e)
        {
            using (var context = new DDBB_SupermercadoEntities2())
            {
                try
                {
                    int dni = int.Parse(text_dni.Text);
                    var resultados = context.CLIENTES.Where(item => item.Dni == dni).ToList();
                    if (resultados != null)
                    {
                        label5.Text = "Cliente: " + resultados[0].NombreCompleto;
                    }
                }
                catch
                { MessageBox.Show("Error al buscar"); }

            }
        }

   

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                btn_buscarclie.Enabled = true;
                text_dni.Enabled = true;
                dataGridView.Enabled = true;
                btn_buscar.Enabled = true;
                btn_Agregar.Enabled = true;
                textBoxid.Enabled = true;
                textBoxNombre.Enabled = true;
                btn_finalizar.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView.Enabled = true;
                btn_buscar.Enabled = true;
                btn_Agregar.Enabled = true;
                textBoxid.Enabled = true;
                textBoxNombre.Enabled = true;
                btn_finalizar.Enabled = true;
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            AgregarArticulo();
        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton2.Checked)
                {
                    using (var context = new DDBB_SupermercadoEntities2())
                    {
                        int dni = int.Parse(text_dni.Text);
                        var resultados = context.CLIENTES.Where(item => item.Dni == dni).ToList();
                        VENTAS ventas = new VENTAS();
                        string codigoc = Convert.ToString(resultados[0].IDcliente);
                        ventas.IDcliente = codigoc;
                        ventas.Monto = decimal.Parse(label3.Text);
                        ventas.Fecha = DateTime.Now;
                        ARTICULO ARTI = new ARTICULO();
                       
                        ddbb.VENTAS.Add(ventas);
                        ddbb.SaveChanges();
                        MessageBox.Show("Compra Finalizada");

                    }

                }



            }
            catch { MessageBox.Show("Error"); }

            if (radioButton1.Checked)
            {
                using (var context = new DDBB_SupermercadoEntities2())
                {

                    VENTAS ventass = new VENTAS();
                    ventass.IDcliente = "";
                    ventass.Monto = decimal.Parse(label3.Text);
                    ventass.Fecha = DateTime.Now;
                    ddbb.VENTAS.Add(ventass);
                    ddbb.SaveChanges(); //VER ERROR
                    MessageBox.Show("Compra Finalizada");

                }

            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
                }

            }
            else
            {
                MessageBox.Show("Seleccione un articulo para eliminar.");
            }
        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView.Rows[e.RowIndex];

            DataGridViewCell cantidadCell = fila.Cells["Cantidad"];

            // Verifica si el valor de cantidad es un número válido.
            if (cantidadCell.Value != null && int.TryParse(cantidadCell.Value.ToString(), out int cantidad))
            {
                // Aumenta la cantidad en 1.
                cantidad++;
                cantidadCell.Value = cantidad;
                CalcularTotal();
            }
        }
    }
}
