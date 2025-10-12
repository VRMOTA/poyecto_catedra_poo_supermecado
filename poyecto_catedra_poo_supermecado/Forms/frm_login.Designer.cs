namespace poyecto_catedra_poo_supermecado.Forms
{
    partial class frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.panelRedondeado1 = new poyecto_catedra_poo_supermecado.CustomControls.PanelRedondeado();
            this.buttonMaxing2 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMaxing1 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.txtClave = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.txtCorreo = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelRedondeado1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRedondeado1
            // 
            this.panelRedondeado1.BackColor = System.Drawing.Color.White;
            this.panelRedondeado1.ColorBorde = System.Drawing.Color.White;
            this.panelRedondeado1.ColorFin = System.Drawing.Color.White;
            this.panelRedondeado1.ColorInicio = System.Drawing.Color.White;
            this.panelRedondeado1.Controls.Add(this.buttonMaxing2);
            this.panelRedondeado1.Controls.Add(this.label4);
            this.panelRedondeado1.Controls.Add(this.label3);
            this.panelRedondeado1.Controls.Add(this.label2);
            this.panelRedondeado1.Controls.Add(this.label1);
            this.panelRedondeado1.Controls.Add(this.buttonMaxing1);
            this.panelRedondeado1.Controls.Add(this.txtClave);
            this.panelRedondeado1.Controls.Add(this.txtCorreo);
            this.panelRedondeado1.ForeColor = System.Drawing.Color.Black;
            this.panelRedondeado1.Location = new System.Drawing.Point(350, 109);
            this.panelRedondeado1.Name = "panelRedondeado1";
            this.panelRedondeado1.Size = new System.Drawing.Size(344, 428);
            this.panelRedondeado1.TabIndex = 1;
            // 
            // buttonMaxing2
            // 
            this.buttonMaxing2.BackColor = System.Drawing.Color.DimGray;
            this.buttonMaxing2.BackgroundColor = System.Drawing.Color.DimGray;
            this.buttonMaxing2.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing2.BorderRadius = 15;
            this.buttonMaxing2.BorderSize = 0;
            this.buttonMaxing2.FlatAppearance.BorderSize = 0;
            this.buttonMaxing2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaxing2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing2.Location = new System.Drawing.Point(40, 340);
            this.buttonMaxing2.Name = "buttonMaxing2";
            this.buttonMaxing2.Size = new System.Drawing.Size(124, 52);
            this.buttonMaxing2.TabIndex = 7;
            this.buttonMaxing2.Text = "Regresar";
            this.buttonMaxing2.TextColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing2.UseVisualStyleBackColor = false;
            this.buttonMaxing2.Click += new System.EventHandler(this.buttonMaxing2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Clave";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Correo";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(42, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 44);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ingresa tus credenciales para poder entrar al sistema";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bienvenido";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonMaxing1
            // 
            this.buttonMaxing1.BackColor = System.Drawing.Color.Red;
            this.buttonMaxing1.BackgroundColor = System.Drawing.Color.Red;
            this.buttonMaxing1.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing1.BorderRadius = 15;
            this.buttonMaxing1.BorderSize = 0;
            this.buttonMaxing1.FlatAppearance.BorderSize = 0;
            this.buttonMaxing1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaxing1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing1.Location = new System.Drawing.Point(170, 340);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Size = new System.Drawing.Size(131, 52);
            this.buttonMaxing1.TabIndex = 2;
            this.buttonMaxing1.Text = "Ingresar";
            this.buttonMaxing1.TextColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing1.UseVisualStyleBackColor = false;
            this.buttonMaxing1.Click += new System.EventHandler(this.buttonMaxing1_Click);
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtClave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtClave.BorderFocusColor = System.Drawing.Color.Plum;
            this.txtClave.BorderSize = 7;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.ForeColor = System.Drawing.Color.DimGray;
            this.txtClave.Location = new System.Drawing.Point(40, 267);
            this.txtClave.Margin = new System.Windows.Forms.Padding(4);
            this.txtClave.Multiline = false;
            this.txtClave.Name = "txtClave";
            this.txtClave.Padding = new System.Windows.Forms.Padding(7);
            this.txtClave.PasswordChar = true;
            this.txtClave.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtClave.PlaceholderText = "";
            this.txtClave.Size = new System.Drawing.Size(261, 35);
            this.txtClave.TabIndex = 1;
            this.txtClave.Texts = "";
            this.txtClave.UnderlinedStyle = true;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtCorreo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCorreo.BorderFocusColor = System.Drawing.Color.Plum;
            this.txtCorreo.BorderSize = 7;
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCorreo.Location = new System.Drawing.Point(40, 180);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.Multiline = false;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Padding = new System.Windows.Forms.Padding(7);
            this.txtCorreo.PasswordChar = false;
            this.txtCorreo.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtCorreo.PlaceholderText = "";
            this.txtCorreo.Size = new System.Drawing.Size(261, 35);
            this.txtCorreo.TabIndex = 0;
            this.txtCorreo.Texts = "";
            this.txtCorreo.UnderlinedStyle = true;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1021, 678);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 681);
            this.Controls.Add(this.panelRedondeado1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_login";
            this.Text = "Login ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_login_FormClosed);
            this.panelRedondeado1.ResumeLayout(false);
            this.panelRedondeado1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private poyecto_catedra_poo_supermecado.CustomControls.PanelRedondeado panelRedondeado1;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing buttonMaxing1;
        private poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing txtClave;
        private poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing txtCorreo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing buttonMaxing2;
    }
}