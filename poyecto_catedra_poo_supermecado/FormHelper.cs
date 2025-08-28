﻿using System;
using System.Windows.Forms;

namespace project_supermercado
{
    public static class FormHelper
    {
        // Funcion para definir valores default para cada formulario
        public static void DefaultFormValues(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.MinimizeBox = true;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Load += (sender, e) => {
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
            };
        }
    }
}