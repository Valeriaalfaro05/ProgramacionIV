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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Login()
        {
            SqlConnection conexion = new SqlConnection(@"server=ALFARO; database=milogin; INTEGRATED SECURITY=true"
);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(" SELECT Username, pass FROM registro WHERE Username=@Username AND pass=@pass",
                conexion);
            cmd.Parameters.AddWithValue("@Username", textuser.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", textpass.Text.Trim());

            SqlDataReader Lector = cmd.ExecuteReader();

            if (Lector.Read())
            {
                conexion.Close();
                MessageBox.Show("Login Exitoso");
                Form1 Index = new Form1();
                Index.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You've entered incorrect login details", "ERROR",
                MessageBoxButtons.OK);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            {
                if (checkBox1.Checked)
                {
                    textpass.UseSystemPasswordChar = false; // Muestra la contraseña
                }
                else
                {
                    textpass.UseSystemPasswordChar = true; // Oculta la contraseña
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}


