using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleMinusProduction : CheckedBeganProduction<PossibleMinusProduction>, IExecutor<PossibleMinusProduction>
    {
        public PossibleMinusProduction()
            : base(20, "PossibleMinus", "") { }
        public PossibleMinusProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.MINUS)
            {
                Check(TokenEnum.MINUS);
            }
            return this;
        }
        public override bool ValidBegin(TokenEnum tokenExpected)
        {
            return tokenExpected == TokenEnum.MINUS;
        }
    }
}