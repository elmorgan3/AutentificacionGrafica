using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Autentificacion_Grafica
{
    class ClassCalcularHashConPassYSalt
    {
        // PORQUE SE TIENE QUE PONER EL STATIC?????????????????????????????????
        //Se pone porque asin no hace falta crear un objeto de la clase osea un new
        public static string CrearHash(string contrasena, byte[] salt)
        {
            try
            {
                //calculamos el hash con el password y el salt juntos
                var pbkdf2 = new Rfc2898DeriveBytes(contrasena, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(32);

                //Devolvemos el hash ya calculado
                return Convert.ToBase64String(hash);
            }
            catch (Exception)
            {
                return "problemaHash";
            }
        }
    }
}
