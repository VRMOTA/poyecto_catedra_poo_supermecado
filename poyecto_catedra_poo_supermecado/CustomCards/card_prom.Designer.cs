namespace poyecto_catedra_poo_supermecado.CustomCards
{
    partial class card_prom
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.roundedControlBase1 = new poyecto_catedra_poo_supermecado.CustomCards.RoundedControlBase();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblDistribuidor = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // roundedControlBase1
            // 
            this.roundedControlBase1.BackColor = System.Drawing.Color.Transparent;
            this.roundedControlBase1.BorderColor = System.Drawing.Color.Gray;
            this.roundedControlBase1.BorderThickness = 1;
            this.roundedControlBase1.CornerRadius = 12;
            this.roundedControlBase1.FillColor = System.Drawing.Color.White;
            this.roundedControlBase1.Location = new System.Drawing.Point(0, 0);
            this.roundedControlBase1.Name = "roundedControlBase1";
            this.roundedControlBase1.Size = new System.Drawing.Size(507, 150);
            this.roundedControlBase1.TabIndex = 0;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(18, 78);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(470, 56);
            this.lblDescripcion.TabIndex = 36;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblDistribuidor
            // 
            this.lblDistribuidor.AutoSize = true;
            this.lblDistribuidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistribuidor.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblDistribuidor.Location = new System.Drawing.Point(18, 43);
            this.lblDistribuidor.Name = "lblDistribuidor";
            this.lblDistribuidor.Size = new System.Drawing.Size(95, 18);
            this.lblDistribuidor.TabIndex = 35;
            this.lblDistribuidor.Text = "Distribuidor";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(18, 16);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(142, 18);
            this.lblProducto.TabIndex = 34;
            this.lblProducto.Text = "Nombre Producto";
            // 
            // card_prom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblDistribuidor);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.roundedControlBase1);
            this.Name = "card_prom";
            this.Size = new System.Drawing.Size(507, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedControlBase roundedControlBase1;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblDistribuidor;
        private System.Windows.Forms.Label lblProducto;
    }
}
