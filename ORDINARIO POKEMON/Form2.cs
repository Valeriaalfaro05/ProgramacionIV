using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calar_pokemon
{
    public partial class Form2 : Form
    {
        private int registroActual = 0; // es la funcion para poder mandar a llamar la imagen y aparezca en la pokedex 
        private DataTable datos = new DataTable();
        private Dictionary<int, string> imagenes = new Dictionary<int, string>(); // Diccionario para almacenar las imágenes según el número del Pokémon
        private string rutaImagenes = @"C:\Users\DELL\OneDrive\Documentos\ORDINARIO POKEMON\IMAGENES DE POKEMON"; // Ruta de imágenes
        public Form2()
        {

            InitializeComponent();
            CargarDatos();
            CargarImagenes();
        }
        private void CargarDatos() //es la conexion de sql a visual
        {
            SqlConnection conexion = new SqlConnection(@"server=ALFARO; database=pokemon; INTEGRATED SECURITY=true");
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT Numero, Nombre, Descripcion, Habilidad1, Habilidad2, Habilidadoculta, Tipo1, Tipo2, Peso, Altura FROM pokemon", conexion);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        private void MostrarRegistro() //crea la funcion que mandaremos a llamar para los datos en el label
        {
            if (datos.Rows.Count > 0 && registroActual < datos.Rows.Count)
            {
                DataRow fila = datos.Rows[registroActual];
                lbldatos.Text = $"Numero: {fila["Numero"]}\nNombre: {fila["Nombre"]}\nDescripcion: {fila["Descripcion"]}\nHabilidad1: {fila["Habilidad1"]}\nHabilidad2: {fila["Habilidad2"]}\nHabilidadoculta: {fila["Habilidadoculta"]}\nTipo1: {fila["Tipo1"]}\nTipo2: {fila["Tipo2"]}\nPeso: {fila["Peso"]}\nAltura: {fila["Altura"]}";

                int numeroPokemon = Convert.ToInt32(fila["Numero"]);
                MostrarImagen(numeroPokemon); // Mostrar la imagen del Pokémon actual
            }
            else
            {
                MessageBox.Show("No hay más registros.");
            }
        }
        private void CargarImagenes()
        {
            if (Directory.Exists(rutaImagenes))
            {
                string[] archivos = Directory.GetFiles(rutaImagenes, ".")
                                             .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png"))
                                             .ToArray();

                foreach (var archivo in archivos)
                {
                    string nombreArchivo = Path.GetFileNameWithoutExtension(archivo);
                    if (int.TryParse(nombreArchivo, out int numeroPokemon))
                    {
                        imagenes[numeroPokemon] = archivo; // Asocia la imagen al número del Pokémon
                    }
                }
            }
        }

        private void MostrarImagen(int numeroPokemon)
        {
            if (imagenes.ContainsKey(numeroPokemon))
            {
                pictureBox2.Image = Image.FromFile(imagenes[numeroPokemon]);
            }
            else
            {
                pictureBox2.Image = null; // Si no hay imagen, deja el PictureBox en blanco
                MessageBox.Show("No se encontró imagen para este Pokémon.");
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MostrarRegistro();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (registroActual > 0)
            {
                registroActual--;
                MostrarRegistro();
            }
            else
            {
                MessageBox.Show("Este es el primer registro.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (registroActual < datos.Rows.Count - 1)
            {
                registroActual++;
                MostrarRegistro();
            }
            else
            {
                MessageBox.Show("No hay más registros.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumero.Text, out int numero))
            {
                MostrarRegistroPorNumero(numero);
            }
            else
            {
                MessageBox.Show("Ingrese un número válido.");
            }
        }
        //Esta es la funcion la cual nos va a permitir mostrar los datos de sql en el label
        private void MostrarRegistroPorNumero(int numero)
        {
            DataRow[] filaEncontrada = datos.Select($"Numero = {numero}");

            if (filaEncontrada.Length > 0)
            {
                DataRow fila = filaEncontrada[0];
                lbldatos.Text = $"Numero: {fila["Numero"]}\nNombre: {fila["Nombre"]}\nDescripcion: {fila["Descripcion"]}\nHabilidad1: {fila["Habilidad1"]}\nHabilidad2: {fila["Habilidad2"]}\nHabilidadoculta: {fila["Habilidadoculta"]}\nTipo1: {fila["Tipo1"]}\nTipo2: {fila["Tipo2"]}\nPeso: {fila["Peso"]}\nAltura: {fila["Altura"]}";
                //Es la funcion para mandar a llamar las imagenes
                MostrarImagen(numero);
            }
            else
            {
                MessageBox.Show("No se encontró ningún Pokémon con ese número.");
            }
        }

        private void button5_Click(object sender, EventArgs e) //Esta es la funcion para poderte mandar al primer formulario 
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
