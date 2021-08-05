using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class VariableDeclarationProduction : CompoundProduction<VariableDeclarationProduction>
    {
        private readonly TypedIdentifierProduction typedIdentifierProduction = new TypedIdentifierProduction();
        private readonly PosibleIdentifiersCommaSeparatedProduction posibleIdentifiersCommaSeparatedProduction = new PosibleIdentifiersCommaSeparatedProduction();

        private SymbolKind symbolKind;
        public VariableDeclarationProduction SetAttributes(SymbolKind symbolKind)
        {
            this.symbolKind = symbolKind;
            return this;
        }

        public override VariableDeclarationProduction Execute()
        {
            typedIdentifierProduction.Execute();
            posibleIdentifiersCommaSeparatedProduction.Execute();
            Check(TokenEnum.SEMICOLON);
            return this;
        }

        public override void InitProductions()
        {
            typedIdentifierProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            posibleIdentifiersCommaSeparatedProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}