using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleElseProduction : CompoundProduction<PossibleElseProduction>
    {
        private readonly StatementProduction statementProduction = new StatementProduction();

        public override void InitProductions()
        {
            statementProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
        public override PossibleElseProduction Execute()
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