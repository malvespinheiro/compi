﻿using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleConditionTermProduction : CompoundProduction<PossibleConditionTermProduction>, IExecutor<PossibleConditionTermProduction>
    {
        ConditionTermProduction conditionTermProduction = new ConditionTermProduction();
        public PossibleConditionTermProduction()
            : base(35, "PossibleConditionTerm", " . | ConditionTerm") { }
        public PossibleConditionTermProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.OR)
            {
                Check(TokenEnum.OR);
                conditionTermProduction.Execute();
                Execute();
            }
            return this;
        }
        public override void InitProductions()
        {
            conditionTermProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}