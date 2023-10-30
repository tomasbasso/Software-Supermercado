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
using System.Security.Cryptography;


namespace Tp2_TomasBasso
{
    public partial class Frm_inicioSesion : Form
    {
        public Frm_inicioSesion()
        {
            InitializeComponent();
            
        }
        
        private void btn_inicio_Click(object sender, EventArgs e)
        {


            
            using (Models.DDBB_SupermercadoEntities2 DDBB = new Models.DDBB_SupermercadoEntities2()) 
            {
                var lista = from d in DDBB.USUARIOS
                            where d.NombreUsuario == txt_nombre.Text
                            && d.Contraseña == txt_contraseña.Text
                            select d; //VERIFICO USUARIO Y CONTRASEÑA
                if (lista.Count() > 0)
                {
                    MessageBox.Show("Bienvenido/a "+ txt_nombre.Text);
                    
                    Frm_MENU fm = new Frm_MENU();
                    fm.Show();
                    this.Hide();

                }
                else {
                    MessageBox.Show("Error en usuario o contraseña, intentolo nuevamente");
                }
            }
       

          
        }

        
    }
}
