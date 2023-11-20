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
            string usuarion;
            using (Models.DDBB_SupermercadoEntities2 DDBB = new Models.DDBB_SupermercadoEntities2())
            {
                var usuario = (from d in DDBB.USUARIOS
                               where d.NombreUsuario == txt_nombre.Text
                               && d.Contraseña == txt_contraseña.Text
                               select d).FirstOrDefault(); // Buscar el usuario
                
                if (usuario != null)
                {
                    usuarion =Convert.ToString( usuario.UsuarioID);
                    MessageBox.Show("Bienvenido/a " + txt_nombre.Text);

                    if (usuario.Acceso == "Administrativo")
                    {
                        Frm_MenuAdmin fm = new Frm_MenuAdmin();
                        fm.iduser =usuarion;
                        fm.Show();

                    }
                    else if (usuario.Acceso == "Gerente")
                    {
                        Frm_MenuNormal fm = new Frm_MenuNormal();
                        fm.iduser = usuarion;
                        fm.Show();
                        
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error en usuario o contraseña, inténtelo nuevamente");
                }
            }
            



        }

        private void Frm_inicioSesion_Load(object sender, EventArgs e)
        {

        }
    }
}