﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using poyecto_catedra_poo_supermecado.Utilities;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_signin : Form
    {
        public frm_signin()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
        }
    }
}
