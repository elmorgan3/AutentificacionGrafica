using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Autentificacion_Grafica
{
    class Iniciar
    {

        public static string autentificar (string nombre, string contrasena)
        {
            //Creamos una array donde guardaremos la linea de cada usuario del archivo
            string[] usuario;

            //Creamos una array de tipo byte donde guardaremos el salt del archivo
            //Hay que declararlo array porque sino da error
            byte[] saltLeido;

            //Llamamos a la clase 'Leer' para leer el archivo
            string respuestaArchivo = Leer.LeerUsuario(nombre);

            //Hacemos un if para ver si se a encontrado el usuario
            if (respuestaArchivo == "noEncontrado")
            {
                return "noEncontrado";
            }
            else
            {
                //Si se ha encontrado al usuario guardamos los tres datos en el array separado por las ','
                usuario = respuestaArchivo.Split(',');

                //Convertimos el salt de byte a string
                saltLeido = Convert.FromBase64String(usuario[1]);
          
                //Calculamos el hash con el salt del archivo mas el la contraseña introducido por el usuario
                string hash = ClassCalcularHashConPassYSalt.CrearHash(contrasena, saltLeido);

                //Los comparamos para ver si coinciden con el registrado
                if (hash == usuario[2])
                {
                    return "usuarioAutentificado";
                }
                else
                {
                    return "contraNoCoincide";
                }
                
            }
        }
    }
}
