﻿using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleConditionFactorProduction : CompoundProduction<PosibleConditionFactorProduction>
    {
        ConditionFactorProduction conditionFactorProduction = new ConditionFactorProduction();
        public override PosibleConditionFactorProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.AND)
            {
                Check(TokenEnum.AND);
                conditionFactorProduction.Execute();
                Execute();
            }
            return this;
        }
        public override void InitProductions()
        {
            conditionFactorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
       
    }
}