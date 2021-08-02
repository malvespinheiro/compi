using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class VariableDeclarationProduction : CompoundProduction<VariableDeclarationProduction>
    {
        private readonly TypeProduction typeProduction = new TypeProduction();
        private readonly PosibleIdentifiersProduction posibleIdentifiersProduction = new PosibleIdentifiersProduction();

        private SymbolKind symbolKind;
        public VariableDeclarationProduction SetAttributes(SymbolKind symbolKind)
        {
            this.symbolKind = symbolKind;
            return this;
        }

        public override VariableDeclarationProduction Execute()
        {
            BaseStruct type = typeProduction.Execute().Type;
            BaseSymbol variable = symbolTable.Insert(symbolKind, currentToken.StringRepresentation, type);

            Check(TokenEnum.IDENT);
            posibleIdentifiersProduction.SetAttributes(type, symbolKind).Execute();
            Check(TokenEnum.SEMICOLON);

            return this;
        }

        public override void InitProductions()
        {
            typeProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            posibleIdentifiersProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}