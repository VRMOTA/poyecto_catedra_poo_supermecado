namespace poyecto_catedra_poo_supermecado
{
    partial class frm_dashboard_cajero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_dashboard_cajero));
            this.navegador = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_menu = new System.Windows.Forms.Panel();
            this.btn_menu = new System.Windows.Forms.Button();
            this.pnl_catalogo = new System.Windows.Forms.Panel();
            this.btn_categoria = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_carrito = new System.Windows.Forms.Button();
            this.pnl_consultas = new System.Windows.Forms.Panel();
            this.btn_consultas = new System.Windows.Forms.Button();
            this.pnl_salir = new System.Windows.Forms.Panel();
            this.btn_salir = new System.Windows.Forms.Button();
            this.panel_control = new System.Windows.Forms.Panel();
            this.navegador.SuspendLayout();
            this.pnl_menu.SuspendLayout();
            this.pnl_catalogo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_consultas.SuspendLayout();
            this.pnl_salir.SuspendLayout();
            this.SuspendLayout();
            // 
            // navegador
            // 
            this.navegador.Controls.Add(this.pnl_menu);
            this.navegador.Controls.Add(this.pnl_catalogo);
            this.navegador.Controls.Add(this.panel1);
            this.navegador.Controls.Add(this.pnl_consultas);
            this.navegador.Controls.Add(this.pnl_salir);
            this.navegador.Dock = System.Windows.Forms.DockStyle.Left;
            this.navegador.Location = new System.Drawing.Point(0, 0);
            this.navegador.Name = "navegador";
            this.navegador.Size = new System.Drawing.Size(289, 911);
            this.navegador.TabIndex = 1;
            // 
            // pnl_menu
            // 
            this.pnl_menu.Controls.Add(this.btn_menu);
            this.pnl_menu.Location = new System.Drawing.Point(3, 30);
            this.pnl_menu.Margin = new System.Windows.Forms.Padding(3, 30, 3, 30);
            this.pnl_menu.Name = "pnl_menu";
            this.pnl_menu.Size = new System.Drawing.Size(286, 60);
            this.pnl_menu.TabIndex = 1;
            // 
            // btn_menu
            // 
            this.btn_menu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_menu.ForeColor = System.Drawing.Color.White;
            this.btn_menu.Image = ((System.Drawing.Image)(resources.GetObject("btn_menu.Image")));
            this.btn_menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_menu.Location = new System.Drawing.Point(-5, -19);
            this.btn_menu.Name = "btn_menu";
            this.btn_menu.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_menu.Size = new System.Drawing.Size(331, 101);
            this.btn_menu.TabIndex = 2;
            this.btn_menu.Text = "        Menú";
            this.btn_menu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_menu.UseVisualStyleBackColor = false;
            this.btn_menu.Click += new System.EventHandler(this.btn_menu_Click);
            // 
            // pnl_catalogo
            // 
            this.pnl_catalogo.Controls.Add(this.btn_categoria);
            this.pnl_catalogo.Location = new System.Drawing.Point(3, 123);
            this.pnl_catalogo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pnl_catalogo.Name = "pnl_catalogo";
            this.pnl_catalogo.Size = new System.Drawing.Size(286, 60);
            this.pnl_catalogo.TabIndex = 1;
            // 
            // btn_categoria
            // 
            this.btn_categoria.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_categoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_categoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_categoria.ForeColor = System.Drawing.Color.White;
            this.btn_categoria.Image = ((System.Drawing.Image)(resources.GetObject("btn_categoria.Image")));
            this.btn_categoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_categoria.Location = new System.Drawing.Point(-12, -19);
            this.btn_categoria.Name = "btn_categoria";
            this.btn_categoria.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_categoria.Size = new System.Drawing.Size(331, 101);
            this.btn_categoria.TabIndex = 3;
            this.btn_categoria.Text = "        Catalogo";
            this.btn_categoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_categoria.UseVisualStyleBackColor = false;
            this.btn_categoria.Click += new System.EventHandler(this.btn_categoria_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_carrito);
            this.panel1.Location = new System.Drawing.Point(3, 216);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 60);
            this.panel1.TabIndex = 1;
            // 
            // btn_carrito
            // 
            this.btn_carrito.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_carrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_carrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_carrito.ForeColor = System.Drawing.Color.White;
            this.btn_carrito.Image = ((System.Drawing.Image)(resources.GetObject("btn_carrito.Image")));
            this.btn_carrito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_carrito.Location = new System.Drawing.Point(-13, -20);
            this.btn_carrito.Name = "btn_carrito";
            this.btn_carrito.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_carrito.Size = new System.Drawing.Size(331, 101);
            this.btn_carrito.TabIndex = 4;
            this.btn_carrito.Text = "        Carrito ";
            this.btn_carrito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_carrito.UseVisualStyleBackColor = false;
            this.btn_carrito.Click += new System.EventHandler(this.btn_carrito_Click);
            // 
            // pnl_consultas
            // 
            this.pnl_consultas.Controls.Add(this.btn_consultas);
            this.pnl_consultas.Location = new System.Drawing.Point(3, 309);
            this.pnl_consultas.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pnl_consultas.Name = "pnl_consultas";
            this.pnl_consultas.Size = new System.Drawing.Size(286, 60);
            this.pnl_consultas.TabIndex = 1;
            // 
            // btn_consultas
            // 
            this.btn_consultas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_consultas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_consultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_consultas.ForeColor = System.Drawing.Color.White;
            this.btn_consultas.Image = ((System.Drawing.Image)(resources.GetObject("btn_consultas.Image")));
            this.btn_consultas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_consultas.Location = new System.Drawing.Point(-5, -19);
            this.btn_consultas.Name = "btn_consultas";
            this.btn_consultas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_consultas.Size = new System.Drawing.Size(331, 101);
            this.btn_consultas.TabIndex = 5;
            this.btn_consultas.Text = "        Consultas";
            this.btn_consultas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_consultas.UseVisualStyleBackColor = false;
            this.btn_consultas.Click += new System.EventHandler(this.btn_consultas_Click);
            // 
            // pnl_salir
            // 
            this.pnl_salir.Controls.Add(this.btn_salir);
            this.pnl_salir.Location = new System.Drawing.Point(3, 829);
            this.pnl_salir.Margin = new System.Windows.Forms.Padding(3, 430, 3, 3);
            this.pnl_salir.Name = "pnl_salir";
            this.pnl_salir.Size = new System.Drawing.Size(286, 60);
            this.pnl_salir.TabIndex = 1;
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ForeColor = System.Drawing.Color.White;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(-7, -19);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_salir.Size = new System.Drawing.Size(331, 101);
            this.btn_salir.TabIndex = 6;
            this.btn_salir.Text = "        Salir";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // panel_control
            // 
            this.panel_control.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_control.Location = new System.Drawing.Point(288, 0);
            this.panel_control.Name = "panel_control";
            this.panel_control.Size = new System.Drawing.Size(1278, 911);
            this.panel_control.TabIndex = 2;
            // 
            // frm_dashboard_cajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 911);
            this.Controls.Add(this.panel_control);
            this.Controls.Add(this.navegador);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_dashboard_cajero";
            this.Text = "Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_dashboard_cajero_FormClosed);
            this.navegador.ResumeLayout(false);
            this.pnl_menu.ResumeLayout(false);
            this.pnl_catalogo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnl_consultas.ResumeLayout(false);
            this.pnl_salir.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.FlowLayoutPanel navegador;
        protected System.Windows.Forms.Panel pnl_menu;
        protected System.Windows.Forms.Button btn_menu;
        protected System.Windows.Forms.Panel pnl_catalogo;
        protected System.Windows.Forms.Button btn_categoria;
        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_carrito;
        protected System.Windows.Forms.Panel pnl_consultas;
        private System.Windows.Forms.Button btn_consultas;
        private System.Windows.Forms.Panel pnl_salir;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Panel panel_control;
    }
}