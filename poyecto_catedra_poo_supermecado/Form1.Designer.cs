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
            this.card_producto_menu1 = new poyecto_catedra_poo_supermecado.CustomCards.card_producto_menu();
            this.SuspendLayout();
            // 
            // card_producto_menu1
            // 
            this.card_producto_menu1.BackColor = System.Drawing.Color.Transparent;
            this.card_producto_menu1.BorderColor = System.Drawing.Color.Gray;
            this.card_producto_menu1.BorderThickness = 1;
            this.card_producto_menu1.CornerRadius = 12;
            this.card_producto_menu1.Descuento = 10;
            this.card_producto_menu1.FillColor = System.Drawing.Color.White;
            this.card_producto_menu1.ImagenProducto = global::poyecto_catedra_poo_supermecado.Properties.Resources.Rigbyyyy;
            this.card_producto_menu1.Location = new System.Drawing.Point(182, 72);
            this.card_producto_menu1.Name = "card_producto_menu1";
            this.card_producto_menu1.Precio = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.card_producto_menu1.Producto = "Nombre Producto";
            this.card_producto_menu1.Size = new System.Drawing.Size(241, 266);
            this.card_producto_menu1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.card_producto_menu1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomCards.card_producto_menu card_producto_menu1;
    }
}

