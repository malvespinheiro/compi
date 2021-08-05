using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleMinusProduction : BaseProduction<PosibleMinusProduction>
    {
        public override PosibleMinusProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.MINUS)
            {
                Check(TokenEnum.MINUS);
            }
            return this;
        }
    }
}