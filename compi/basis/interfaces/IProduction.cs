using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis.interfaces
{
    interface IProduction
    {
        IProduction Execute();

        IProduction Init(ref IScanner scanner, ref Token currentToken, ref Token lookingAheadToken);

        void Scan();

        void Check(TokenKind expected);
    }
}
