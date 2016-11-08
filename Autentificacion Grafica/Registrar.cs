using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Autentificacion_Grafica
{
    class Registrar
    {
        
        public static string crearLogin (string nombre, string contrasena)
        {

            string apartado = Leer.LeerUsuario(nombre);
            
            if (apartado =="noEncontrado")
            {
                //declaramos el salt en byte
                byte[] salt;

                //Creamos un salt aleatorio
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

                //Llamamos a la clase de calcular hash con la contraseña y el salt
                string hash = ClassCalcularHashConPassYSalt.CrearHash(contrasena, salt);

                //Comprovamos si el se ha producido algun error en la clase de crear el hash para poder mostrarlo en el form
                if (hash == "problemaHash")
                {
                    return hash;
                }
                else
                {
                    //Aqui usamos la constante Inicializada en el Form1 para escribir 
                    //en el usuarios.txt el nombre, el salt(convertida a String) y el hash del password 
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(Form1.archivoUsuarios, true))
                    {
                        file.WriteLine(nombre + ',' + Convert.ToBase64String(salt) + ',' + hash);
                    }
                    return "creado";
                }
            }
            else
            {
                return "existe";
            }
        }
    }
}
