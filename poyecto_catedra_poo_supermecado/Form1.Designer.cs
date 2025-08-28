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
            this.card_distribuidores1 = new poyecto_catedra_poo_supermecado.CustomCards.card_distribuidores();
            this.SuspendLayout();
            // 
            // card_distribuidores1
            // 
            this.card_distribuidores1.BackColor = System.Drawing.Color.Transparent;
            this.card_distribuidores1.BorderColor = System.Drawing.Color.Gray;
            this.card_distribuidores1.BorderThickness = 1;
            this.card_distribuidores1.Categoria = "Me lleva la pendejada";
            this.card_distribuidores1.CornerRadius = 12;
            this.card_distribuidores1.FillColor = System.Drawing.Color.White;
            this.card_distribuidores1.ImagenDistribuidora = global::poyecto_catedra_poo_supermecado.Properties.Resources.Rigbyyyy;
            this.card_distribuidores1.Location = new System.Drawing.Point(236, 125);
            this.card_distribuidores1.Name = "card_distribuidores1";
            this.card_distribuidores1.NombreDistribuidora = "PENEE";
            this.card_distribuidores1.Size = new System.Drawing.Size(412, 204);
            this.card_distribuidores1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.card_distribuidores1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomCards.card_distribuidores card_distribuidores1;
    }
}

