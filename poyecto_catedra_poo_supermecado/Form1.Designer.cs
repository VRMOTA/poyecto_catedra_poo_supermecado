namespace poyecto_catedra_poo_supermecado
{
    partial class frm_clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_clientes));
            this.pln_cards = new System.Windows.Forms.Panel();
            this.panelRedondeado1 = new project_supermercado.CustomControls.PanelRedondeado();
            this.rd_fondo = new poyecto_catedra_poo_supermecado.CustomCards.RoundedControlBase();
            this.textboxMaxing1 = new Catedra.CustomControls.TextboxMaxing();
            this.buttonMaxing1 = new Catedra.CustomControls.ButtonMaxing();
            this.buttonMaxing2 = new Catedra.CustomControls.ButtonMaxing();
            this.card = new poyecto_catedra_poo_supermecado.CustomCards.card_producto_menu();
            this.pln_cards.SuspendLayout();
            this.SuspendLayout();
            // 
            // pln_cards
            // 
            this.pln_cards.Controls.Add(this.card);
            this.pln_cards.Location = new System.Drawing.Point(28, 72);
            this.pln_cards.Name = "pln_cards";
            this.pln_cards.Size = new System.Drawing.Size(1111, 813);
            this.pln_cards.TabIndex = 11;
            // 
            // panelRedondeado1
            // 
            this.panelRedondeado1.BackColor = System.Drawing.Color.White;
            this.panelRedondeado1.ColorBorde = System.Drawing.Color.White;
            this.panelRedondeado1.ForeColor = System.Drawing.Color.Black;
            this.panelRedondeado1.Location = new System.Drawing.Point(1165, 72);
            this.panelRedondeado1.Name = "panelRedondeado1";
            this.panelRedondeado1.Size = new System.Drawing.Size(376, 813);
            this.panelRedondeado1.TabIndex = 10;
            // 
            // rd_fondo
            // 
            this.rd_fondo.BackColor = System.Drawing.Color.Transparent;
            this.rd_fondo.BorderColor = System.Drawing.Color.Gray;
            this.rd_fondo.BorderThickness = 1;
            this.rd_fondo.CornerRadius = 12;
            this.rd_fondo.FillColor = System.Drawing.Color.White;
            this.rd_fondo.Location = new System.Drawing.Point(12, 12);
            this.rd_fondo.Name = "rd_fondo";
            this.rd_fondo.Size = new System.Drawing.Size(1540, 887);
            this.rd_fondo.TabIndex = 9;
            // 
            // textboxMaxing1
            // 
            this.textboxMaxing1.BackColor = System.Drawing.Color.White;
            this.textboxMaxing1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textboxMaxing1.BorderFocusColor = System.Drawing.Color.Plum;
            this.textboxMaxing1.BorderSize = 7;
            this.textboxMaxing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxMaxing1.ForeColor = System.Drawing.Color.DimGray;
            this.textboxMaxing1.Location = new System.Drawing.Point(28, 30);
            this.textboxMaxing1.Margin = new System.Windows.Forms.Padding(4);
            this.textboxMaxing1.Multiline = false;
            this.textboxMaxing1.Name = "textboxMaxing1";
            this.textboxMaxing1.Padding = new System.Windows.Forms.Padding(7);
            this.textboxMaxing1.PasswordChar = false;
            this.textboxMaxing1.PlaceholderColor = System.Drawing.Color.Gray;
            this.textboxMaxing1.PlaceholderText = "Buscar";
            this.textboxMaxing1.Size = new System.Drawing.Size(1079, 35);
            this.textboxMaxing1.TabIndex = 13;
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
            this.buttonMaxing1.Location = new System.Drawing.Point(1114, 29);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Size = new System.Drawing.Size(167, 36);
            this.buttonMaxing1.TabIndex = 12;
            this.buttonMaxing1.TextColor = System.Drawing.Color.White;
            this.buttonMaxing1.UseVisualStyleBackColor = false;
            // 
            // buttonMaxing2
            // 
            this.buttonMaxing2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMaxing2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMaxing2.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing2.BorderRadius = 15;
            this.buttonMaxing2.BorderSize = 0;
            this.buttonMaxing2.FlatAppearance.BorderSize = 0;
            this.buttonMaxing2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaxing2.ForeColor = System.Drawing.Color.White;
            this.buttonMaxing2.Image = ((System.Drawing.Image)(resources.GetObject("buttonMaxing2.Image")));
            this.buttonMaxing2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMaxing2.Location = new System.Drawing.Point(1287, 29);
            this.buttonMaxing2.Name = "buttonMaxing2";
            this.buttonMaxing2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonMaxing2.Size = new System.Drawing.Size(254, 36);
            this.buttonMaxing2.TabIndex = 14;
            this.buttonMaxing2.Text = "           Login";
            this.buttonMaxing2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMaxing2.TextColor = System.Drawing.Color.White;
            this.buttonMaxing2.UseVisualStyleBackColor = false;
            // 
            // card
            // 
            this.card.BackColor = System.Drawing.Color.Transparent;
            this.card.BorderColor = System.Drawing.Color.Gray;
            this.card.BorderThickness = 1;
            this.card.CornerRadius = 12;
            this.card.Descuento = 0;
            this.card.FillColor = System.Drawing.Color.White;
            this.card.IDProducto = 0;
            this.card.ImagenProducto = ((System.Drawing.Image)(resources.GetObject("card.ImagenProducto")));
            this.card.Location = new System.Drawing.Point(3, 3);
            this.card.Name = "card";
            this.card.Precio = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.card.Producto = "Nombre Producto";
            this.card.Size = new System.Drawing.Size(241, 266);
            this.card.TabIndex = 0;
            this.card.Load += new System.EventHandler(this.card_Load);
            // 
            // frm_clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 911);
            this.Controls.Add(this.buttonMaxing2);
            this.Controls.Add(this.textboxMaxing1);
            this.Controls.Add(this.buttonMaxing1);
            this.Controls.Add(this.pln_cards);
            this.Controls.Add(this.panelRedondeado1);
            this.Controls.Add(this.rd_fondo);
            this.Name = "frm_clientes";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_clientes_Load);
            this.pln_cards.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pln_cards;
        private project_supermercado.CustomControls.PanelRedondeado panelRedondeado1;
        private CustomCards.RoundedControlBase rd_fondo;
        private Catedra.CustomControls.TextboxMaxing textboxMaxing1;
        private Catedra.CustomControls.ButtonMaxing buttonMaxing1;
        private Catedra.CustomControls.ButtonMaxing buttonMaxing2;
        private CustomCards.card_producto_menu card;
    }
}

