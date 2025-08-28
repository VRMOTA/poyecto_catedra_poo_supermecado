namespace poyecto_catedra_poo_supermecado.CustomModals
{
    partial class md_consulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(md_consulta));
            this.label1 = new System.Windows.Forms.Label();
            this.textboxMaxing1 = new Catedra.CustomControls.TextboxMaxing();
            this.btn_cancelar = new Catedra.CustomControls.ButtonMaxing();
            this.btnActualizar = new Catedra.CustomControls.ButtonMaxing();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 39);
            this.label1.TabIndex = 33;
            this.label1.Text = "Consulta";
            // 
            // textboxMaxing1
            // 
            this.textboxMaxing1.BackColor = System.Drawing.Color.White;
            this.textboxMaxing1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textboxMaxing1.BorderFocusColor = System.Drawing.Color.Plum;
            this.textboxMaxing1.BorderSize = 7;
            this.textboxMaxing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxMaxing1.ForeColor = System.Drawing.Color.DimGray;
            this.textboxMaxing1.Location = new System.Drawing.Point(19, 67);
            this.textboxMaxing1.Margin = new System.Windows.Forms.Padding(4);
            this.textboxMaxing1.Multiline = true;
            this.textboxMaxing1.Name = "textboxMaxing1";
            this.textboxMaxing1.Padding = new System.Windows.Forms.Padding(7);
            this.textboxMaxing1.PasswordChar = false;
            this.textboxMaxing1.PlaceholderColor = System.Drawing.Color.Gray;
            this.textboxMaxing1.PlaceholderText = "";
            this.textboxMaxing1.Size = new System.Drawing.Size(754, 205);
            this.textboxMaxing1.TabIndex = 36;
            this.textboxMaxing1.Texts = "";
            this.textboxMaxing1.UnderlinedStyle = true;
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
            this.btn_cancelar.Location = new System.Drawing.Point(616, 308);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(157, 35);
            this.btn_cancelar.TabIndex = 41;
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
            this.btnActualizar.Location = new System.Drawing.Point(453, 308);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(157, 35);
            this.btnActualizar.TabIndex = 40;
            this.btnActualizar.Text = "Consultar";
            this.btnActualizar.TextColor = System.Drawing.Color.White;
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // md_consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.textboxMaxing1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "md_consulta";
            this.Text = "Modal Consulta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Catedra.CustomControls.TextboxMaxing textboxMaxing1;
        private Catedra.CustomControls.ButtonMaxing btn_cancelar;
        private Catedra.CustomControls.ButtonMaxing btnActualizar;
    }
}