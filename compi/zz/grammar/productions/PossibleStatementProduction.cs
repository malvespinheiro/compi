using unsj.fcefn.compiladores.compi.basis;
namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleStatementProduction : CompoundProduction<PossibleStatementProduction>
    {
        private readonly StatementProduction statementProduction = new StatementProduction();
        public PossibleStatementProduction()
            : base(16, "PossibleStatement", " . | Statement PossibleStatement") { }
        public override PossibleStatementProduction Execute()
        {
            if (statementProduction.ValidBegin(lookingAheadToken.Kind))
            {
                statementProduction.Execute();
            }
            return this;
        }
        public override void InitProductions()
        {
            statementProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}