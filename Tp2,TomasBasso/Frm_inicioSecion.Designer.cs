namespace Tp2_TomasBasso
{
    partial class Frm_inicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_inicioSesion));
            this.txt_contraseña = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label_contraseña = new System.Windows.Forms.Label();
            this.label_usuario = new System.Windows.Forms.Label();
            this.btn_inicio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_contraseña
            // 
            this.txt_contraseña.Location = new System.Drawing.Point(792, 322);
            this.txt_contraseña.Name = "txt_contraseña";
            this.txt_contraseña.PasswordChar = '*';
            this.txt_contraseña.Size = new System.Drawing.Size(232, 22);
            this.txt_contraseña.TabIndex = 9;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(794, 220);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(232, 22);
            this.txt_nombre.TabIndex = 8;
            // 
            // label_contraseña
            // 
            this.label_contraseña.AutoSize = true;
            this.label_contraseña.BackColor = System.Drawing.Color.Orange;
            this.label_contraseña.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_contraseña.Location = new System.Drawing.Point(833, 273);
            this.label_contraseña.Name = "label_contraseña";
            this.label_contraseña.Size = new System.Drawing.Size(138, 29);
            this.label_contraseña.TabIndex = 7;
            this.label_contraseña.Text = "Contraseña:";
            // 
            // label_usuario
            // 
            this.label_usuario.AutoSize = true;
            this.label_usuario.BackColor = System.Drawing.Color.Orange;
            this.label_usuario.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_usuario.Location = new System.Drawing.Point(851, 171);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(99, 29);
            this.label_usuario.TabIndex = 6;
            this.label_usuario.Text = "Usuario:";
            // 
            // btn_inicio
            // 
            this.btn_inicio.AutoSize = true;
            this.btn_inicio.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_inicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inicio.FlatAppearance.BorderSize = 5;
            this.btn_inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inicio.Font = new System.Drawing.Font("Goudy Old Style", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inicio.Location = new System.Drawing.Point(818, 406);
            this.btn_inicio.Name = "btn_inicio";
            this.btn_inicio.Size = new System.Drawing.Size(182, 68);
            this.btn_inicio.TabIndex = 5;
            this.btn_inicio.Text = "Iniciar sesión";
            this.btn_inicio.UseMnemonic = false;
            this.btn_inicio.UseVisualStyleBackColor = false;
            this.btn_inicio.Click += new System.EventHandler(this.btn_inicio_Click);
            // 
            // Frm_inicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImage = global::Tp2_TomasBasso.Properties.Resources.Diseño_sin_título__1_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1156, 583);
            this.Controls.Add(this.btn_inicio);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.txt_contraseña);
            this.Controls.Add(this.label_contraseña);
            this.Controls.Add(this.label_usuario);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_inicioSesion";
            this.Text = "Inicio de sesión";
            this.Load += new System.EventHandler(this.Frm_inicioSesion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_contraseña;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label_contraseña;
        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.Button btn_inicio;
    }
}