using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleMinusProduction : BaseProduction<PossibleMinusProduction>
    {
        public override PossibleMinusProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.MINUS)
            {
                Check(TokenEnum.MINUS);
            }
            return this;
        }
    }
}