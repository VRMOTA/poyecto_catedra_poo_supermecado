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
            this.card_producto_carrito1 = new poyecto_catedra_poo_supermecado.CustomCards.card_producto_carrito();
            this.roundedControlBase1 = new poyecto_catedra_poo_supermecado.CustomCards.RoundedControlBase();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCorreo = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.buttonMaxing1 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(898, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cantidad de Productos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1181, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "10";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(898, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total a Pagar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1146, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "$50.40";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(898, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre del Cliente";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtCorreo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCorreo.BorderFocusColor = System.Drawing.Color.Plum;
            this.txtCorreo.BorderSize = 7;
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCorreo.Location = new System.Drawing.Point(902, 193);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.Multiline = false;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Padding = new System.Windows.Forms.Padding(7);
            this.txtCorreo.PasswordChar = false;
            this.txtCorreo.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtCorreo.PlaceholderText = "";
            this.txtCorreo.Size = new System.Drawing.Size(308, 35);
            this.txtCorreo.TabIndex = 8;
            this.txtCorreo.Texts = "";
            this.txtCorreo.UnderlinedStyle = true;
            // 
            // buttonMaxing1
            // 
            this.buttonMaxing1.BackColor = System.Drawing.Color.Red;
            this.buttonMaxing1.BackgroundColor = System.Drawing.Color.Red;
            this.buttonMaxing1.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing1.BorderRadius = 15;
            this.buttonMaxing1.BorderSize = 0;
            this.buttonMaxing1.FlatAppearance.BorderSize = 0;
            this.buttonMaxing1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaxing1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing1.Location = new System.Drawing.Point(902, 822);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Size = new System.Drawing.Size(308, 52);
            this.buttonMaxing1.TabIndex = 9;
            this.buttonMaxing1.Text = "Finalizar Pedido";
            this.buttonMaxing1.TextColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing1.UseVisualStyleBackColor = false;
            // 
            // frm_carrito_cajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1278, 911);
            this.Controls.Add(this.buttonMaxing1);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedControlBase1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_carrito_cajero";
            this.Text = "frm_carrito_cajero";
            this.Load += new System.EventHandler(this.frm_carrito_cajero_Load_1);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomCards.card_producto_carrito card_producto_carrito1;
        private CustomCards.RoundedControlBase roundedControlBase1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing txtCorreo;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing buttonMaxing1;
    }
}