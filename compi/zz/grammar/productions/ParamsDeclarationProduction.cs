using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ParamsDeclarationProduction : CompoundProduction<ParamsDeclarationProduction>
    {
        private readonly TypedIdentifierProduction typedIdentifierProduction= new TypedIdentifierProduction();
        private readonly PosibleTypedIdentifiersCommaSeparatedProduction posibleTypedIdentifiersCommaSeparatedProduction = new PosibleTypedIdentifiersCommaSeparatedProduction();

        private SymbolKind symbolKind;

        public ParamsDeclarationProduction SetAttributes(SymbolKind symbolKind)
        {
            this.symbolKind = symbolKind;
            return this;
        }

        public override void InitProductions()
        {
            typedIdentifierProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            posibleTypedIdentifiersCommaSeparatedProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public override ParamsDeclarationProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.IDENT)
            {
                typedIdentifierProduction.Execute();
                posibleTypedIdentifiersCommaSeparatedProduction.Execute();
            }
            return this;
        }
    }
}