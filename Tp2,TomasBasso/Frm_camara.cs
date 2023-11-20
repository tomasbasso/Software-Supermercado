using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Tp2_TomasBasso
{
    public partial class Frm_camara : Form
    {
        public Frm_camara()
        {
            InitializeComponent();
        }
        private string video2 = @"C:\Users\Usuario\Desktop\ITES\2DO AÑO\Copia TP2pROG\Andando hasta 1-11\5\Tp2,TomasBasso\Tp2,TomasBasso\Resources\v2.mp4";
        private string video1 = @"C:\Users\Usuario\Desktop\ITES\2DO AÑO\Copia TP2pROG\Andando hasta 1-11\5\Tp2,TomasBasso\Tp2,TomasBasso\Resources\v1.mp4";
        private void btn_encender_Click(object sender, EventArgs e)
        {
            
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer2.Ctlcontrols.play();

        }

        private void btn_apagar_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer2.Ctlcontrols.stop();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_camara_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = video1;
            axWindowsMediaPlayer2.URL = video2;
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer2.Ctlcontrols.stop();
        }
    }
}
