using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    abstract class CompoundProduction<TProduction> : BaseProduction<TProduction>
    {
        public abstract void InitProductions();

        public override void Init(
            ref BaseScanner scanner,
            ref BaseSymbolTable symbolTable,
            ref Token currentToken,
            ref Token lookingAheadToken,
            ref ErrorHandler errorHandler)
        {
            base.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            this.InitProductions();
        }
    }
}