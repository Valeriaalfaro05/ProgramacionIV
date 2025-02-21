using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnpromedio_Click(object sender, EventArgs e)
        {
            //OBTENER DATOS DE LOS TEXTBOX
            string nombre = textBox4.Text;
            double parcial1 = Convert.ToDouble(txtparcial1.Text);
            double parcial2 = Convert.ToDouble(txtparcial2.Text);
            double parcial3 = Convert.ToDouble(txtparcial3.Text);

            //calculo el promedio de los tres parciales, con su respesctiva formula 
            double promedio = (parcial1 + parcial2 + parcial3) / 3;

            //determinar el estatus del alumno 
            string Estatus;
            if (promedio >= 95)
            {
                Estatus = "Exento";
            }
            else if (promedio >= 70)
            {
                Estatus = "Ordinario";
            }
            else if (promedio >= 50)
            {
                Estatus = "Extraordinario";
            }
            else
            {
                Estatus = "Especial";
            }

            int vIndice = dataGridView1.Rows.Add();
            dataGridView1.Rows[vIndice].Cells[0].Value = textBox4.Text;
            dataGridView1.Rows[vIndice].Cells[1].Value = txtparcial1.Text;
            dataGridView1.Rows[vIndice].Cells[2].Value = txtparcial2.Text;
            dataGridView1.Rows[vIndice].Cells[3].Value = txtparcial3.Text;
            dataGridView1.Rows[vIndice].Cells[4].Value = promedio;
            dataGridView1.Rows[vIndice].Cells[5].Value = Estatus;

            textBox4.Text = "";
            txtparcial1.Text = "";
            txtparcial2.Text = "";
            txtparcial3.Text = "";
        }

    }
}

    

