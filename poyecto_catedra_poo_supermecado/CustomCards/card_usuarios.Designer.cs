namespace poyecto_catedra_poo_supermecado.CustomCards
{
    partial class card_usuarios
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnActualizar = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.btnEliminar = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.lblCorreoUsuario = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnActualizar.Location = new System.Drawing.Point(347, 22);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(123, 30);
            this.btnActualizar.TabIndex = 33;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextColor = System.Drawing.Color.White;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DimGray;
            this.btnEliminar.BackgroundColor = System.Drawing.Color.DimGray;
            this.btnEliminar.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnEliminar.BorderRadius = 10;
            this.btnEliminar.BorderSize = 0;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(347, 58);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(123, 30);
            this.btnEliminar.TabIndex = 32;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextColor = System.Drawing.Color.White;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // lblCorreoUsuario
            // 
            this.lblCorreoUsuario.AutoSize = true;
            this.lblCorreoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreoUsuario.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCorreoUsuario.Location = new System.Drawing.Point(33, 58);
            this.lblCorreoUsuario.Name = "lblCorreoUsuario";
            this.lblCorreoUsuario.Size = new System.Drawing.Size(98, 16);
            this.lblCorreoUsuario.TabIndex = 31;
            this.lblCorreoUsuario.Text = "Correo Usuario";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(33, 30);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(120, 16);
            this.lblNombreUsuario.TabIndex = 30;
            this.lblNombreUsuario.Text = "Nombre Usuario";
            // 
            // card_usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblCorreoUsuario);
            this.Controls.Add(this.lblNombreUsuario);
            this.Name = "card_usuarios";
            this.Size = new System.Drawing.Size(495, 107);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing btnActualizar;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing btnEliminar;
        private System.Windows.Forms.Label lblCorreoUsuario;
        private System.Windows.Forms.Label lblNombreUsuario;
    }
}
