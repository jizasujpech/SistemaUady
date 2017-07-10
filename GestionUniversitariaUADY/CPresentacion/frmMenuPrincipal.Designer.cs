namespace CPresentacion
{
    partial class frmMenuPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.btnAltaProblematica = new System.Windows.Forms.Button();
            this.btnSeguimientoProblematica = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAltaProblematica
            // 
            this.btnAltaProblematica.Location = new System.Drawing.Point(31, 61);
            this.btnAltaProblematica.Name = "btnAltaProblematica";
            this.btnAltaProblematica.Size = new System.Drawing.Size(93, 82);
            this.btnAltaProblematica.TabIndex = 0;
            this.btnAltaProblematica.Text = "Alta Problematica";
            this.btnAltaProblematica.UseVisualStyleBackColor = true;
            this.btnAltaProblematica.Click += new System.EventHandler(this.btnAltaProblematica_Click);
            // 
            // btnSeguimientoProblematica
            // 
            this.btnSeguimientoProblematica.Location = new System.Drawing.Point(157, 61);
            this.btnSeguimientoProblematica.Name = "btnSeguimientoProblematica";
            this.btnSeguimientoProblematica.Size = new System.Drawing.Size(95, 82);
            this.btnSeguimientoProblematica.TabIndex = 1;
            this.btnSeguimientoProblematica.Text = "Seguimiento de Problematica";
            this.btnSeguimientoProblematica.UseVisualStyleBackColor = true;
            this.btnSeguimientoProblematica.Click += new System.EventHandler(this.btnSeguimientoProblematica_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "application-pgp-signature.png");
            this.imageList1.Images.SetKeyName(1, "application-pgp-signature (1).png");
            this.imageList1.Images.SetKeyName(2, "application-pgp-signature (2).png");
            this.imageList1.Images.SetKeyName(3, "lock-128.png");
            this.imageList1.Images.SetKeyName(4, "inside-logout-icon.png");
            this.imageList1.Images.SetKeyName(5, "user_man_lock_password_security-128.png");
            this.imageList1.Images.SetKeyName(6, "power_shut_shut_down_switch-128.png");
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ImageIndex = 6;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(335, 179);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 70);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 261);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSeguimientoProblematica);
            this.Controls.Add(this.btnAltaProblematica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAltaProblematica;
        private System.Windows.Forms.Button btnSeguimientoProblematica;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSalir;
    }
}