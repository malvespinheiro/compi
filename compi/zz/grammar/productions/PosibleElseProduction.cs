using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleElseProduction : CompoundProduction<PosibleElseProduction>
    {
        private readonly StatementProduction statementProduction = new StatementProduction();

        public override void InitProductions()
        {
            statementProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
        public override PosibleElseProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.ELSE)
            {
                statementProduction.Execute();
            }
            return this;
        }
    }
}