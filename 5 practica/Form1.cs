using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _5_practica
{
    public partial class Form1 : Form
    {
        int vindice;
        string vseleccion;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Mexico");
            comboBox1.Items.Add("Canada");
            comboBox1.Items.Add("USA");
            comboBox1.Items.Add("Corea del sur");
            comboBox1.Items.Add("China");
            comboBox1.Items.Add("Colombia");
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            vseleccion = Convert.ToString(comboBox1.Text);
            int vIndice = dataGridView1.Rows.Add();

            dataGridView1.Rows[vIndice].Cells[0].Value = txtname.Text;
            dataGridView1.Rows[vIndice].Cells[1].Value = txtLastname.Text;
            dataGridView1.Rows[vIndice].Cells[2].Value = vseleccion;

            txtname.Text = "";
            txtLastname.Text = "";
            comboBox1.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vindice = e.RowIndex;
        }

        private void btnREMOVE_Click(object sender, EventArgs e)
        {
            if (vindice != -1)
            {
                dataGridView1.Rows.RemoveAt(vindice);
            }

            else
            {
                MessageBox.Show("Select a ITEM to delete");
            }
        }
    }
}
