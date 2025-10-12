namespace poyecto_catedra_poo_supermecado.CustomModals
{
    partial class md_agregar_distribuidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(md_agregar_distribuidor));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            this.btn_cancelar = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.btnActualizar = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.txt_nombre = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.buttonMaxing1 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 39);
            this.label1.TabIndex = 32;
            this.label1.Text = "Agregar Distriubidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(409, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 29);
            this.label2.TabIndex = 34;
            this.label2.Text = "Nombre del Distruibidor";
            // 
            // pbProducto
            // 
            this.pbProducto.Location = new System.Drawing.Point(30, 77);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(352, 240);
            this.pbProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProducto.TabIndex = 31;
            this.pbProducto.TabStop = false;
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
            this.btn_cancelar.Location = new System.Drawing.Point(646, 282);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(157, 35);
            this.btn_cancelar.TabIndex = 39;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TextColor = System.Drawing.Color.White;
            this.btn_cancelar.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Red;
            this.btnActualizar.BackgroundColor = System.Drawing.Color.Red;
            this.btnActualizar.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnActualizar.BorderRadius = 10;
            this.btnActualizar.BorderSize = 0;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(483, 282);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(157, 35);
            this.btnActualizar.TabIndex = 38;
            this.btnActualizar.Text = "Crear";
            this.btnActualizar.TextColor = System.Drawing.Color.White;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txt_nombre
            // 
            this.txt_nombre.BackColor = System.Drawing.Color.White;
            this.txt_nombre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_nombre.BorderFocusColor = System.Drawing.Color.Plum;
            this.txt_nombre.BorderSize = 7;
            this.txt_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre.ForeColor = System.Drawing.Color.DimGray;
            this.txt_nombre.Location = new System.Drawing.Point(414, 114);
            this.txt_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nombre.Multiline = false;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Padding = new System.Windows.Forms.Padding(7);
            this.txt_nombre.PasswordChar = false;
            this.txt_nombre.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_nombre.PlaceholderText = "";
            this.txt_nombre.Size = new System.Drawing.Size(389, 35);
            this.txt_nombre.TabIndex = 35;
            this.txt_nombre.Texts = "";
            this.txt_nombre.UnderlinedStyle = true;
            // 
            // buttonMaxing1
            // 
            this.buttonMaxing1.BackColor = System.Drawing.Color.Salmon;
            this.buttonMaxing1.BackgroundColor = System.Drawing.Color.Salmon;
            this.buttonMaxing1.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing1.BorderRadius = 15;
            this.buttonMaxing1.BorderSize = 0;
            this.buttonMaxing1.FlatAppearance.BorderSize = 0;
            this.buttonMaxing1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaxing1.ForeColor = System.Drawing.Color.White;
            this.buttonMaxing1.Image = ((System.Drawing.Image)(resources.GetObject("buttonMaxing1.Image")));
            this.buttonMaxing1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMaxing1.Location = new System.Drawing.Point(57, 333);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonMaxing1.Size = new System.Drawing.Size(301, 40);
            this.buttonMaxing1.TabIndex = 33;
            this.buttonMaxing1.Text = "                 Subir Imagen";
            this.buttonMaxing1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMaxing1.TextColor = System.Drawing.Color.White;
            this.buttonMaxing1.UseVisualStyleBackColor = false;
            this.buttonMaxing1.Click += new System.EventHandler(this.buttonMaxing1_Click);
            // 
            // md_agregar_distribuidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 411);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonMaxing1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbProducto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "md_agregar_distribuidor";
            this.Text = "Modal Distriubidor";
            this.Load += new System.EventHandler(this.md_agregar_distribuidor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.Label label1;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing buttonMaxing1;
        private System.Windows.Forms.Label label2;
        private poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing txt_nombre;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing btnActualizar;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing btn_cancelar;
    }
}