using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleMethodDeclarationProduction : CompoundProduction<PosibleMethodDeclarationProduction>
    {
        private readonly MethodDeclarationProduction methodDeclarationProduction = new MethodDeclarationProduction();

        private SymbolKind symbolKind;

        public PosibleMethodDeclarationProduction SetAttributes(SymbolKind symbolKind)
        {
            this.symbolKind = symbolKind;
            return this;
        }

        public override void InitProductions()
        {
            this.methodDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public override PosibleMethodDeclarationProduction Execute()
        {
            if ((lookingAheadToken.Kind == TokenEnum.IDENT || lookingAheadToken.Kind == TokenEnum.VOID) && lookingAheadToken.Kind != TokenEnum.EOF)
            {
                methodDeclarationProduction.Execute();
                Execute();
            }
            return this;
        }
    }
}