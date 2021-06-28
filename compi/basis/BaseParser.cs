using unsj.fcefn.compiladores.compi.basis.interfaces;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    class BaseParser<TProduction> : IParser<BaseParser<TProduction>>
    {
        BaseProduction<TProduction> rootProduction;

        public BaseParser<TProduction> Compile()
        {
            rootProduction.Execute();
            return this;
        }

        public BaseParser<TProduction> Init(BaseScanner scanner)
        {
            Token currentToken = null;
            Token lookingAheadToken = new Token(1, 1);

            this.rootProduction.Init(ref scanner, ref currentToken, ref lookingAheadToken);
            return this;
        }
    }
}