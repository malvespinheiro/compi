using unsj.fcefn.compiladores.compi.basis;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ConditionTermProduction : CompoundProduction<ConditionTermProduction>
    {
        ConditionFactorProduction conditionFactorProduction = new ConditionFactorProduction();
        PossibleConditionFactorProduction possibleConditionFactorProduction = new PossibleConditionFactorProduction();
        public ConditionTermProduction()
            : base(34, "ConditionTerm", "ConditionFactor PossibleConditionFactor") { }
        public override ConditionTermProduction Execute()
        {
            conditionFactorProduction.Execute();
            possibleConditionFactorProduction.Execute();
            return this;
        }
        public override void InitProductions()
        {
            conditionFactorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            possibleConditionFactorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}