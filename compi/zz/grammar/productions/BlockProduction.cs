using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class BlockProduction : CompoundProduction<BlockProduction>
    {
        private readonly PossibleStatementProduction possibleStatementProduction = new PossibleStatementProduction();
        public override BlockProduction Execute()
        {
            Check(TokenEnum.LBRACE);
            possibleStatementProduction.Execute();
            Check(TokenEnum.RBRACE);
            return this;
        }

        public override void InitProductions()
        {
            possibleStatementProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}