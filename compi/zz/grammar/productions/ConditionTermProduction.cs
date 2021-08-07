using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ConditionTermProduction : CompoundProduction<ConditionTermProduction>
    {
        ConditionFactorProduction conditionFactorProduction = new ConditionFactorProduction();
        PosibleConditionFactorProduction posibleConditionFactorProduction = new PosibleConditionFactorProduction();
        public override ConditionTermProduction Execute()
        {
            conditionFactorProduction.Execute();
            posibleConditionFactorProduction.Execute();
            return this;
        }
        public override void InitProductions()
        {
            conditionFactorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            posibleConditionFactorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
       
    }
}