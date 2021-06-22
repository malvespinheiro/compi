using System.IO;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis.interfaces
{
    interface IScanner
    {
        void Init(TextReader input);

        void NextCharacter();

        Token Next();
    }
}