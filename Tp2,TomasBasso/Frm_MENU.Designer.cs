namespace Tp2_TomasBasso
{
    partial class Frm_MENU
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MENU));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDePersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vigilanciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verIniciosDeSeciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.verVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.articulosToolStripMenuItem,
            this.gestionDePersonasToolStripMenuItem,
            this.provedoresToolStripMenuItem,
            this.facturacionToolStripMenuItem,
            this.vigilanciaToolStripMenuItem,
            this.configuracionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_casa_50;
            resources.ApplyResources(this.inicioToolStripMenuItem, "inicioToolStripMenuItem");
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // articulosToolStripMenuItem
            // 
            resources.ApplyResources(this.articulosToolStripMenuItem, "articulosToolStripMenuItem");
            this.articulosToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.Articulos;
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click);
            // 
            // gestionDePersonasToolStripMenuItem
            // 
            resources.ApplyResources(this.gestionDePersonasToolStripMenuItem, "gestionDePersonasToolStripMenuItem");
            this.gestionDePersonasToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_joining_queue_64;
            this.gestionDePersonasToolStripMenuItem.Name = "gestionDePersonasToolStripMenuItem";
            this.gestionDePersonasToolStripMenuItem.Click += new System.EventHandler(this.gestionDePersonasToolStripMenuItem_Click);
            // 
            // provedoresToolStripMenuItem
            // 
            resources.ApplyResources(this.provedoresToolStripMenuItem, "provedoresToolStripMenuItem");
            this.provedoresToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_carga_50;
            this.provedoresToolStripMenuItem.Name = "provedoresToolStripMenuItem";
            this.provedoresToolStripMenuItem.Click += new System.EventHandler(this.provedoresToolStripMenuItem_Click);
            // 
            // facturacionToolStripMenuItem
            // 
            this.facturacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteToolStripMenuItem,
            this.nuevaFacturaToolStripMenuItem,
            this.verVentasToolStripMenuItem});
            resources.ApplyResources(this.facturacionToolStripMenuItem, "facturacionToolStripMenuItem");
            this.facturacionToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_factura_50__1_;
            this.facturacionToolStripMenuItem.Name = "facturacionToolStripMenuItem";
            // 
            // nuevoClienteToolStripMenuItem
            // 
            this.nuevoClienteToolStripMenuItem.Name = "nuevoClienteToolStripMenuItem";
            resources.ApplyResources(this.nuevoClienteToolStripMenuItem, "nuevoClienteToolStripMenuItem");
            this.nuevoClienteToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteToolStripMenuItem_Click);
            // 
            // nuevaFacturaToolStripMenuItem
            // 
            this.nuevaFacturaToolStripMenuItem.Name = "nuevaFacturaToolStripMenuItem";
            resources.ApplyResources(this.nuevaFacturaToolStripMenuItem, "nuevaFacturaToolStripMenuItem");
            this.nuevaFacturaToolStripMenuItem.Click += new System.EventHandler(this.nuevaFacturaToolStripMenuItem_Click);
            // 
            // vigilanciaToolStripMenuItem
            // 
            this.vigilanciaToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_vigilancia_50;
            resources.ApplyResources(this.vigilanciaToolStripMenuItem, "vigilanciaToolStripMenuItem");
            this.vigilanciaToolStripMenuItem.Name = "vigilanciaToolStripMenuItem";
            this.vigilanciaToolStripMenuItem.Click += new System.EventHandler(this.vigilanciaToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.verIniciosDeSeciónToolStripMenuItem});
            resources.ApplyResources(this.configuracionToolStripMenuItem, "configuracionToolStripMenuItem");
            this.configuracionToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.Config;
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            resources.ApplyResources(this.usuariosToolStripMenuItem, "usuariosToolStripMenuItem");
            // 
            // verIniciosDeSeciónToolStripMenuItem
            // 
            this.verIniciosDeSeciónToolStripMenuItem.Name = "verIniciosDeSeciónToolStripMenuItem";
            resources.ApplyResources(this.verIniciosDeSeciónToolStripMenuItem, "verIniciosDeSeciónToolStripMenuItem");
            // 
            // salirToolStripMenuItem
            // 
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_fire_exit_50;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // verVentasToolStripMenuItem
            // 
            this.verVentasToolStripMenuItem.Name = "verVentasToolStripMenuItem";
            resources.ApplyResources(this.verVentasToolStripMenuItem, "verVentasToolStripMenuItem");
            this.verVentasToolStripMenuItem.Click += new System.EventHandler(this.verVentasToolStripMenuItem_Click);
            // 
            // Frm_MENU
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.BackgroundImage = global::Tp2_TomasBasso.Properties.Resources.Logo;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_MENU";
            this.Load += new System.EventHandler(this.Frm_MENU_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDePersonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vigilanciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verIniciosDeSeciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaFacturaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem verVentasToolStripMenuItem;
    }
}