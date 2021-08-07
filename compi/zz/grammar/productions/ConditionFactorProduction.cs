using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ConditionFactorProduction : CompoundProduction<ConditionFactorProduction>
    {
        ExpressionProduction expressionProduction = new ExpressionProduction();
        RelationalOperatorProduction relationalOperatorProduction = new RelationalOperatorProduction();
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