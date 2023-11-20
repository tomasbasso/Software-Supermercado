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

namespace Tp2_TomasBasso
{
    public partial class Frm_Sesion : Form
    {
        public Frm_Sesion()
        {
            InitializeComponent();
        }
        DDBB_SupermercadoEntities2 ddbb = new DDBB_SupermercadoEntities2();
        private void Frm_Sesion_Load(object sender, EventArgs e)
        {
            RefrescarGrilla();
        }
        public void RefrescarGrilla()
        {
            var lista = ddbb.SESIONES.ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["USUARIOS"].Visible = false;
        }
    }
}
