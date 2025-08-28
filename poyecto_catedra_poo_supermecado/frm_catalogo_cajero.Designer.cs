namespace poyecto_catedra_poo_supermecado
{
    partial class frm_catalogo_cajero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_catalogo_cajero));
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundedControlBase1 = new poyecto_catedra_poo_supermecado.CustomCards.RoundedControlBase();
            this.textboxMaxing1 = new Catedra.CustomControls.TextboxMaxing();
            this.buttonMaxing1 = new Catedra.CustomControls.ButtonMaxing();
            this.card_producto_menu1 = new poyecto_catedra_poo_supermecado.CustomCards.card_producto_menu();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.card_producto_menu1);
            this.panel1.Location = new System.Drawing.Point(13, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 844);
            this.panel1.TabIndex = 4;
            // 
            // roundedControlBase1
            // 
            this.roundedControlBase1.BackColor = System.Drawing.Color.Transparent;
            this.roundedControlBase1.BorderColor = System.Drawing.Color.Gray;
            this.roundedControlBase1.BorderThickness = 1;
            this.roundedControlBase1.CornerRadius = 12;
            this.roundedControlBase1.FillColor = System.Drawing.Color.White;
            this.roundedControlBase1.Location = new System.Drawing.Point(1000, 55);
            this.roundedControlBase1.Name = "roundedControlBase1";
            this.roundedControlBase1.Size = new System.Drawing.Size(266, 844);
            this.roundedControlBase1.TabIndex = 3;
            // 
            // textboxMaxing1
            // 
            this.textboxMaxing1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.textboxMaxing1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textboxMaxing1.BorderFocusColor = System.Drawing.Color.Plum;
            this.textboxMaxing1.BorderSize = 7;
            this.textboxMaxing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxMaxing1.ForeColor = System.Drawing.Color.DimGray;
            this.textboxMaxing1.Location = new System.Drawing.Point(13, 13);
            this.textboxMaxing1.Margin = new System.Windows.Forms.Padding(4);
            this.textboxMaxing1.Multiline = false;
            this.textboxMaxing1.Name = "textboxMaxing1";
            this.textboxMaxing1.Padding = new System.Windows.Forms.Padding(7);
            this.textboxMaxing1.PasswordChar = false;
            this.textboxMaxing1.PlaceholderColor = System.Drawing.Color.Gray;
            this.textboxMaxing1.PlaceholderText = "Buscar";
            this.textboxMaxing1.Size = new System.Drawing.Size(1079, 35);
            this.textboxMaxing1.TabIndex = 2;
            this.textboxMaxing1.Texts = "";
            this.textboxMaxing1.UnderlinedStyle = true;
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
            this.buttonMaxing1.Location = new System.Drawing.Point(1099, 12);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Size = new System.Drawing.Size(167, 36);
            this.buttonMaxing1.TabIndex = 1;
            this.buttonMaxing1.TextColor = System.Drawing.Color.White;
            this.buttonMaxing1.UseVisualStyleBackColor = false;
            // 
            // card_producto_menu1
            // 
            this.card_producto_menu1.BackColor = System.Drawing.Color.Transparent;
            this.card_producto_menu1.BorderColor = System.Drawing.Color.Gray;
            this.card_producto_menu1.BorderThickness = 1;
            this.card_producto_menu1.CornerRadius = 12;
            this.card_producto_menu1.Descuento = 0;
            this.card_producto_menu1.FillColor = System.Drawing.Color.White;
            this.card_producto_menu1.ImagenProducto = ((System.Drawing.Image)(resources.GetObject("card_producto_menu1.ImagenProducto")));
            this.card_producto_menu1.Location = new System.Drawing.Point(3, 3);
            this.card_producto_menu1.Name = "card_producto_menu1";
            this.card_producto_menu1.Precio = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.card_producto_menu1.Producto = "Nombre Producto";
            this.card_producto_menu1.Size = new System.Drawing.Size(241, 266);
            this.card_producto_menu1.TabIndex = 0;
            // 
            // frm_catalogo_cajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1278, 911);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.roundedControlBase1);
            this.Controls.Add(this.textboxMaxing1);
            this.Controls.Add(this.buttonMaxing1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_catalogo_cajero";
            this.Text = "frm_catalogo_cajero";
            this.Load += new System.EventHandler(this.frm_catalogo_cajero_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Catedra.CustomControls.ButtonMaxing buttonMaxing1;
        private Catedra.CustomControls.TextboxMaxing textboxMaxing1;
        private CustomCards.RoundedControlBase roundedControlBase1;
        private System.Windows.Forms.Panel panel1;
        private CustomCards.card_producto_menu card_producto_menu1;
    }
}