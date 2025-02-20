using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "ADMIN" && txtpass.Text == "admin")
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                MessageBox.Show("usuario y clave incorrecta");
            }
        }
    }
}


