namespace poyecto_catedra_poo_supermecado.CustomCards
{
    partial class card_producto_menu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrecioDescuento = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.btnVisualizar = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(22, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descuento:";
            // 
            // lblPrecioDescuento
            // 
            this.lblPrecioDescuento.AccessibleDescription = " ";
            this.lblPrecioDescuento.AutoSize = true;
            this.lblPrecioDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioDescuento.ForeColor = System.Drawing.Color.Red;
            this.lblPrecioDescuento.Location = new System.Drawing.Point(175, 182);
            this.lblPrecioDescuento.Name = "lblPrecioDescuento";
            this.lblPrecioDescuento.Size = new System.Drawing.Size(38, 16);
            this.lblPrecioDescuento.TabIndex = 2;
            this.lblPrecioDescuento.Text = "$0.00";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(175, 152);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(38, 16);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "$0.00";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(22, 152);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(113, 16);
            this.lblProducto.TabIndex = 3;
            this.lblProducto.Text = "Nombre Producto";
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.BackColor = System.Drawing.Color.Red;
            this.btnVisualizar.BackgroundColor = System.Drawing.Color.Red;
            this.btnVisualizar.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnVisualizar.BorderRadius = 15;
            this.btnVisualizar.BorderSize = 0;
            this.btnVisualizar.FlatAppearance.BorderSize = 0;
            this.btnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.ForeColor = System.Drawing.Color.White;
            this.btnVisualizar.Location = new System.Drawing.Point(25, 215);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(188, 30);
            this.btnVisualizar.TabIndex = 5;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.TextColor = System.Drawing.Color.White;
            this.btnVisualizar.UseVisualStyleBackColor = false;
            // 
            // pbProducto
            // 
            this.pbProducto.Image = global::poyecto_catedra_poo_supermecado.Properties.Resources.ImageDef;
            this.pbProducto.Location = new System.Drawing.Point(25, 18);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(188, 119);
            this.pbProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProducto.TabIndex = 0;
            this.pbProducto.TabStop = false;
            // 
            // card_producto_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblPrecioDescuento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbProducto);
            this.Name = "card_producto_menu";
            this.Size = new System.Drawing.Size(241, 266);
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPrecioDescuento;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblProducto;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing btnVisualizar;
    }
}
