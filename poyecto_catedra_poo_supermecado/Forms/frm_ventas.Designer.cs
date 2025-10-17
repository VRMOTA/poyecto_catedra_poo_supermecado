namespace poyecto_catedra_poo_supermecado.Forms
{
    partial class frm_ventas
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
            this.cmb_cajero = new poyecto_catedra_poo_supermecado.CustomControls.RJComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nombre = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_limpiar = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.btnBuscar = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 39);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ventas";
            // 
            // cmb_cajero
            // 
            this.cmb_cajero.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmb_cajero.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmb_cajero.BorderSize = 2;
            this.cmb_cajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmb_cajero.EnableTextInput = true;
            this.cmb_cajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmb_cajero.ForeColor = System.Drawing.Color.DimGray;
            this.cmb_cajero.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmb_cajero.Items.AddRange(new object[] {
            "1"});
            this.cmb_cajero.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cmb_cajero.ListTextColor = System.Drawing.Color.DimGray;
            this.cmb_cajero.Location = new System.Drawing.Point(27, 136);
            this.cmb_cajero.MinimumSize = new System.Drawing.Size(200, 30);
            this.cmb_cajero.Name = "cmb_cajero";
            this.cmb_cajero.Padding = new System.Windows.Forms.Padding(2);
            this.cmb_cajero.Size = new System.Drawing.Size(390, 36);
            this.cmb_cajero.TabIndex = 50;
            this.cmb_cajero.Texts = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 29);
            this.label2.TabIndex = 51;
            this.label2.Text = "Cajero ";
            // 
            // txt_nombre
            // 
            this.txt_nombre.BackColor = System.Drawing.Color.White;
            this.txt_nombre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_nombre.BorderFocusColor = System.Drawing.Color.Plum;
            this.txt_nombre.BorderSize = 7;
            this.txt_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre.ForeColor = System.Drawing.Color.DimGray;
            this.txt_nombre.Location = new System.Drawing.Point(459, 137);
            this.txt_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nombre.Multiline = false;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Padding = new System.Windows.Forms.Padding(7);
            this.txt_nombre.PasswordChar = false;
            this.txt_nombre.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_nombre.PlaceholderText = "";
            this.txt_nombre.Size = new System.Drawing.Size(389, 35);
            this.txt_nombre.TabIndex = 52;
            this.txt_nombre.Texts = "";
            this.txt_nombre.UnderlinedStyle = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(454, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 29);
            this.label3.TabIndex = 53;
            this.label3.Text = "Correlativo de la Venta ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 252);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1196, 647);
            this.dataGridView1.TabIndex = 54;
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.BackColor = System.Drawing.Color.DimGray;
            this.btn_limpiar.BackgroundColor = System.Drawing.Color.DimGray;
            this.btn_limpiar.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn_limpiar.BorderRadius = 10;
            this.btn_limpiar.BorderSize = 0;
            this.btn_limpiar.FlatAppearance.BorderSize = 0;
            this.btn_limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_limpiar.ForeColor = System.Drawing.Color.White;
            this.btn_limpiar.Location = new System.Drawing.Point(1066, 211);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(157, 35);
            this.btn_limpiar.TabIndex = 56;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.TextColor = System.Drawing.Color.White;
            this.btn_limpiar.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Red;
            this.btnBuscar.BackgroundColor = System.Drawing.Color.Red;
            this.btnBuscar.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscar.BorderRadius = 10;
            this.btnBuscar.BorderSize = 0;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(903, 211);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(157, 35);
            this.btnBuscar.TabIndex = 55;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextColor = System.Drawing.Color.White;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // frm_ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 911);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_cajero);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_ventas";
            this.Text = "frm_ventas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CustomControls.RJComboBox cmb_cajero;
        private System.Windows.Forms.Label label2;
        private CustomControls.TextboxMaxing txt_nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CustomControls.ButtonMaxing btn_limpiar;
        private CustomControls.ButtonMaxing btnBuscar;
    }
}