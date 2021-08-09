using unsj.fcefn.compiladores.compi.basis;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ConditionFactorProduction : CompoundProduction<ConditionFactorProduction>
    {
        ExpressionProduction expressionProduction = new ExpressionProduction();
        RelationalOperatorProduction relationalOperatorProduction = new RelationalOperatorProduction();
        public ConditionFactorProduction()
            : base(36, "ConditionFactor", "Expression RelationalOperator Expression") { }
        public override ConditionFactorProduction Execute()
        {
            expressionProduction.Execute();
            relationalOperatorProduction.Execute();
            expressionProduction.Execute();
            return this;
        }
        public override void InitProductions()
        {
            expressionProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            relationalOperatorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}