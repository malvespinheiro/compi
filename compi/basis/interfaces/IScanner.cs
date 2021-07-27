using System.IO;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis.interfaces
{
    interface IScanner
    {
        void Init(string input, ErrorHandler errorHandler);
    
        void NextCharacter();

        Token Next();
    }
}