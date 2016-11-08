using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Autentificacion_Grafica
{
    class Leer
    {
        public static string LeerUsuario(string nombre)
        {
            try
            {
                using (StreamReader sr = new StreamReader(Form1.archivoUsuarios))
                {
                    string linea = sr.ReadToEnd();
                    
                    // retorn d'usuari no trobat
                    return "noEncontrado";            

                }
            }
            catch
            {
                // Retornem null per indicar que no s'ha pogut llegir el fitxer
                return null;
            }
        }
    }
}
