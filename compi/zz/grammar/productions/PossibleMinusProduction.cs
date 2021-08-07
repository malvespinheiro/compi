﻿using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleMinusProduction : CheckedBeganProduction<PossibleMinusProduction>
    {
        public override PossibleMinusProduction Execute()
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