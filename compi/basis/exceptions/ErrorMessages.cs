using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unsj.fcefn.compiladores.compi.basis.exceptions
{
    class ErrorMessages
    {
        public static string wrongCharacter = "Token inválido debido a caracter: ";
        public static string wrongFormatNumber = "El formato del caracter no es válido: ";
        public static string wrongExpectedToken = "Se esperaba: ";

        public static String GetMessage(String data, String message)
        {
            return message + data;
        }
    }
}
