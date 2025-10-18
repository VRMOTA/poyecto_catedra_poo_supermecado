namespace poyecto_catedra_poo_supermecado.CustomModals
{
    partial class md_agregar_categoria
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
            this.btn_cancelar = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.btnActualizar = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.txt_nombre = new poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btn_cancelar.Location = new System.Drawing.Point(457, 210);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(157, 35);
            this.btn_cancelar.TabIndex = 46;
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
            this.btnActualizar.Location = new System.Drawing.Point(294, 210);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(157, 35);
            this.btnActualizar.TabIndex = 45;
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
            this.txt_nombre.Location = new System.Drawing.Point(17, 120);
            this.txt_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nombre.Multiline = false;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Padding = new System.Windows.Forms.Padding(7);
            this.txt_nombre.PasswordChar = false;
            this.txt_nombre.PlaceholderColor = System.Drawing.Color.Gray;
            this.txt_nombre.PlaceholderText = "";
            this.txt_nombre.Size = new System.Drawing.Size(596, 35);
            this.txt_nombre.TabIndex = 44;
            this.txt_nombre.Texts = "";
            this.txt_nombre.UnderlinedStyle = true;
            this.txt_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nombre_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 29);
            this.label2.TabIndex = 43;
            this.label2.Text = "Nombre de la  Categoria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 39);
            this.label1.TabIndex = 41;
            this.label1.Text = "Agregar Cateogoria";
            // 
            // md_agregar_categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 268);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "md_agregar_categoria";
            this.Text = "Agregar Categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing btn_cancelar;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing btnActualizar;
        private poyecto_catedra_poo_supermecado.CustomControls.TextboxMaxing txt_nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}