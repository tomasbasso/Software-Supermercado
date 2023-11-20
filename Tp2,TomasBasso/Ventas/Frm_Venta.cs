
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
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
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
        int ventaID;
        string cuit;
        string razon;
        string direccion;

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
                        ventas.IDcliente = int.Parse(codigoc);
                        ventas.Monto = decimal.Parse(label3.Text);
                        ventas.Fecha = DateTime.Now;
                        ARTICULO ARTI = new ARTICULO();
                       
                        ddbb.VENTAS.Add(ventas);
                        ddbb.SaveChanges();
                        MessageBox.Show("Compra Finalizada");
                        ventaID = ventas.VentaID;
                        razon = resultados[0].RazonSocial;
                        direccion= resultados[0].Direccion;
                        cuit = resultados[0].CUIT;
                    }

                }



            }
            catch { MessageBox.Show("Error"); }
            
            if (radioButton1.Checked)
            {
                using (var context = new DDBB_SupermercadoEntities2())
                {

                    VENTAS ventass = new VENTAS();
                    ventass.Monto = decimal.Parse(label3.Text);
                    ventass.Fecha = DateTime.Now;
                    ddbb.VENTAS.Add(ventass);
                    ddbb.SaveChanges(); //VER ERROR
                    MessageBox.Show("Compra Finalizada");
                    ventaID = ventass.VentaID;
                    
                }

            }

            /////////////////////////PRUEBA PDF ////////////////////////////////////////////////
            ///
            List<ARTICULO> articulos = new List<ARTICULO>();

            var fecha = DateTime.Now.ToString("dd/MM/yyyy");
            

            var document = Document.Create(Container => {
                Container.Page(page =>
                {
                    page.Header().Column(col =>
                        {

                            col.Item().PaddingTop(2).AlignCenter().Text(text =>
                            {
                                text.Span("LOS DOS CHINOS").FontSize(29).Bold();
                            });
                            col.Item().PaddingTop(2).AlignCenter().Text(text =>
                            {
                                text.Span("Rivadavia Nº599").FontSize(11).SemiBold();
                            });
                            col.Item().PaddingTop(2).AlignCenter().Text(text =>
                            {
                                text.Span("Winifreda, La Pampa").FontSize(11).SemiBold();
                            });
                            col.Item().PaddingTop(2).AlignCenter().Text(text =>
                            {
                                text.Span("Responsable Inscirpto").FontSize(11).SemiBold();
                            });
                            col.Item().PaddingTop(2).AlignCenter().Text(text =>
                            {
                                text.Span("CUIT Nº20/765897456/9").FontSize(11).SemiBold();
                            });


                            col.Item().LineHorizontal(0.8f).LineColor("#000000");


                        });
                    page.Content().Padding(2).Column(col =>




                    {
                        if (nombre != "")
                        {
                            col.Item().PaddingTop(2).AlignLeft().Text(text =>
                            {
                                text.Span(nombre).FontSize(11).Bold();
                            });
                            col.Item().PaddingTop(2).AlignLeft().Text(text =>
                            {
                                text.Span(direccion).FontSize(11).Bold();
                            });
                            col.Item().PaddingTop(2).AlignLeft().Text(text =>
                            {
                                text.Span(razon).FontSize(11).Bold();
                            });
                            col.Item().PaddingTop(2).AlignLeft().Text(text =>
                            {
                                text.Span("Cuit nº" + cuit).FontSize(11).Bold();
                            });

                            
                        
                            col.Item().AlignRight().Text(text =>
                            {
                                text.Span("Fecha:").FontSize(9).SemiBold();
                                text.Span(fecha).FontSize(9).SemiBold();
                            });
                            
                            col.Item().Border(0.5f).PaddingTop(10).Table(tabla =>
                            {
                                tabla.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });
                                tabla.Header(header =>
                                {
                                    header.Cell().Padding(2).Border(0.5f).AlignCenter().Text("Detalle").FontSize(12).Bold();
                                    header.Cell().Padding(2).Border(0.5f).AlignCenter().Text("Presentacion").FontSize(12).Bold();
                                    header.Cell().Padding(2).Border(0.5f).AlignCenter().Text("Precio").FontSize(12).Bold();
                                    header.Cell().Padding(2).Border(0.5f).AlignCenter().Text("Cantidad").FontSize(12).Bold();
                                });


                                foreach (DataGridViewRow row in dataGridView.Rows)
                                {
                                    if (row.Cells["Detalle"].Value != null &&
                                        row.Cells["Presentacion"].Value != null &&
                                        row.Cells["Precio"].Value != null &&
                                        row.Cells["Cantidad"].Value != null)
                                    {
                                        tabla.Cell().BorderBottom(0.8f).AlignCenter().BorderColor("#000000").Padding(2).Text(row.Cells["Detalle"].Value.ToString());
                                        tabla.Cell().BorderBottom(0.8f).AlignCenter().BorderColor("#000000").Padding(2).Text(row.Cells["Presentacion"].Value.ToString());
                                        tabla.Cell().BorderBottom(0.8f).AlignCenter().BorderColor("#000000").Padding(2).Text(row.Cells["Precio"].Value.ToString());
                                        tabla.Cell().BorderBottom(0.8f).AlignCenter().BorderColor("#000000").Padding(2).Text(row.Cells["Cantidad"].Value.ToString());

                                        decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                                    }
                                }




                                col.Item().PaddingTop(2).AlignRight().Text(text =>
                                {
                                    text.Span("TOTAL: ").FontSize(14).Bold();
                                    text.Span("$" + total.ToString()).FontSize(11);
                                });
                            });
                        }
                    }
                    );
                });
            
            } );//IMPORTANTE PONER LAS LIBRERIAS
            try
            {
                // Construir el nuevo Path_ticket con el número de venta
                if (nombre == "") { 
                string nuevoPathTicket = $@"C:\Users\Usuario\Desktop\ITES\2DO AÑO\Copia TP2pROG\pdf\5\Tp2,TomasBasso\data\Factura_Nº{ventaID}.pdf";
                    document.GeneratePdf(nuevoPathTicket);
                    document.GeneratePdf(nuevoPathTicket);
                    MessageBox.Show("El ticket fue generado correctamente");
                } else {
                    string nuevoPathTicket = $@"C:\Users\Usuario\Desktop\ITES\2DO AÑO\Copia TP2pROG\pdf\5\Tp2,TomasBasso\data\Factura_Nº{ventaID},Cliente {nombre}.pdf";
                    document.GeneratePdf(nuevoPathTicket);
                    document.GeneratePdf(nuevoPathTicket);
                    MessageBox.Show("El ticket fue generado correctamente");
                }
                
                
            } 
            catch 
            { MessageBox.Show("Error al generar ticket"); }
            

        }



        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView.SelectedRows[0];

                // Obtener el precio y la cantidad del artículo a eliminar
                if (fila.Cells["Precio"].Value != null && fila.Cells["Cantidad"].Value != null)
                {
                    decimal precio = Convert.ToDecimal(fila.Cells["Precio"].Value);
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);

                    // Restar el precio del artículo eliminado al total
                    total -= (int)(precio * cantidad);

                    // Eliminar la fila seleccionada
                    dataGridView.Rows.RemoveAt(fila.Index);

                    // Actualizar el total en el label
                    label3.Text = total.ToString("0.00");
                    CalcularTotal();
                }
                else
                {
                    MessageBox.Show("Error al obtener el precio o la cantidad del artículo.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un artículo para eliminar.");
            }
        }



        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView.Rows[e.RowIndex];

            DataGridViewCell cantidadCell = fila.Cells["Cantidad"];
            int articuloId;
            if (int.TryParse(textBoxid.Text, out articuloId))
            {

                using (var dbContext = new DDBB_SupermercadoEntities2()) // Reemplaza "TuDbContext" con el nombre de tu contexto de Entity Framework
                {

                    ARTICULO ART = new ARTICULO();
                    var articulo = dbContext.ARTICULOS.FirstOrDefault(a => a.ArticuloID == articuloId);

                    // Verifica si el valor de cantidad es un número válido.
                    if (cantidadCell.Value != null && int.TryParse(cantidadCell.Value.ToString(), out int cantidad))
                    {
                        if (articulo.Cantidad > cantidad)
                        {
                            // Aumenta la cantidad en 1.
                            cantidad++;
                            cantidadCell.Value = cantidad;
                            CalcularTotal();
                        }
                        else { MessageBox.Show("Cantidad Insuficiente"); }

                    }
                }
            }
        }
        string nombre="";
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
                        nombre = resultados[0].NombreCompleto; ;
                    }
                }
                catch
                { MessageBox.Show("Error al buscar"); }
                
            }
        }

        private void text_dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número, la tecla de retroceso (Backspace) o un signo negativo "-"
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',')
            {
                e.Handled = true; // Detiene la entrada de caracteres no válidos
            }
            // Verifica si el cuadro de texto ya contiene un signo negativo "-" en la posición inicial
            else if ((e.KeyChar == '-' && text_dni.Text.Contains("-")) || (e.KeyChar == '-' && text_dni.SelectionStart != 0))
            {
                e.Handled = true; // No permite ingresar un segundo signo negativo
            }
        }

        private void textBoxid_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número, la tecla de retroceso (Backspace) o un signo negativo "-"
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != ',')
            {
                e.Handled = true; // Detiene la entrada de caracteres no válidos
            }
            // Verifica si el cuadro de texto ya contiene un signo negativo "-" en la posición inicial
            else if ((e.KeyChar == '-' && textBoxid.Text.Contains("-")) || (e.KeyChar == '-' && textBoxid.SelectionStart != 0))
            {
                e.Handled = true; // No permite ingresar un segundo signo negativo
            }
        }

        
    }
}
