using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleElseProduction : CompoundProduction<PossibleElseProduction>, IExecutor<PossibleElseProduction>
    {
        private readonly StatementProduction statementProduction = new StatementProduction();
        public PossibleElseProduction()
            : base(31, "PossibleElse", " . | \"else\" Statement") { }
        public override void InitProductions()
        {
            statementProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
        public PossibleElseProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.ELSE)
            {
                Check(TokenEnum.ELSE);
                statementProduction.Execute();
            }
            return this;
        }
    }
}