using System;

namespace unsj.fcefn.compiladores.compi.basis.exceptions
{
    class ErrorHandler
    {
        public void ThrowParserError(String expected, String messasgeError)
        {
            throw new ParserException(ErrorMessages.GetMessage(expected, messasgeError));
        }

        public void ThrowScannerError(String currentCharacter, String messasgeError)
        {
            throw new ScannerException(ErrorMessages.GetMessage(currentCharacter, messasgeError));
        }
    }
}
