using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleConditionTermProduction : CompoundProduction<PosibleConditionTermProduction>
    {
        ConditionTermProduction conditionTermProduction = new ConditionTermProduction();
        public override PosibleConditionTermProduction Execute()
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