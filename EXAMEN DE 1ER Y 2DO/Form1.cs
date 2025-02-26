using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAMEN_DE_1ER_Y_2DO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                // Obtener mi fecha de nacimiento en la caja de texto 
                string input = textBox1.Text;


                if (DateTime.TryParse(input, out DateTime fechaNacimiento))
                {
                    // Obtener mi signo zodiacal correcto con la fecha de nacimiento 
                    string signo = ObtenerSignoZodiacal(fechaNacimiento.Day, fechaNacimiento.Month);
                    label3.Text = $"Tu signo zodiacal es: {signo}";
                }
                else
                {
                    MessageBox.Show("La fecha ingresada no es válida. Usa el formato: dd/mm/yyyy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string ObtenerSignoZodiacal(int dia, int mes)
            {
                // Definir los rangos de fecg=has para cada signo zodiacal 
                var signos = new[]
                {
            new { Signo = "Aries", MesInicio = 3, DiaInicio = 21, MesFin = 4, DiaFin = 19 },
            new { Signo = "Tauro", MesInicio = 4, DiaInicio = 20, MesFin = 5, DiaFin = 20 },
            new { Signo = "Géminis", MesInicio = 5, DiaInicio = 21, MesFin = 6, DiaFin = 20 },
            new { Signo = "Cáncer", MesInicio = 6, DiaInicio = 21, MesFin = 7, DiaFin = 22 },
            new { Signo = "Leo", MesInicio = 7, DiaInicio = 23, MesFin = 8, DiaFin = 22 },
            new { Signo = "Virgo", MesInicio = 8, DiaInicio = 23, MesFin = 9, DiaFin = 22 },
            new { Signo = "Libra", MesInicio = 9, DiaInicio = 23, MesFin = 10, DiaFin = 22 },
            new { Signo = "Escorpio", MesInicio = 10, DiaInicio = 23, MesFin = 11, DiaFin = 21 },
            new { Signo = "Sagitario", MesInicio = 11, DiaInicio = 22, MesFin = 12, DiaFin = 21 },
            new { Signo = "Capricornio", MesInicio = 12, DiaInicio = 22, MesFin = 1, DiaFin = 19 },
            new { Signo = "Acuario", MesInicio = 1, DiaInicio = 20, MesFin = 2, DiaFin = 18 },
            new { Signo = "Piscis", MesInicio = 2, DiaInicio = 19, MesFin = 3, DiaFin = 20 }
        };

                // Buscar el signo zodiacal que corresponda 
                foreach (var signoZodiacal in signos)
                {
                    if ((mes == signoZodiacal.MesInicio && dia >= signoZodiacal.DiaInicio) ||
                        (mes == signoZodiacal.MesFin && dia <= signoZodiacal.DiaFin) ||
                        (mes > signoZodiacal.MesInicio && mes < signoZodiacal.MesFin))
                    {
                        return signoZodiacal.Signo;
                    }
                }
                //muestra un mensaje en caso de que ponga una fecha fuera de los rangos 
                return "Fecha inválida"; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

