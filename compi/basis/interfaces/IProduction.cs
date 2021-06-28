using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis.interfaces
{
    interface IProduction<TProduction>
    {
        TProduction Execute();

        void Init(ref BaseScanner scanner, ref Token currentToken, ref Token lookingAheadToken);

        void Scan();

        void Check(TokenEnum expected);
    }
}
