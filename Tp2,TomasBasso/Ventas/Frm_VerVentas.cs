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

namespace Tp2_TomasBasso.Ventas
{
    public partial class Frm_VerVentas : Form
    {
        public Frm_VerVentas()
        {
            InitializeComponent();
        }
        DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2();
        private void Frm_VerVentas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            RefrescarGrilla();
        }
        public void RefrescarGrilla()
        {
            var lista = ddbb.VENTAS.ToList();
            dataGridView1.DataSource = lista;
        }
    }
}
