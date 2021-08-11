using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ConditionTermProduction : CompoundProduction<ConditionTermProduction>, IExecutor<ConditionTermProduction>
    {
        ConditionFactorProduction conditionFactorProduction = new ConditionFactorProduction();
        PossibleConditionFactorProduction possibleConditionFactorProduction = new PossibleConditionFactorProduction();
        public ConditionTermProduction()
            : base(34, "ConditionTerm", "ConditionFactor PossibleConditionFactor") { }
        public ConditionTermProduction Execute()
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