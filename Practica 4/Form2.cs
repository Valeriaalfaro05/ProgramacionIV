using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Practica_4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void funRegistro()
        {
            SqlConnection conexion = new SqlConnection(@"server=ALFARO ; database = milogin ; 
            INTEGRATED SECURITY = true");

            conexion.Open();

            string vConsultaSQL = "INSERT INTO registro (Username, pass) VALUES ('" +
            textBox3.Text.Trim() + "', '" + textBox4.Text.Trim() + "')";

            SqlCommand cmdRegistro = new SqlCommand(vConsultaSQL, conexion);
            cmdRegistro.ExecuteNonQuery();
            conexion.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            funRegistro();
            if (textBox5.Text == textBox4.Text)
            {
                MessageBox.Show("You've signed a new user", "NEW REGISTER", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("You've entered incorrect login details", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox1.Checked)
                {
                    textBox4.UseSystemPasswordChar = false; // Muestra la contraseña
                }
                else
                {
                    textBox4.UseSystemPasswordChar = true; // Oculta la contraseña
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox1.Checked)
                {
                    textBox5.UseSystemPasswordChar = false; // Muestra la contraseña
                }
                else
                {
                    textBox5.UseSystemPasswordChar = true; // Oculta la contraseña
                }
            }
        }
    }
}

