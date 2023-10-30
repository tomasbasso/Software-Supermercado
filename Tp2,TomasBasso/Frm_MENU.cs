using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tp2_TomasBasso.Articulos;
using Tp2_TomasBasso.Models;
using Tp2_TomasBasso.Proveedores;
using Tp2_TomasBasso.Venta;
using Tp2_TomasBasso.Ventas;

namespace Tp2_TomasBasso
{
    public partial class Frm_MENU : Form
    {
        public Frm_MENU()
        {
            InitializeComponent();
         
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_inicioSesion ini = new Frm_inicioSesion();
            this.Hide();
            ini.ShowDialog();


        }


        private void gestionDePersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            abrirformhija(new Frm_Usuario());

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformhija(new Frm_Articulos());
        }

        private void provedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformhija(new Frm_proveedores());
        }

        private void Frm_MENU_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void abrirformhija(object formhija)
        {

            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;//hace que se acople
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;
            fh.Show();


        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformhija(new Frm_venta());
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformhija(new Frm_Adm_clientes());
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void vigilanciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformhija(new Frm_camara());
        }

        private void verVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformhija(new Frm_VerVentas());
        }
    }
}
