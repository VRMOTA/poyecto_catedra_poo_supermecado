namespace poyecto_catedra_poo_supermecado.Forms
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
            this.card_producto_menu1 = new poyecto_catedra_poo_supermecado.CustomCards.card_producto_menu();
            this.roundedControlBase1 = new poyecto_catedra_poo_supermecado.CustomCards.RoundedControlBase();
            this.txt_buscar = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.buttonMaxing1 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbstock = new System.Windows.Forms.Label();
            this.lbdescriccion = new System.Windows.Forms.Label();
            this.buttonMaxing2 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.textboxMaxing2 = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.lbPromo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
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
            // card_producto_menu1
            // 
            this.card_producto_menu1.BackColor = System.Drawing.Color.Transparent;
            this.card_producto_menu1.BorderColor = System.Drawing.Color.Gray;
            this.card_producto_menu1.BorderThickness = 1;
            this.card_producto_menu1.CornerRadius = 12;
            this.card_producto_menu1.Descuento = 0;
            this.card_producto_menu1.FillColor = System.Drawing.Color.White;
            this.card_producto_menu1.IDProducto = 0;
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
            // roundedControlBase1
            // 
            this.roundedControlBase1.BackColor = System.Drawing.Color.Transparent;
            this.roundedControlBase1.BorderColor = System.Drawing.Color.White;
            this.roundedControlBase1.BorderThickness = 1;
            this.roundedControlBase1.CornerRadius = 12;
            this.roundedControlBase1.FillColor = System.Drawing.Color.White;
            this.roundedControlBase1.Location = new System.Drawing.Point(1000, 55);
            this.roundedControlBase1.Name = "roundedControlBase1";
            this.roundedControlBase1.Size = new System.Drawing.Size(266, 844);
            this.roundedControlBase1.TabIndex = 3;
            this.roundedControlBase1.Load += new System.EventHandler(this.roundedControlBase1_Load);
            // 
            // txt_buscar
            // 
            this.txt_buscar.BackColor = System.Drawing.Color.White;
            this.txt_buscar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_buscar.BorderFocusColor = System.Drawing.Color.Plum;
            this.txt_buscar.BorderSize = 7;
            this.txt_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscar.ForeColor = System.Drawing.Color.DimGray;
            this.txt_buscar.Location = new System.Drawing.Point(13, 13);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_buscar.Multiline = false;
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Padding = new System.Windows.Forms.Padding(7);
            this.txt_buscar.PasswordChar = false;
            this.txt_buscar.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_buscar.PlaceholderText = "Buscar";
            this.txt_buscar.Size = new System.Drawing.Size(1079, 35);
            this.txt_buscar.TabIndex = 2;
            this.txt_buscar.Texts = "";
            this.txt_buscar.UnderlinedStyle = true;
            this.txt_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_buscar_KeyPress);
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
            // pbProducto
            // 
            this.pbProducto.Location = new System.Drawing.Point(1024, 89);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(205, 125);
            this.pbProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProducto.TabIndex = 5;
            this.pbProducto.TabStop = false;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.BackColor = System.Drawing.Color.White;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(1021, 241);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(113, 16);
            this.lblProducto.TabIndex = 6;
            this.lblProducto.Text = "Nombre Producto";
            this.lblProducto.Click += new System.EventHandler(this.lblProducto_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BackColor = System.Drawing.Color.White;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(1191, 241);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(38, 16);
            this.lblPrecio.TabIndex = 7;
            this.lblPrecio.Text = "$0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1021, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Stock";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // lbstock
            // 
            this.lbstock.AutoSize = true;
            this.lbstock.BackColor = System.Drawing.Color.White;
            this.lbstock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstock.Location = new System.Drawing.Point(1215, 308);
            this.lbstock.Name = "lbstock";
            this.lbstock.Size = new System.Drawing.Size(14, 16);
            this.lbstock.TabIndex = 11;
            this.lbstock.Text = "0";
            // 
            // lbdescriccion
            // 
            this.lbdescriccion.AutoSize = true;
            this.lbdescriccion.BackColor = System.Drawing.Color.White;
            this.lbdescriccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdescriccion.Location = new System.Drawing.Point(1021, 377);
            this.lbdescriccion.MaximumSize = new System.Drawing.Size(250, 250);
            this.lbdescriccion.Name = "lbdescriccion";
            this.lbdescriccion.Size = new System.Drawing.Size(79, 16);
            this.lbdescriccion.TabIndex = 12;
            this.lbdescriccion.Text = "Descripcion";
            // 
            // buttonMaxing2
            // 
            this.buttonMaxing2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMaxing2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMaxing2.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing2.BorderRadius = 8;
            this.buttonMaxing2.BorderSize = 0;
            this.buttonMaxing2.FlatAppearance.BorderSize = 0;
            this.buttonMaxing2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaxing2.ForeColor = System.Drawing.Color.White;
            this.buttonMaxing2.Location = new System.Drawing.Point(1012, 857);
            this.buttonMaxing2.Name = "buttonMaxing2";
            this.buttonMaxing2.Size = new System.Drawing.Size(242, 31);
            this.buttonMaxing2.TabIndex = 13;
            this.buttonMaxing2.Text = "Agregar";
            this.buttonMaxing2.TextColor = System.Drawing.Color.White;
            this.buttonMaxing2.UseVisualStyleBackColor = false;
            this.buttonMaxing2.Click += new System.EventHandler(this.buttonMaxing2_Click);
            // 
            // textboxMaxing2
            // 
            this.textboxMaxing2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.textboxMaxing2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textboxMaxing2.BorderFocusColor = System.Drawing.Color.Plum;
            this.textboxMaxing2.BorderSize = 7;
            this.textboxMaxing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxMaxing2.ForeColor = System.Drawing.Color.DimGray;
            this.textboxMaxing2.Location = new System.Drawing.Point(1012, 814);
            this.textboxMaxing2.Margin = new System.Windows.Forms.Padding(4);
            this.textboxMaxing2.Multiline = false;
            this.textboxMaxing2.Name = "textboxMaxing2";
            this.textboxMaxing2.Padding = new System.Windows.Forms.Padding(7);
            this.textboxMaxing2.PasswordChar = false;
            this.textboxMaxing2.PlaceholderColor = System.Drawing.Color.Gray;
            this.textboxMaxing2.PlaceholderText = "Cantidad";
            this.textboxMaxing2.Size = new System.Drawing.Size(242, 35);
            this.textboxMaxing2.TabIndex = 14;
            this.textboxMaxing2.Texts = "";
            this.textboxMaxing2.UnderlinedStyle = true;
            // 
            // lbPromo
            // 
            this.lbPromo.AutoSize = true;
            this.lbPromo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbPromo.Location = new System.Drawing.Point(1021, 681);
            this.lbPromo.MaximumSize = new System.Drawing.Size(250, 250);
            this.lbPromo.Name = "lbPromo";
            this.lbPromo.Size = new System.Drawing.Size(13, 13);
            this.lbPromo.TabIndex = 15;
            this.lbPromo.Text = "--";
            this.lbPromo.Click += new System.EventHandler(this.lbPromo_Click);
            // 
            // frm_catalogo_cajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1278, 911);
            this.Controls.Add(this.lbPromo);
            this.Controls.Add(this.textboxMaxing2);
            this.Controls.Add(this.buttonMaxing2);
            this.Controls.Add(this.lbdescriccion);
            this.Controls.Add(this.lbstock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.pbProducto);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.roundedControlBase1);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.buttonMaxing1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_catalogo_cajero";
            this.Text = "frm_catalogo_cajero";
            this.Load += new System.EventHandler(this.frm_catalogo_cajero_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing buttonMaxing1;
        private poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing txt_buscar;
        private CustomCards.RoundedControlBase roundedControlBase1;
        private System.Windows.Forms.Panel panel1;
        private CustomCards.card_producto_menu card_producto_menu1;
        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbstock;
        private System.Windows.Forms.Label lbdescriccion;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing buttonMaxing2;
        private poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing textboxMaxing2;
        private System.Windows.Forms.Label lbPromo;
    }
}