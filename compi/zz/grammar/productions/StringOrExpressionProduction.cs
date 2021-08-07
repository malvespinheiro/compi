using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class StringOrExpressionProduction : CompoundProduction<StringOrExpressionProduction>
    {
        ExpressionProduction expressionProduction = new ExpressionProduction();
        public override StringOrExpressionProduction Execute()
        {
            if (expressionProduction.ValidBegin(lookingAheadToken.Kind))
            {
                expressionProduction.Execute();
            }
            else
            {
                Check(TokenEnum.STRINGCONST);
            }
            return this;
        }
        public override void InitProductions()
        {
            expressionProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
       
    }
}