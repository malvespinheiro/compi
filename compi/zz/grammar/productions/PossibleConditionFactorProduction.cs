using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleConditionFactorProduction : CompoundProduction<PossibleConditionFactorProduction>, IExecutor<PossibleConditionFactorProduction>
    {
        ConditionFactorProduction conditionFactorProduction = new ConditionFactorProduction();
        public PossibleConditionFactorProduction()
            : base(37, "PossibleConditionFactor", " . | ConditionFactor") { }
        public PossibleConditionFactorProduction Execute()
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