namespace poyecto_catedra_poo_supermecado.Forms
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel_cards = new System.Windows.Forms.Panel();
            this.textboxMaxing2 = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.buttonMaxing1 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 39);
            this.label1.TabIndex = 40;
            this.label1.Text = "Promociones";
            // 
            // panel_cards
            // 
            this.panel_cards.Location = new System.Drawing.Point(19, 96);
            this.panel_cards.Margin = new System.Windows.Forms.Padding(4);
            this.panel_cards.Name = "panel_cards";
            this.panel_cards.Size = new System.Drawing.Size(1627, 1010);
            this.panel_cards.TabIndex = 42;
            // 
            // textboxMaxing2
            // 
            this.textboxMaxing2.BackColor = System.Drawing.Color.White;
            this.textboxMaxing2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textboxMaxing2.BorderFocusColor = System.Drawing.Color.Plum;
            this.textboxMaxing2.BorderSize = 7;
            this.textboxMaxing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxMaxing2.ForeColor = System.Drawing.Color.DimGray;
            this.textboxMaxing2.Location = new System.Drawing.Point(951, 37);
            this.textboxMaxing2.Margin = new System.Windows.Forms.Padding(5);
            this.textboxMaxing2.Multiline = false;
            this.textboxMaxing2.Name = "textboxMaxing2";
            this.textboxMaxing2.Padding = new System.Windows.Forms.Padding(9);
            this.textboxMaxing2.PasswordChar = false;
            this.textboxMaxing2.PlaceholderColor = System.Drawing.Color.Gray;
            this.textboxMaxing2.PlaceholderText = "Buscar";
            this.textboxMaxing2.Size = new System.Drawing.Size(653, 39);
            this.textboxMaxing2.TabIndex = 41;
            this.textboxMaxing2.Texts = "";
            this.textboxMaxing2.UnderlinedStyle = true;
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
            this.buttonMaxing1.Location = new System.Drawing.Point(19, 23);
            this.buttonMaxing1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Size = new System.Drawing.Size(163, 57);
            this.buttonMaxing1.TabIndex = 39;
            this.buttonMaxing1.TextColor = System.Drawing.Color.White;
            this.buttonMaxing1.UseVisualStyleBackColor = false;
            this.buttonMaxing1.Click += new System.EventHandler(this.buttonMaxing1_Click);
            // 
            // frm_promociones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1705, 1100);
            this.Controls.Add(this.panel_cards);
            this.Controls.Add(this.textboxMaxing2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMaxing1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_promociones";
            this.Text = "frm_promociones";
            this.Load += new System.EventHandler(this.frm_promociones_Load);
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