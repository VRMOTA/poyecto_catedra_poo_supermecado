using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_prom : UserControl
    {
        private int id_promocion;
        public card_prom()
        {
            InitializeComponent();
        }
        public int ID_Promocion
        {
            get => id_promocion;
            set => id_promocion = value;
        }
        [Category("Promocion"), Description("Nombre del Producto")]
        public string Nombre_Producto
        {
            get => lblProducto?.Text ?? string.Empty;
            set { if (lblProducto != null) lblProducto.Text = value; }
        }
        [Category("Promocion"), Description("Cantidad minima de la promocion")]
        public int Cantidad_Minima
        {
            get => int.TryParse(lb_cantidad_min?.Text, out int result) ? result : 0;
            set { if (lb_cantidad_min != null) lb_cantidad_min.Text = value.ToString(); }
        }
        [Category("Promocion"), Description("Precion de la promocion")]
        public decimal Precio_Promocion
        {
            get => decimal.TryParse(lb_precio_prom?.Text, out decimal result) ? result : 0;
            set { if (lb_precio_prom != null) lb_precio_prom.Text = value.ToString("F2"); }
        }
        [Category("Promocion"), Description("Descripcion de la promocion")]
        public string Descripcion_Promocion
        {
            get => lblDescripcion?.Text ?? string.Empty;
            set { if (lblDescripcion != null) lblDescripcion.Text = value; }
        }
        [Category("Promocion"), Description("Fecha de inicio de la promocion ")]
        public DateTime Fecha_Inicio
        {
            get => DateTime.TryParse(lb_fecha_inicio?.Text, out DateTime result) ? result : DateTime.Now;
            set { if (lb_fecha_inicio != null) lb_fecha_inicio.Text = value.ToString("yyyy-MM-dd"); }
        }
        [Category("Promocion"), Description("Fecha de finalizacion de la promocion ")]
        public DateTime Fecha_Fin
        {
            get => DateTime.TryParse(lb_fecha_fin?.Text, out DateTime result) ? result : DateTime.Now;
            set { if (lb_fecha_fin != null) lb_fecha_fin.Text = value.ToString("yyyy-MM-dd"); }
        }
    }
}
