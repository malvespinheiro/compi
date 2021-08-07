﻿using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleRestOfMethodCallProduction : CompoundProduction<PossibleRestOfMethodCallProduction>
    {
        PossibleParamsSendProduction possibleParamsSendProduction = new PossibleParamsSendProduction();

        public override PossibleRestOfMethodCallProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.LPAR)
            {
                Check(TokenEnum.LPAR);
                possibleParamsSendProduction.Execute();
                Check(TokenEnum.RPAR);
            }
            return this;
        }
        public override void InitProductions()
        {
            possibleParamsSendProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}