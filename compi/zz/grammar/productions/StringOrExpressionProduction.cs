using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class StringOrExpressionProduction : CompoundProduction<StringOrExpressionProduction>, IExecutor<StringOrExpressionProduction>
    {
        ExpressionProduction expressionProduction = new ExpressionProduction();
        public StringOrExpressionProduction()
            : base(32, "StringOrExpression", "string | Expression") { }
        public StringOrExpressionProduction Execute()
        {
            if (expressionProduction.ValidBegin(lookingAheadToken.Kind))
            {
                expressionProduction.Execute();
            }
            else
            {
                Check(TokenEnum.STRINGCONSTANT);
            }
            return this;
        }
        public override void InitProductions()
        {
            expressionProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
       
    }
}