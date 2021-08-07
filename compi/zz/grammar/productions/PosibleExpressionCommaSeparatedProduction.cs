using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleExpressionCommaSeparatedProduction : CompoundProduction<PosibleExpressionCommaSeparatedProduction>
    {
        private readonly ExpressionProduction expressionProduction = new ExpressionProduction();

        public override PosibleExpressionCommaSeparatedProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.COMMA)
            {
                Check(TokenEnum.COMMA);
                expressionProduction.Execute();
                Execute();
            }
            return this;
        }

        public override void InitProductions()
        {
            expressionProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}