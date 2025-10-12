using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomControls
{
    [DefaultEvent("TextChanged")]
    public partial class TextboxMaxing : UserControl
    {
        //Campos
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;

        // Nuevos campos para placeholder
        private string placeholderText = "";
        private Color placeholderColor = Color.Gray;
        private bool isPlaceholderActive = false;
        private bool passwordChar = false; // Nuevo campo para almacenar el estado de PasswordChar

        //Eventos
        public event EventHandler TextChanged;

        //Propiedades
        [Category("Textbox Maxing")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Textbox Maxing")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Textbox Maxing")]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("Textbox Maxing")]
        public bool PasswordChar
        {
            get { return passwordChar; }
            set
            {
                passwordChar = value;
                // Solo aplicar si no hay placeholder activo
                if (!isPlaceholderActive)
                    textBox1.UseSystemPasswordChar = value;
            }
        }

        [Category("Textbox Maxing")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("Textbox Maxing")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("Textbox Maxing")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("Textbox Maxing")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("Textbox Maxing")]
        public string Texts
        {
            get
            {
                if (isPlaceholderActive)
                    return "";
                else
                    return textBox1.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(placeholderText))
                {
                    SetPlaceholder();
                }
                else
                {
                    RemovePlaceholder();
                    textBox1.Text = value;
                }
            }
        }

        [Category("Textbox Maxing")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        // Nuevas propiedades para placeholder
        [Category("Textbox Maxing")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                if (string.IsNullOrEmpty(textBox1.Text) || isPlaceholderActive)
                {
                    if (!string.IsNullOrEmpty(value))
                        SetPlaceholder();
                    else if (isPlaceholderActive)
                        RemovePlaceholder();
                }
            }
        }

        [Category("Textbox Maxing")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;
                if (isPlaceholderActive)
                    textBox1.ForeColor = value;
            }
        }

        //Constructor
        public TextboxMaxing()
        {
            InitializeComponent();
        }

        //Sobreescribir otros metodos
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            //Draw border
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if (isFocused) penBorder.Color = borderFocusColor;//Set Border color in focus. Otherwise, normal border color

                if (underlinedStyle) //Line Style
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                else //Normal Style
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();

            // Inicializar placeholder si es necesario
            if (!string.IsNullOrEmpty(placeholderText) && string.IsNullOrEmpty(textBox1.Text))
                SetPlaceholder();
        }

        //Metodos privados
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Si hay texto y el placeholder está activo, removerlo
            if (!string.IsNullOrEmpty(textBox1.Text) && isPlaceholderActive)
            {
                RemovePlaceholder();
            }

            if (TextChanged != null)
                TextChanged.Invoke(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        //Cambiar valores del textbox cuando se seleccione
        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();

            // Remover placeholder al enfocar
            if (isPlaceholderActive)
                RemovePlaceholder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();

            // Establecer placeholder si está vacío al perder el foco
            if (string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(placeholderText))
                SetPlaceholder();
        }

        // Métodos para manejar el placeholder
        private void SetPlaceholder()
        {
            if (string.IsNullOrEmpty(placeholderText))
                return;

            isPlaceholderActive = true;
            textBox1.Text = placeholderText;
            textBox1.ForeColor = placeholderColor;
            textBox1.UseSystemPasswordChar = false; // Siempre desactivar password char para placeholder
        }

        private void RemovePlaceholder()
        {
            if (!isPlaceholderActive)
                return;

            isPlaceholderActive = false;
            textBox1.Text = "";
            textBox1.ForeColor = this.ForeColor;

            // Restaurar la propiedad PasswordChar según el valor almacenado
            textBox1.UseSystemPasswordChar = passwordChar;
        }
    }
}