﻿using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ParamsSendProduction : CompoundProduction<ParamsSendProduction>
    {
        private readonly ExpressionProduction expressionProduction = new ExpressionProduction();
        private readonly PossibleExpressionCommaSeparatedProduction possibleExpressionCommaSeparatedProduction = new PossibleExpressionCommaSeparatedProduction();

        public override ParamsSendProduction Execute()
        {
            expressionProduction.Execute();
            possibleExpressionCommaSeparatedProduction.Execute();
            return this;
        }

        public override void InitProductions()
        {
            expressionProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            possibleExpressionCommaSeparatedProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}