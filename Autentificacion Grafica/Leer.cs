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
                using (StreamReader sr = new StreamReader("usuarios.txt"))
                {
                    //Declaro esta variable donde se guardara cada linea del archivo
                    string linia;

                    //Declaro una array para llenarla con el nombre del usuario,salt y hash. Separadas por ,
                    string[] user;

                    //Este while lee una linea del archivo por cada vuelta
                    while ((linia = sr.ReadLine()) != null)
                    {
                        //metemos en esta array lo que haya antes de la primera ',' en este caso el nombre del usuario
                        user = linia.Split(',');
                    }
                    

                    return "noEncontrado";

                }
            }
            catch
            {
                //Devolvemos un null para decir que se a producido un error al leer el archivo
                return null;
            }
        }
    }
}
