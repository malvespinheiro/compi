using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleRestOfMethodCallProduction : CompoundProduction<PosibleRestOfMethodCallProduction>
    {
        PosibleParamsSendProduction posibleParamsSendProduction = new PosibleParamsSendProduction();

        public override PosibleRestOfMethodCallProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.LPAR)
            {
                Check(TokenEnum.LPAR);
                posibleParamsSendProduction.Execute();
                Check(TokenEnum.RPAR);
            }
            return this;
        }
        public override void InitProductions()
        {
            posibleParamsSendProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}