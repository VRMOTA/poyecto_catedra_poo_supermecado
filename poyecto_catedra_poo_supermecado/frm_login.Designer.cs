﻿namespace project_supermercado
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
            this.panelRedondeado1 = new project_supermercado.CustomControls.PanelRedondeado();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMaxing1 = new Catedra.CustomControls.ButtonMaxing();
            this.txtClave = new Catedra.CustomControls.TextboxMaxing();
            this.txtCorreo = new Catedra.CustomControls.TextboxMaxing();
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
            this.panelRedondeado1.Controls.Add(this.label4);
            this.panelRedondeado1.Controls.Add(this.label3);
            this.panelRedondeado1.Controls.Add(this.label2);
            this.panelRedondeado1.Controls.Add(this.label1);
            this.panelRedondeado1.Controls.Add(this.buttonMaxing1);
            this.panelRedondeado1.Controls.Add(this.txtClave);
            this.panelRedondeado1.Controls.Add(this.txtCorreo);
            this.panelRedondeado1.ForeColor = System.Drawing.Color.Black;
            this.panelRedondeado1.Location = new System.Drawing.Point(306, 109);
            this.panelRedondeado1.Name = "panelRedondeado1";
            this.panelRedondeado1.Size = new System.Drawing.Size(398, 462);
            this.panelRedondeado1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Correo";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(66, 89);
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
            this.label1.Location = new System.Drawing.Point(64, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bienvenido";
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
            this.buttonMaxing1.Location = new System.Drawing.Point(64, 350);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Size = new System.Drawing.Size(261, 63);
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
            this.txtClave.Location = new System.Drawing.Point(64, 267);
            this.txtClave.Margin = new System.Windows.Forms.Padding(4);
            this.txtClave.Multiline = false;
            this.txtClave.Name = "txtClave";
            this.txtClave.Padding = new System.Windows.Forms.Padding(7);
            this.txtClave.PasswordChar = false;
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
            this.txtCorreo.Location = new System.Drawing.Point(64, 180);
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
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::poyecto_catedra_poo_supermecado.Properties.Resources.background;
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
            this.Name = "frm_login";
            this.Text = "frm_login";
            this.panelRedondeado1.ResumeLayout(false);
            this.panelRedondeado1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.PanelRedondeado panelRedondeado1;
        private Catedra.CustomControls.ButtonMaxing buttonMaxing1;
        private Catedra.CustomControls.TextboxMaxing txtClave;
        private Catedra.CustomControls.TextboxMaxing txtCorreo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}