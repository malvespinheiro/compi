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

        internal void ThrowParserError(object invalidConstantType)
        {
            throw new NotImplementedException();
        }
    }
}
