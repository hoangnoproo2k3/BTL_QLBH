﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBH.View
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void customerMenu_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.MdiParent = this;
            customer.Dock = DockStyle.Fill;
            customer.Show();
        }
    }
}