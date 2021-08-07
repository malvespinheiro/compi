using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TypeProduction : CheckedBeganProduction<TypeProduction>
    {
        public override TypeProduction Execute()
        {
            Check(TokenEnum.IDENT);
            return this;
        }

        public override bool ValidBegin(TokenEnum tokenExpected)
        {
            return tokenExpected == TokenEnum.IDENT;
        }
    }
}