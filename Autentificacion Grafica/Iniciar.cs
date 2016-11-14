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
            string[] usuario;
            //Creamos una array de tipo byte donde guardaremos el salt del archivo
            //Hay que declararlo array porque sino da error
            byte[] saltLeido;

            string respuestaArchivo = Leer.LeerUsuario(nombre);

            if (respuestaArchivo == "noEncontrado")
            {
                return "noEncontrado";
            }
            else
            {
                usuario = respuestaArchivo.Split(',');

                saltLeido = Convert.FromBase64String(usuario[1]);
          
                string hash = ClassCalcularHashConPassYSalt.CrearHash(contrasena, saltLeido);

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
