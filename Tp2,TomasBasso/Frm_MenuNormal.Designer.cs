﻿namespace Tp2_TomasBasso
{
    partial class Frm_MenuNormal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MenuNormal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vigilanciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.menuStrip1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.articulosToolStripMenuItem,
            this.provedoresToolStripMenuItem,
            this.facturacionToolStripMenuItem,
            this.vigilanciaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1278, 58);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_casa_50;
            this.inicioToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inicioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(115, 54);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F);
            this.articulosToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.Articulos;
            this.articulosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(138, 54);
            this.articulosToolStripMenuItem.Text = "Articulos";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click_1);
            // 
            // provedoresToolStripMenuItem
            // 
            this.provedoresToolStripMenuItem.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F);
            this.provedoresToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_carga_50;
            this.provedoresToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.provedoresToolStripMenuItem.Name = "provedoresToolStripMenuItem";
            this.provedoresToolStripMenuItem.Size = new System.Drawing.Size(157, 54);
            this.provedoresToolStripMenuItem.Text = "Provedores";
            this.provedoresToolStripMenuItem.Click += new System.EventHandler(this.provedoresToolStripMenuItem_Click_1);
            // 
            // facturacionToolStripMenuItem
            // 
            this.facturacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaFacturaToolStripMenuItem,
            this.toolStripMenuItem1});
            this.facturacionToolStripMenuItem.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F);
            this.facturacionToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_factura_50__1_;
            this.facturacionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.facturacionToolStripMenuItem.Name = "facturacionToolStripMenuItem";
            this.facturacionToolStripMenuItem.Size = new System.Drawing.Size(165, 54);
            this.facturacionToolStripMenuItem.Text = "Transacciones";
            // 
            // nuevaFacturaToolStripMenuItem
            // 
            this.nuevaFacturaToolStripMenuItem.Name = "nuevaFacturaToolStripMenuItem";
            this.nuevaFacturaToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.nuevaFacturaToolStripMenuItem.Text = "Nueva Factura";
            this.nuevaFacturaToolStripMenuItem.Click += new System.EventHandler(this.nuevaFacturaToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(263, 26);
            this.toolStripMenuItem1.Text = "Administracion de clientes";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // vigilanciaToolStripMenuItem
            // 
            this.vigilanciaToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_vigilancia_50;
            this.vigilanciaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.vigilanciaToolStripMenuItem.Name = "vigilanciaToolStripMenuItem";
            this.vigilanciaToolStripMenuItem.Size = new System.Drawing.Size(145, 54);
            this.vigilanciaToolStripMenuItem.Text = "Vigilancia";
            this.vigilanciaToolStripMenuItem.Click += new System.EventHandler(this.vigilanciaToolStripMenuItem_Click_1);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F);
            this.salirToolStripMenuItem.Image = global::Tp2_TomasBasso.Properties.Resources.icons8_fire_exit_50;
            this.salirToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(104, 54);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackgroundImage = global::Tp2_TomasBasso.Properties.Resources.Logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 675);
            this.panel1.TabIndex = 11;
            // 
            // Frm_MenuNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tp2_TomasBasso.Properties.Resources.Logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1278, 733);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_MenuNormal";
            this.Text = "Los Dos Chinos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_MenuNormal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_MenuNormal_FormClosed);
            this.Load += new System.EventHandler(this.Frm_MenuNormal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vigilanciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}