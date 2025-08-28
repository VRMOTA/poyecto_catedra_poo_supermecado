﻿using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_distribuidores : RoundedControlBase
    {
        public card_distribuidores()
        {
            InitializeComponent();
        }

        [Category("Distribuidora"), Description("Imagen de la distribuidora")]
        public Image ImagenDistribuidora
        {
            get => pbDistribuidora?.Image;
            set { if (pbDistribuidora != null) pbDistribuidora.Image = value; }
        }

        [Category("Distribuidora"), Description("Nombre de la distribuidora")]
        public string NombreDistribuidora
        {
            get => lblDistribuidora?.Text ?? string.Empty;
            set { if (lblDistribuidora != null) lblDistribuidora.Text = value; }
        }

        [Category("Distribuidora"), Description("Categoría de productos que distribuyen")]
        public string Categoria
        {
            get => lblCategoria?.Text ?? string.Empty;
            set { if (lblCategoria != null) lblCategoria.Text = value; }
        }

        private void buttonMaxing2_Click(object sender, EventArgs e)
        {
            var modal = new md_agregar_distribuidor("Actualizar nuevo distribuidor", "Actualizar");
            modal.ShowDialog();
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
   "¿Está seguro que desea eliminar el registro?",
   "Confirmar eliminación",
   MessageBoxButtons.YesNo,
   MessageBoxIcon.Warning
);

            if (resultado == DialogResult.Yes)
            {

            }
        }
    }
}