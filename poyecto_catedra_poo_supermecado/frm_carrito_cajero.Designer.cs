namespace poyecto_catedra_poo_supermecado
{
    partial class frm_carrito_cajero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_carrito_cajero));
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundedControlBase1 = new poyecto_catedra_poo_supermecado.CustomCards.RoundedControlBase();
            this.card_producto_carrito1 = new poyecto_catedra_poo_supermecado.CustomCards.card_producto_carrito();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.card_producto_carrito1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 887);
            this.panel1.TabIndex = 0;
            // 
            // roundedControlBase1
            // 
            this.roundedControlBase1.BackColor = System.Drawing.Color.Transparent;
            this.roundedControlBase1.BorderColor = System.Drawing.Color.Gray;
            this.roundedControlBase1.BorderThickness = 1;
            this.roundedControlBase1.CornerRadius = 12;
            this.roundedControlBase1.FillColor = System.Drawing.Color.White;
            this.roundedControlBase1.Location = new System.Drawing.Point(876, 12);
            this.roundedControlBase1.Name = "roundedControlBase1";
            this.roundedControlBase1.Size = new System.Drawing.Size(358, 872);
            this.roundedControlBase1.TabIndex = 2;
            this.roundedControlBase1.Load += new System.EventHandler(this.roundedControlBase1_Load);
            // 
            // card_producto_carrito1
            // 
            this.card_producto_carrito1.BackColor = System.Drawing.Color.Transparent;
            this.card_producto_carrito1.BorderColor = System.Drawing.Color.Gray;
            this.card_producto_carrito1.BorderThickness = 1;
            this.card_producto_carrito1.Cantidad = 0;
            this.card_producto_carrito1.CornerRadius = 12;
            this.card_producto_carrito1.Descuento = 0;
            this.card_producto_carrito1.FillColor = System.Drawing.Color.White;
            this.card_producto_carrito1.ImagenProducto = ((System.Drawing.Image)(resources.GetObject("card_producto_carrito1.ImagenProducto")));
            this.card_producto_carrito1.Location = new System.Drawing.Point(28, 12);
            this.card_producto_carrito1.Name = "card_producto_carrito1";
            this.card_producto_carrito1.NombreProducto = "Nombre Producto";
            this.card_producto_carrito1.Precio = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.card_producto_carrito1.Size = new System.Drawing.Size(775, 204);
            this.card_producto_carrito1.TabIndex = 0;
            // 
            // frm_carrito_cajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1278, 911);
            this.Controls.Add(this.roundedControlBase1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_carrito_cajero";
            this.Text = "frm_carrito_cajero";
            this.Load += new System.EventHandler(this.frm_carrito_cajero_Load_1);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomCards.card_producto_carrito card_producto_carrito1;
        private CustomCards.RoundedControlBase roundedControlBase1;
    }
}