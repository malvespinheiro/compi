using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleDeclarationProduction : CompoundProduction<PosibleDeclarationProduction>
    {
        private readonly DeclarationProduction declarationProduction = new DeclarationProduction();

        private SymbolKind symbolKind;

        public PosibleDeclarationProduction SetAttributes(SymbolKind symbolKind)
        {
            this.symbolKind = symbolKind;
            return this;
        }

        public override void InitProductions()
        {
            this.declarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public override PosibleDeclarationProduction Execute()
        {
            if (lookingAheadToken.Kind != TokenEnum.LBRACE && lookingAheadToken.Kind != TokenEnum.EOF)
            {
                declarationProduction.SetAttributes(symbolKind).Execute();
                Execute();
            }
            return this;
        }
    }
}