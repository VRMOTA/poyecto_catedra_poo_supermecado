namespace poyecto_catedra_poo_supermecado.CustomCards
{
    partial class card_distribuidores
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
            this.buttonMaxing2 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.buttonMaxing1 = new poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing();
            this.lblDistribuidora = new System.Windows.Forms.Label();
            this.pbDistribuidora = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDistribuidora)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMaxing2
            // 
            this.buttonMaxing2.BackColor = System.Drawing.Color.Red;
            this.buttonMaxing2.BackgroundColor = System.Drawing.Color.Red;
            this.buttonMaxing2.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing2.BorderRadius = 10;
            this.buttonMaxing2.BorderSize = 0;
            this.buttonMaxing2.FlatAppearance.BorderSize = 0;
            this.buttonMaxing2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxing2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaxing2.ForeColor = System.Drawing.Color.White;
            this.buttonMaxing2.Location = new System.Drawing.Point(242, 101);
            this.buttonMaxing2.Name = "buttonMaxing2";
            this.buttonMaxing2.Size = new System.Drawing.Size(123, 30);
            this.buttonMaxing2.TabIndex = 27;
            this.buttonMaxing2.Text = "Actualizar";
            this.buttonMaxing2.TextColor = System.Drawing.Color.White;
            this.buttonMaxing2.UseVisualStyleBackColor = false;
            this.buttonMaxing2.Click += new System.EventHandler(this.buttonMaxing2_Click);
            // 
            // buttonMaxing1
            // 
            this.buttonMaxing1.BackColor = System.Drawing.Color.DimGray;
            this.buttonMaxing1.BackgroundColor = System.Drawing.Color.DimGray;
            this.buttonMaxing1.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaxing1.BorderRadius = 10;
            this.buttonMaxing1.BorderSize = 0;
            this.buttonMaxing1.FlatAppearance.BorderSize = 0;
            this.buttonMaxing1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaxing1.ForeColor = System.Drawing.Color.White;
            this.buttonMaxing1.Location = new System.Drawing.Point(242, 149);
            this.buttonMaxing1.Name = "buttonMaxing1";
            this.buttonMaxing1.Size = new System.Drawing.Size(123, 30);
            this.buttonMaxing1.TabIndex = 22;
            this.buttonMaxing1.Text = "Eliminar";
            this.buttonMaxing1.TextColor = System.Drawing.Color.White;
            this.buttonMaxing1.UseVisualStyleBackColor = false;
            this.buttonMaxing1.Click += new System.EventHandler(this.buttonMaxing1_Click);
            // 
            // lblDistribuidora
            // 
            this.lblDistribuidora.AutoSize = true;
            this.lblDistribuidora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistribuidora.Location = new System.Drawing.Point(239, 34);
            this.lblDistribuidora.Name = "lblDistribuidora";
            this.lblDistribuidora.Size = new System.Drawing.Size(131, 16);
            this.lblDistribuidora.TabIndex = 20;
            this.lblDistribuidora.Text = "Nombre Distibuidora";
            // 
            // pbDistribuidora
            // 
            this.pbDistribuidora.Image = global::poyecto_catedra_poo_supermecado.Properties.Resources.ImageDef;
            this.pbDistribuidora.Location = new System.Drawing.Point(24, 25);
            this.pbDistribuidora.Name = "pbDistribuidora";
            this.pbDistribuidora.Size = new System.Drawing.Size(197, 154);
            this.pbDistribuidora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDistribuidora.TabIndex = 17;
            this.pbDistribuidora.TabStop = false;
            // 
            // card_distribuidores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonMaxing2);
            this.Controls.Add(this.buttonMaxing1);
            this.Controls.Add(this.lblDistribuidora);
            this.Controls.Add(this.pbDistribuidora);
            this.Name = "card_distribuidores";
            this.Size = new System.Drawing.Size(412, 204);
            ((System.ComponentModel.ISupportInitialize)(this.pbDistribuidora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing buttonMaxing2;
        private poyecto_catedra_poo_supermecado.CustomControls.ButtonMaxing buttonMaxing1;
        private System.Windows.Forms.Label lblDistribuidora;
        private System.Windows.Forms.PictureBox pbDistribuidora;
    }
}
