namespace poyecto_catedra_poo_supermecado
{
    partial class frm_distruibidores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_distruibidores));
            this.pnl_principal = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxMaxing2 = new Catedra.CustomControls.TextboxMaxing();
            this.buttonMaxing1 = new Catedra.CustomControls.ButtonMaxing();
            this.panel_cards = new System.Windows.Forms.Panel();
            this.pnl_principal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_principal
            // 
            this.pnl_principal.Controls.Add(this.panel_cards);
            this.pnl_principal.Controls.Add(this.textboxMaxing2);
            this.pnl_principal.Controls.Add(this.label1);
            this.pnl_principal.Controls.Add(this.buttonMaxing1);
            this.pnl_principal.Location = new System.Drawing.Point(-1, -2);
            this.pnl_principal.Name = "pnl_principal";
            this.pnl_principal.Size = new System.Drawing.Size(1280, 915);
            this.pnl_principal.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 39);
            this.label1.TabIndex = 33;
            this.label1.Text = "Distriubidor";
            // 
            // textboxMaxing2
            // 
            this.textboxMaxing2.BackColor = System.Drawing.Color.White;
            this.textboxMaxing2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textboxMaxing2.BorderFocusColor = System.Drawing.Color.Plum;
            this.textboxMaxing2.BorderSize = 7;
            this.textboxMaxing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxMaxing2.ForeColor = System.Drawing.Color.DimGray;
            this.textboxMaxing2.Location = new System.Drawing.Point(749, 41);
            this.textboxMaxing2.Margin = new System.Windows.Forms.Padding(4);
            this.textboxMaxing2.Multiline = false;
            this.textboxMaxing2.Name = "textboxMaxing2";
            this.textboxMaxing2.Padding = new System.Windows.Forms.Padding(7);
            this.textboxMaxing2.PasswordChar = false;
            this.textboxMaxing2.PlaceholderColor = System.Drawing.Color.Gray;
            this.textboxMaxing2.PlaceholderText = "Buscar";
            this.textboxMaxing2.Size = new System.Drawing.Size(490, 35);
            this.textboxMaxing2.TabIndex = 34;
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
            this.buttonMaxing1.Location = new System.Drawing.Point(50, 30);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Size = new System.Drawing.Size(122, 46);
            this.buttonMaxing1.TabIndex = 13;
            this.buttonMaxing1.TextColor = System.Drawing.Color.White;
            this.buttonMaxing1.UseVisualStyleBackColor = false;
            // 
            // panel_cards
            // 
            this.panel_cards.Location = new System.Drawing.Point(50, 96);
            this.panel_cards.Name = "panel_cards";
            this.panel_cards.Size = new System.Drawing.Size(1189, 805);
            this.panel_cards.TabIndex = 35;
            // 
            // frm_distruibidores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 911);
            this.Controls.Add(this.pnl_principal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_distruibidores";
            this.Text = "frm_distruibidores";
            this.pnl_principal.ResumeLayout(false);
            this.pnl_principal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_principal;
        private Catedra.CustomControls.ButtonMaxing buttonMaxing1;
        private System.Windows.Forms.Label label1;
        private Catedra.CustomControls.TextboxMaxing textboxMaxing2;
        private System.Windows.Forms.Panel panel_cards;
    }
}