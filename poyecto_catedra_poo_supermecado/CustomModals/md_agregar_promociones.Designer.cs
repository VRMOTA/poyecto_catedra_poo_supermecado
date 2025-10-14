namespace poyecto_catedra_poo_supermecado.CustomModals
{
    partial class md_agregar_promociones
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_prod = new poyecto_catedra_poo_supermecado.CustomControls.RJComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cantidad_min = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_precio_prom = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_descripcion = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_fecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.dtp_fecha_final = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_activo = new poyecto_catedra_poo_supermecado.CustomControls.RJComboBox();
            this.btn_cancelar = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.btn_crear = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 39);
            this.label1.TabIndex = 34;
            this.label1.Text = "Agregar Promocion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 29);
            this.label2.TabIndex = 46;
            this.label2.Text = "Producto";
            // 
            // cmb_prod
            // 
            this.cmb_prod.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmb_prod.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmb_prod.BorderSize = 2;
            this.cmb_prod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmb_prod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmb_prod.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_prod.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmb_prod.Items.AddRange(new object[] {
            "1"});
            this.cmb_prod.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cmb_prod.ListTextColor = System.Drawing.Color.DimGray;
            this.cmb_prod.Location = new System.Drawing.Point(20, 110);
            this.cmb_prod.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_prod.MinimumSize = new System.Drawing.Size(267, 37);
            this.cmb_prod.Name = "cmb_prod";
            this.cmb_prod.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_prod.Size = new System.Drawing.Size(360, 44);
            this.cmb_prod.TabIndex = 56;
            this.cmb_prod.Texts = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 29);
            this.label3.TabIndex = 57;
            this.label3.Text = "Cantidad Minima: ";
            // 
            // txt_cantidad_min
            // 
            this.txt_cantidad_min.BackColor = System.Drawing.Color.White;
            this.txt_cantidad_min.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_cantidad_min.BorderFocusColor = System.Drawing.Color.Plum;
            this.txt_cantidad_min.BorderSize = 7;
            this.txt_cantidad_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cantidad_min.ForeColor = System.Drawing.Color.DimGray;
            this.txt_cantidad_min.Location = new System.Drawing.Point(20, 202);
            this.txt_cantidad_min.Margin = new System.Windows.Forms.Padding(5);
            this.txt_cantidad_min.Multiline = false;
            this.txt_cantidad_min.Name = "txt_cantidad_min";
            this.txt_cantidad_min.Padding = new System.Windows.Forms.Padding(9);
            this.txt_cantidad_min.PasswordChar = false;
            this.txt_cantidad_min.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_cantidad_min.PlaceholderText = "";
            this.txt_cantidad_min.Size = new System.Drawing.Size(360, 39);
            this.txt_cantidad_min.TabIndex = 58;
            this.txt_cantidad_min.Texts = "";
            this.txt_cantidad_min.UnderlinedStyle = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 256);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 29);
            this.label4.TabIndex = 59;
            this.label4.Text = "Precio Promocional : ";
            // 
            // txt_precio_prom
            // 
            this.txt_precio_prom.BackColor = System.Drawing.Color.White;
            this.txt_precio_prom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_precio_prom.BorderFocusColor = System.Drawing.Color.Plum;
            this.txt_precio_prom.BorderSize = 7;
            this.txt_precio_prom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_precio_prom.ForeColor = System.Drawing.Color.DimGray;
            this.txt_precio_prom.Location = new System.Drawing.Point(20, 290);
            this.txt_precio_prom.Margin = new System.Windows.Forms.Padding(5);
            this.txt_precio_prom.Multiline = false;
            this.txt_precio_prom.Name = "txt_precio_prom";
            this.txt_precio_prom.Padding = new System.Windows.Forms.Padding(9);
            this.txt_precio_prom.PasswordChar = false;
            this.txt_precio_prom.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_precio_prom.PlaceholderText = "";
            this.txt_precio_prom.Size = new System.Drawing.Size(360, 39);
            this.txt_precio_prom.TabIndex = 60;
            this.txt_precio_prom.Texts = "";
            this.txt_precio_prom.UnderlinedStyle = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 344);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 29);
            this.label6.TabIndex = 62;
            this.label6.Text = "Descripción";
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.BackColor = System.Drawing.Color.White;
            this.txt_descripcion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_descripcion.BorderFocusColor = System.Drawing.Color.Plum;
            this.txt_descripcion.BorderSize = 7;
            this.txt_descripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_descripcion.ForeColor = System.Drawing.Color.DimGray;
            this.txt_descripcion.Location = new System.Drawing.Point(20, 384);
            this.txt_descripcion.Margin = new System.Windows.Forms.Padding(5);
            this.txt_descripcion.Multiline = true;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Padding = new System.Windows.Forms.Padding(9);
            this.txt_descripcion.PasswordChar = false;
            this.txt_descripcion.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_descripcion.PlaceholderText = "";
            this.txt_descripcion.Size = new System.Drawing.Size(499, 156);
            this.txt_descripcion.TabIndex = 61;
            this.txt_descripcion.Texts = "";
            this.txt_descripcion.UnderlinedStyle = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(557, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 29);
            this.label5.TabIndex = 63;
            this.label5.Text = "Fecha Inicio: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(557, 146);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 29);
            this.label7.TabIndex = 65;
            this.label7.Text = "Fecha Final: ";
            // 
            // dtp_fecha_inicio
            // 
            this.dtp_fecha_inicio.Location = new System.Drawing.Point(562, 110);
            this.dtp_fecha_inicio.Name = "dtp_fecha_inicio";
            this.dtp_fecha_inicio.Size = new System.Drawing.Size(267, 22);
            this.dtp_fecha_inicio.TabIndex = 66;
            // 
            // dtp_fecha_final
            // 
            this.dtp_fecha_final.Location = new System.Drawing.Point(562, 178);
            this.dtp_fecha_final.Name = "dtp_fecha_final";
            this.dtp_fecha_final.Size = new System.Drawing.Size(267, 22);
            this.dtp_fecha_final.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(557, 212);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 29);
            this.label8.TabIndex = 68;
            this.label8.Text = "Activa";
            // 
            // cmb_activo
            // 
            this.cmb_activo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmb_activo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmb_activo.BorderSize = 2;
            this.cmb_activo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmb_activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmb_activo.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_activo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmb_activo.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cmb_activo.ListTextColor = System.Drawing.Color.DimGray;
            this.cmb_activo.Location = new System.Drawing.Point(562, 256);
            this.cmb_activo.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_activo.MinimumSize = new System.Drawing.Size(267, 37);
            this.cmb_activo.Name = "cmb_activo";
            this.cmb_activo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_activo.Size = new System.Drawing.Size(360, 44);
            this.cmb_activo.TabIndex = 69;
            this.cmb_activo.Texts = "";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.DimGray;
            this.btn_cancelar.BackgroundColor = System.Drawing.Color.DimGray;
            this.btn_cancelar.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancelar.BorderRadius = 10;
            this.btn_cancelar.BorderSize = 0;
            this.btn_cancelar.FlatAppearance.BorderSize = 0;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_cancelar.Location = new System.Drawing.Point(713, 497);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(209, 43);
            this.btn_cancelar.TabIndex = 71;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TextColor = System.Drawing.Color.White;
            this.btn_cancelar.UseVisualStyleBackColor = false;
            // 
            // btn_crear
            // 
            this.btn_crear.BackColor = System.Drawing.Color.Red;
            this.btn_crear.BackgroundColor = System.Drawing.Color.Red;
            this.btn_crear.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn_crear.BorderRadius = 10;
            this.btn_crear.BorderSize = 0;
            this.btn_crear.FlatAppearance.BorderSize = 0;
            this.btn_crear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_crear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crear.ForeColor = System.Drawing.Color.White;
            this.btn_crear.Location = new System.Drawing.Point(713, 446);
            this.btn_crear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(209, 43);
            this.btn_crear.TabIndex = 70;
            this.btn_crear.Text = "Crear";
            this.btn_crear.TextColor = System.Drawing.Color.White;
            this.btn_crear.UseVisualStyleBackColor = false;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click);
            // 
            // md_agregar_promociones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 563);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.cmb_activo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtp_fecha_final);
            this.Controls.Add(this.dtp_fecha_inicio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_descripcion);
            this.Controls.Add(this.txt_precio_prom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_cantidad_min);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_prod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "md_agregar_promociones";
            this.Text = "Modal Promociones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJComboBox cmb_prod;
        private System.Windows.Forms.Label label3;
        private CustomControls.TextboxMaxing txt_cantidad_min;
        private System.Windows.Forms.Label label4;
        private CustomControls.TextboxMaxing txt_precio_prom;
        private System.Windows.Forms.Label label6;
        private CustomControls.TextboxMaxing txt_descripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_fecha_inicio;
        private System.Windows.Forms.DateTimePicker dtp_fecha_final;
        private System.Windows.Forms.Label label8;
        private CustomControls.RJComboBox cmb_activo;
        private CustomControls.ButtonMaxing btn_cancelar;
        private CustomControls.ButtonMaxing btn_crear;
    }
}