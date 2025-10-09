using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using poyecto_catedra_poo_supermecado.CustomCards;

namespace poyecto_catedra_poo_supermecado
{
    public partial class frm_consultas_cajero : Form
    {
        private List<Consulta> consultas = new List<Consulta>();
        private List<card_consultas> consultasCards = new List<card_consultas>();

        // Constantes para layout
        private const int AltoCarta = 204;
        private const int Espacio = 10;

        public frm_consultas_cajero()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(235, 235, 235);
        }

        private void frm_consultas_cajero_Load_1(object sender, EventArgs e)
        {
            InicializarConsultas();
            CargarConsultas();

        }
        private void InicializarConsultas()
        {
            consultas = new List<Consulta>
            {
                new Consulta(1, "Manzana", "Juan Pérez", "juan.perez@email.com", "¿Cuál es el origen de la manzana?", 1.20m, 10, Properties.Resources.manzana),
                new Consulta(2, "Leche", "Ana Gómez", "ana.gomez@email.com", "¿La leche es deslactosada?", 2.50m, 5, Properties.Resources.leche),
                new Consulta(3, "Yogur", "Carlos Ruiz", "carlos.ruiz@email.com", "¿Caduca pronto el yogur?", 1.60m, 0, Properties.Resources.yogyur),
                new Consulta(4, "Pan", "María López", "maria.lopez@email.com", "¿Es sin gluten el pan?", 1.00m, 0, Properties.Resources.pan),
            };
        }

        private void CargarConsultas()
        {
            panel1.Controls.Clear();
            consultasCards.Clear();
            panel1.AutoScroll = true;

            // Constantes para layout
            int columnas = 1; // Solo una columna para consultas
            int anchoCarta = panel1.Width - 25;

            for (int i = 0; i < consultas.Count; i++)
            {
                var c = consultas[i];

                var card = new card_consultas
                {
                    NombreProducto = c.Producto,
                    NombreCliente = c.Consultante,
                    ImagenProducto = c.Imagen,
                    Width = anchoCarta,
                    Height = AltoCarta,
                    Left = 0,
                    Top = i * (AltoCarta + Espacio)
                };

                // Suscribimos el evento igual que en productos
                card.BotonVisualizarClick += Card_BotonVisualizarClick;

                panel1.Controls.Add(card);
                consultasCards.Add(card);
            }

            int filas = consultas.Count;
            panel1.AutoScrollMinSize = new Size(
                columnas * (anchoCarta + Espacio),
                filas * (AltoCarta + Espacio)
            );
        }

        // Evento centralizado para mostrar información
        private void Card_BotonVisualizarClick(object sender, int idConsulta)
        {
            var consulta = consultas.FirstOrDefault(c => c.Id == idConsulta);
            if (consulta == null)
            {
                MessageBox.Show("Consulta no encontrada.");
                return;
            }

            lblNombreProducto.Text = consulta.Producto;
            lblPrecio.Text = consulta.Precio.ToString("C2");
            lblPrecioDescuento.Text = consulta.Descuento > 0
                ? (consulta.Precio * (1 - (consulta.Descuento / 100m))).ToString("C2")
                : "";
            lb_nombre_cliente.Text = consulta.Consultante;
            lb_cliente.Text = consulta.Correo;
            lb_consutla.Text = consulta.Descripcion;
            pbProducto.Image = consulta.Imagen;
        }


    }

    // Clase Consulta con ID
    public class Consulta
    {
        public int Id { get; }
        public string Producto { get; }
        public string Consultante { get; }
        public string Correo { get; }
        public string Descripcion { get; }
        public decimal Precio { get; }
        public int Descuento { get; }
        public Image Imagen { get; }

        public Consulta(int id, string producto, string consultante, string correo, string descripcion, decimal precio, int descuento, Image imagen)
        {
            Id = id;
            Producto = producto;
            Consultante = consultante;
            Correo = correo;
            Descripcion = descripcion;
            Precio = precio;
            Descuento = descuento;
            Imagen = imagen;
        }
    }
}
