using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleExpressionCommaSeparatedProduction : CompoundProduction<PossibleExpressionCommaSeparatedProduction>, IExecutor<PossibleExpressionCommaSeparatedProduction>
    {
        private readonly ExpressionProduction expressionProduction = new ExpressionProduction();
        public PossibleExpressionCommaSeparatedProduction()
            : base(26, "PossibleExpressionCommaSeparated", " . | \",\" Expression") { }
        public PossibleExpressionCommaSeparatedProduction Execute()
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