﻿namespace poyecto_catedra_poo_supermecado.Forms
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
            this.card = new poyecto_catedra_poo_supermecado.CustomCards.card_producto_menu();
            this.rd_fondo = new poyecto_catedra_poo_supermecado.CustomCards.RoundedControlBase();
            this.txt_buscar = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.buttonMaxing2 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.panelRedondeado1 = new poyecto_catedra_poo_supermecado.CustomControls.PanelRedondeado();
            this.lbdescriccion = new System.Windows.Forms.Label();
            this.lbstock = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrecioDescuento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            this.pln_cards.SuspendLayout();
            this.panelRedondeado1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
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
            // card
            // 
            this.card.Activo = true;
            this.card.BackColor = System.Drawing.Color.Transparent;
            this.card.BorderColor = System.Drawing.Color.Gray;
            this.card.BorderThickness = 1;
            this.card.Categoria = "";
            this.card.CornerRadius = 12;
            this.card.Descripcion = "";
            this.card.Descuento = 0;
            this.card.Distribuidor = "";
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
            this.card.Stock = 0;
            this.card.TabIndex = 0;
            this.card.Load += new System.EventHandler(this.card_Load);
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
            // txt_buscar
            // 
            this.txt_buscar.BackColor = System.Drawing.Color.White;
            this.txt_buscar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_buscar.BorderFocusColor = System.Drawing.Color.Plum;
            this.txt_buscar.BorderSize = 7;
            this.txt_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscar.ForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.Location = new System.Drawing.Point(31, 30);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Multiline = false;
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Padding = new System.Windows.Forms.Padding(7);
            this.txt_buscar.PasswordChar = false;
            this.txt_buscar.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_buscar.PlaceholderText = "Buscar";
            this.txt_buscar.Size = new System.Drawing.Size(1249, 35);
            this.txt_buscar.TabIndex = 13;
            this.txt_buscar.Texts = "";
            this.txt_buscar.UnderlinedStyle = true;
            this.txt_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_buscar_KeyPress);
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
            this.buttonMaxing2.Click += new System.EventHandler(this.buttonMaxing2_Click);
            // 
            // panelRedondeado1
            // 
            this.panelRedondeado1.BackColor = System.Drawing.Color.White;
            this.panelRedondeado1.ColorBorde = System.Drawing.Color.White;
            this.panelRedondeado1.Controls.Add(this.lbdescriccion);
            this.panelRedondeado1.Controls.Add(this.lbstock);
            this.panelRedondeado1.Controls.Add(this.label2);
            this.panelRedondeado1.Controls.Add(this.lblPrecioDescuento);
            this.panelRedondeado1.Controls.Add(this.label1);
            this.panelRedondeado1.Controls.Add(this.lblPrecio);
            this.panelRedondeado1.Controls.Add(this.lblProducto);
            this.panelRedondeado1.Controls.Add(this.pbProducto);
            this.panelRedondeado1.ForeColor = System.Drawing.Color.Black;
            this.panelRedondeado1.Location = new System.Drawing.Point(1165, 72);
            this.panelRedondeado1.Name = "panelRedondeado1";
            this.panelRedondeado1.Size = new System.Drawing.Size(376, 813);
            this.panelRedondeado1.TabIndex = 10;
            // 
            // lbdescriccion
            // 
            this.lbdescriccion.AutoSize = true;
            this.lbdescriccion.BackColor = System.Drawing.Color.White;
            this.lbdescriccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdescriccion.Location = new System.Drawing.Point(21, 378);
            this.lbdescriccion.Name = "lbdescriccion";
            this.lbdescriccion.Size = new System.Drawing.Size(110, 24);
            this.lbdescriccion.TabIndex = 21;
            this.lbdescriccion.Text = "Descripcion";
            // 
            // lbstock
            // 
            this.lbstock.AutoSize = true;
            this.lbstock.BackColor = System.Drawing.Color.White;
            this.lbstock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstock.Location = new System.Drawing.Point(342, 334);
            this.lbstock.Name = "lbstock";
            this.lbstock.Size = new System.Drawing.Size(20, 24);
            this.lbstock.TabIndex = 20;
            this.lbstock.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "Stock";
            // 
            // lblPrecioDescuento
            // 
            this.lblPrecioDescuento.AccessibleDescription = " ";
            this.lblPrecioDescuento.AutoSize = true;
            this.lblPrecioDescuento.BackColor = System.Drawing.Color.White;
            this.lblPrecioDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioDescuento.ForeColor = System.Drawing.Color.Red;
            this.lblPrecioDescuento.Location = new System.Drawing.Point(307, 286);
            this.lblPrecioDescuento.Name = "lblPrecioDescuento";
            this.lblPrecioDescuento.Size = new System.Drawing.Size(55, 24);
            this.lblPrecioDescuento.TabIndex = 18;
            this.lblPrecioDescuento.Text = "$0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(21, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Descuento:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BackColor = System.Drawing.Color.White;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(307, 243);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(55, 24);
            this.lblPrecio.TabIndex = 16;
            this.lblPrecio.Text = "$0.00";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.BackColor = System.Drawing.Color.White;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(21, 243);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(160, 24);
            this.lblProducto.TabIndex = 15;
            this.lblProducto.Text = "Nombre Producto";
            // 
            // pbProducto
            // 
            this.pbProducto.Location = new System.Drawing.Point(25, 17);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(337, 213);
            this.pbProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProducto.TabIndex = 14;
            this.pbProducto.TabStop = false;
            // 
            // frm_clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 911);
            this.Controls.Add(this.buttonMaxing2);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.pln_cards);
            this.Controls.Add(this.panelRedondeado1);
            this.Controls.Add(this.rd_fondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_clientes";
            this.Text = "Clientes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_clientes_FormClosed);
            this.Load += new System.EventHandler(this.frm_clientes_Load);
            this.pln_cards.ResumeLayout(false);
            this.panelRedondeado1.ResumeLayout(false);
            this.panelRedondeado1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pln_cards;
        private CustomCards.RoundedControlBase rd_fondo;
        private poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing txt_buscar;
        private CustomCards.card_producto_menu card;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing buttonMaxing2;
        private poyecto_catedra_poo_supermecado.CustomControls.PanelRedondeado panelRedondeado1;
        private System.Windows.Forms.Label lbdescriccion;
        private System.Windows.Forms.Label lbstock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrecioDescuento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.PictureBox pbProducto;
    }
}

