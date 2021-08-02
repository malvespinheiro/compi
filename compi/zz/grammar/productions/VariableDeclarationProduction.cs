using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class VariableDeclarationProduction : CompoundProduction<VariableDeclarationProduction>
    {
        private readonly TypeProduction typeProduction = new TypeProduction();
        private readonly IdentifiersOpcProduction identifiersOpcProduction  = new IdentifiersOpcProduction();

        private SymbolKind symbolKind;
        public VariableDeclarationProduction SetAttributes(SymbolKind symbolKind)
        {
            this.symbolKind = symbolKind;
            return this;
        }

        public override VariableDeclarationProduction Execute()
        {
            BaseStruct type = typeProduction.Execute().Type;
            Check(TokenEnum.IDENT);
            BaseSymbol variable = symbolTable.Insert(symbolKind, currentToken.StringRepresentation, type);
            //Code.CreateMetadata(variable); 
            //TODO: Ver como hacer para que tome los atributos de entrada a la produccion
            identifiersOpcProduction.SetAttributes(type, symbolKind).Execute();
            Check(TokenEnum.SEMICOLON);
            return this;
        }

        public override void InitProductions()
        {
            typeProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            identifiersOpcProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}