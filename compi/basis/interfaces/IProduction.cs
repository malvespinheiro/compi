using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis.interfaces
{
    interface IProduction<TProduction>
    {
        TProduction Execute();

        void Init(ref BaseScanner scanner, ref BaseSymbolTable symbolTable, ref Token currentToken, ref Token lookingAheadToken, ref ErrorHandler errorHandler);

        void Scan();

        void Check(TokenEnum expected);
    }
}
