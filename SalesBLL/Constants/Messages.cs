using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBLL.Constants
{
    public class Messages
    {
        #region ValidationPostUsers

        public static readonly string ExistingUserName = "El nombre de usuario ya existe.";
        public static readonly string ExistingMail = "El correo electrónico ya esta siendo usado por otro usaurio.";
        public static readonly string FormatPasswordNotMatch = "La constraseña debe contar con minimo con 8 caracteres, al menos unos letra mayúscula, una letra minúscula, un número y alguno de los siguietes caracteres especiales: (@$!%*?&).";
        public static readonly string FormatEmailNotMatch = "El correo no tiene un formato correcto.";
        public static readonly string ItsSamePassword = "La contraseña no puede ser igual a la actual.";

        #endregion

        #region Authenticate 

        public static readonly string UserDontExist = "El nombre de usuario no existe en el sistema.";
        public static readonly string ErrorAuthenticate = "Nombre de usuario o contraseña incorrecta.";

        #endregion


    }
}
