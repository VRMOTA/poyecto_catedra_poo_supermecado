﻿namespace poyecto_catedra_poo_supermecado
{
    partial class frm_promociones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_promociones));
            this.textboxMaxing2 = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMaxing1 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.panel_cards = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // textboxMaxing2
            // 
            this.textboxMaxing2.BackColor = System.Drawing.Color.White;
            this.textboxMaxing2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textboxMaxing2.BorderFocusColor = System.Drawing.Color.Plum;
            this.textboxMaxing2.BorderSize = 7;
            this.textboxMaxing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxMaxing2.ForeColor = System.Drawing.Color.DimGray;
            this.textboxMaxing2.Location = new System.Drawing.Point(713, 30);
            this.textboxMaxing2.Margin = new System.Windows.Forms.Padding(4);
            this.textboxMaxing2.Multiline = false;
            this.textboxMaxing2.Name = "textboxMaxing2";
            this.textboxMaxing2.Padding = new System.Windows.Forms.Padding(7);
            this.textboxMaxing2.PasswordChar = false;
            this.textboxMaxing2.PlaceholderColor = System.Drawing.Color.Gray;
            this.textboxMaxing2.PlaceholderText = "Buscar";
            this.textboxMaxing2.Size = new System.Drawing.Size(490, 40);
            this.textboxMaxing2.TabIndex = 41;
            this.textboxMaxing2.Texts = "";
            this.textboxMaxing2.UnderlinedStyle = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 65);
            this.label1.TabIndex = 40;
            this.label1.Text = "Promociones";
            // 
            // buttonMaxing1
            // 
            this.buttonMaxing1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMaxing1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMaxing1.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing1.BorderRadius = 15;
            this.buttonMaxing1.BorderSize = 0;
            this.buttonMaxing1.FlatAppearance.BorderSize = 0;
            this.buttonMaxing1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxing1.ForeColor = System.Drawing.Color.White;
            this.buttonMaxing1.Image = ((System.Drawing.Image)(resources.GetObject("buttonMaxing1.Image")));
            this.buttonMaxing1.Location = new System.Drawing.Point(14, 19);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Size = new System.Drawing.Size(122, 46);
            this.buttonMaxing1.TabIndex = 39;
            this.buttonMaxing1.TextColor = System.Drawing.Color.White;
            this.buttonMaxing1.UseVisualStyleBackColor = false;
            // 
            // panel_cards
            // 
            this.panel_cards.Location = new System.Drawing.Point(14, 78);
            this.panel_cards.Name = "panel_cards";
            this.panel_cards.Size = new System.Drawing.Size(1220, 821);
            this.panel_cards.TabIndex = 42;
            // 
            // frm_promociones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 911);
            this.Controls.Add(this.panel_cards);
            this.Controls.Add(this.textboxMaxing2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMaxing1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_promociones";
            this.Text = "frm_promociones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing textboxMaxing2;
        private System.Windows.Forms.Label label1;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing buttonMaxing1;
        private System.Windows.Forms.Panel panel_cards;
    }
}