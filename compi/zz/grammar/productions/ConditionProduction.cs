using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ConditionProduction : CompoundProduction<ConditionProduction>
    {
        ConditionTermProduction conditionTermProduction = new ConditionTermProduction();
        PossibleConditionTermProduction possibleConditionTermProduction = new PossibleConditionTermProduction();
        public override ConditionProduction Execute()
        {
            conditionTermProduction.Execute();
            possibleConditionTermProduction.Execute();
            return this;
        }
        public override void InitProductions()
        {
            conditionTermProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            possibleConditionTermProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
       
    }
}