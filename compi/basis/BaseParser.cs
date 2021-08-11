using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.interfaces;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    class BaseParser<TProduction> : IParser<TProduction>
    {
        BaseProduction<TProduction> rootProduction;

        public void SetRootProduction(BaseProduction<TProduction> rootProduction)
        {
            this.rootProduction = rootProduction;
        }

        public TProduction Compile()
        {
            return rootProduction.Execute();
        }

        public BaseParser<TProduction> Init(BaseScanner scanner, BaseSymbolTable symbolTable, ErrorHandler errorHandler)
        {
            Token currentToken = null;
            Token lookingAheadToken = new Token(1, 1);
            rootProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            return this;
        }
    }
}