namespace poyecto_catedra_poo_supermecado
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.card_producto_carrito1 = new poyecto_catedra_poo_supermecado.CustomCards.card_producto_carrito();
            this.SuspendLayout();
            // 
            // card_producto_carrito1
            // 
            this.card_producto_carrito1.BackColor = System.Drawing.Color.Transparent;
            this.card_producto_carrito1.BorderColor = System.Drawing.Color.Gray;
            this.card_producto_carrito1.BorderThickness = 1;
            this.card_producto_carrito1.Cantidad = 2;
            this.card_producto_carrito1.CornerRadius = 12;
            this.card_producto_carrito1.Descuento = 10;
            this.card_producto_carrito1.FillColor = System.Drawing.Color.White;
            this.card_producto_carrito1.ImagenProducto = global::poyecto_catedra_poo_supermecado.Properties.Resources.Rigbyyyy;
            this.card_producto_carrito1.Location = new System.Drawing.Point(13, 117);
            this.card_producto_carrito1.Name = "card_producto_carrito1";
            this.card_producto_carrito1.NombreProducto = "pene";
            this.card_producto_carrito1.Precio = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.card_producto_carrito1.Size = new System.Drawing.Size(775, 204);
            this.card_producto_carrito1.TabIndex = 0;
            this.card_producto_carrito1.Load += new System.EventHandler(this.card_producto_carrito1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.card_producto_carrito1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomCards.card_producto_carrito card_producto_carrito1;
    }
}

