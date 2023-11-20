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
    public partial class Frm_MenuNormal: Form
    {
        public Frm_MenuNormal()
        {
            InitializeComponent();
            
        }
        public string iduser { get; set; }
        DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2();
        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Frm_inicioSesion ini = new Frm_inicioSesion();
            this.Hide();
            ini.ShowDialog();


        }


        private void gestionDePersonasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            abrirformhija(new Frm_Usuario());

        }

        private void articulosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            abrirformhija(new Frm_Articulos());
        }

        private void provedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            abrirformhija(new Frm_proveedores());
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

            //Esto se usa para comprobar si el panel tiene contenido, si tiene sacarlo,
            //usar el que se selecciona y ajustarlo al panel


        }

        private void nuevaFacturaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            abrirformhija(new Frm_venta());
        }

        private void nuevoClienteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            abrirformhija(new Frm_Adm_clientes());
        }

        private void inicioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void vigilanciaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            abrirformhija(new Frm_camara());
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Muestra un MessageBox de confirmación
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Frm_inicioSesion ini = new Frm_inicioSesion();
                this.Close();
                ini.ShowDialog();
                MessageBox.Show("La sesión ha sido cerrada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // El usuario seleccionó "No", no cierres la sesión o realiza alguna otra acción según tus necesidades
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            abrirformhija(new Frm_Adm_clientes());
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Frm_MenuNormal_FormClosing(object sender, FormClosingEventArgs e)
        {
            horaDeCierre = DateTime.Now;
        }
        private DateTime horaDeCierre;
        private DateTime horaDeApertura;

        private void Frm_MenuNormal_Load(object sender, EventArgs e)
        {
            horaDeApertura = DateTime.Now;
        }

        private void Frm_MenuNormal_FormClosed(object sender, FormClosedEventArgs e)
        {
            SESION sesion = new SESION();
            sesion.UsuarioID = int.Parse(iduser);
            sesion.Hora_inicio = horaDeApertura;
            sesion.Fecha = DateTime.Today;
            sesion.Hora_Finalizacion = horaDeCierre;
            ddbb.SESIONES.Add(sesion);
            ddbb.SaveChanges();
        }
    }
    
}
