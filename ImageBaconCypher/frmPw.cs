using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageBaconCypher
{
    public partial class frmPw : Form
    {
        public string Password
        { get { return this.txtPassword.Text; } }

        public frmPw()
        {
            InitializeComponent();
        }
    }
}
