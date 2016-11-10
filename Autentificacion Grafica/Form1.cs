using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;


namespace Autentificacion_Grafica
{
    public partial class Form1 : Form
    {
        //Inicializamos estas variables aqui para que sean accesibles por los metodos
        string nombre;
        string contrasena;

        //Creamos una variable donde guardamos el nombre que tendra el archivo,
        //en el que guardaremos los datos de los usarios
        //PORQUE HAY QUE PONER CONST????????????????????
        public const string archivoUsuarios = "usuarios.txt";


        public Form1()
        {
            InitializeComponent();

            //Comprovamos si el archivo ya existe y sino lo creamos
            if (!(File.Exists(archivoUsuarios)))
            {
                using (File.Create(archivoUsuarios));
            }
        }


        //Este metodo coge los valores de texBoxNombre y textBoxContrasena y llama al 
        //metodo crearLogin de la clase Registrar 
        private void buttonRegistrarse_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text == "" || textBoxContrasena.Text == "")
            {
                MessageBox.Show("Tiene que rellenar los dos campos");
            }
            else
            {
                nombre = textBoxNombre.Text;

                contrasena = textBoxContrasena.Text;

                string respuesta = Registrar.crearLogin(nombre, contrasena);
                
                if (respuesta == "creado")
                {
                    MessageBox.Show("El usuario a sido creado");
                }
                else if (respuesta == "existe")
                {
                    MessageBox.Show("El usuario ya existe");
                }
                else if (respuesta == "problemaHash")
                {
                    MessageBox.Show("Se ha producido un error al crear el hash");
                }
            }
            
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {

        }


        
    }
}
