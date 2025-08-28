namespace poyecto_catedra_poo_supermecado.CustomModals
{
    partial class md_actualizar_carrito
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
            this.txtCorreo = new Catedra.CustomControls.TextboxMaxing();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMaxing1 = new Catedra.CustomControls.ButtonMaxing();
            this.buttonMaxing2 = new Catedra.CustomControls.ButtonMaxing();
            this.SuspendLayout();
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.txtCorreo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCorreo.BorderFocusColor = System.Drawing.Color.Plum;
            this.txtCorreo.BorderSize = 7;
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCorreo.Location = new System.Drawing.Point(13, 59);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.Multiline = false;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Padding = new System.Windows.Forms.Padding(7);
            this.txtCorreo.PasswordChar = false;
            this.txtCorreo.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtCorreo.PlaceholderText = "";
            this.txtCorreo.Size = new System.Drawing.Size(541, 35);
            this.txtCorreo.TabIndex = 1;
            this.txtCorreo.Texts = "";
            this.txtCorreo.UnderlinedStyle = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Modificar cantidad";
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
            this.buttonMaxing1.Location = new System.Drawing.Point(293, 112);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Size = new System.Drawing.Size(131, 52);
            this.buttonMaxing1.TabIndex = 5;
            this.buttonMaxing1.Text = "Actualizar";
            this.buttonMaxing1.TextColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing1.UseVisualStyleBackColor = false;
            // 
            // buttonMaxing2
            // 
            this.buttonMaxing2.BackColor = System.Drawing.Color.DimGray;
            this.buttonMaxing2.BackgroundColor = System.Drawing.Color.DimGray;
            this.buttonMaxing2.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing2.BorderRadius = 15;
            this.buttonMaxing2.BorderSize = 0;
            this.buttonMaxing2.FlatAppearance.BorderSize = 0;
            this.buttonMaxing2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaxing2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing2.Location = new System.Drawing.Point(430, 112);
            this.buttonMaxing2.Name = "buttonMaxing2";
            this.buttonMaxing2.Size = new System.Drawing.Size(124, 52);
            this.buttonMaxing2.TabIndex = 8;
            this.buttonMaxing2.Text = "Cancelar";
            this.buttonMaxing2.TextColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing2.UseVisualStyleBackColor = false;
            // 
            // md_actualizar_carrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(563, 195);
            this.Controls.Add(this.buttonMaxing2);
            this.Controls.Add(this.buttonMaxing1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCorreo);
            this.Name = "md_actualizar_carrito";
            this.Text = "md_actualizar_carrito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Catedra.CustomControls.TextboxMaxing txtCorreo;
        private System.Windows.Forms.Label label1;
        private Catedra.CustomControls.ButtonMaxing buttonMaxing1;
        private Catedra.CustomControls.ButtonMaxing buttonMaxing2;
    }
}