namespace poyecto_catedra_poo_supermecado
{
    partial class frm_consultas_cajero
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundedControlBase1 = new poyecto_catedra_poo_supermecado.CustomCards.RoundedControlBase();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 887);
            this.panel1.TabIndex = 0;
            // 
            // roundedControlBase1
            // 
            this.roundedControlBase1.BackColor = System.Drawing.Color.Transparent;
            this.roundedControlBase1.BorderColor = System.Drawing.Color.Gray;
            this.roundedControlBase1.BorderThickness = 1;
            this.roundedControlBase1.CornerRadius = 12;
            this.roundedControlBase1.FillColor = System.Drawing.Color.White;
            this.roundedControlBase1.Location = new System.Drawing.Point(966, 12);
            this.roundedControlBase1.Name = "roundedControlBase1";
            this.roundedControlBase1.Size = new System.Drawing.Size(300, 887);
            this.roundedControlBase1.TabIndex = 1;
            // 
            // frm_consultas_cajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1278, 911);
            this.Controls.Add(this.roundedControlBase1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_consultas_cajero";
            this.Text = "frm_consultas_cajero";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomCards.RoundedControlBase roundedControlBase1;
    }
}