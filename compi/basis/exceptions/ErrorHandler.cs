using System;

namespace unsj.fcefn.compiladores.compi.basis.exceptions
{
    class ErrorHandler
    {
        public void ThrowParserError(String messasgeError)
        {
            throw new ParserException(messasgeError);
        }
        public void ThrowScannerError(String messasgeError)
        {
            throw new ScannerException(messasgeError);
        }
        public void ThrowTypingError(String messasgeError)
        {
            throw new TypeCheckingException(messasgeError);
        }
        public void ThrowIdentifierError(String messasgeError)
        {
            throw new IdentifiersException(messasgeError);
        }
    }
}
