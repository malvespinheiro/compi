using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class MethodDeclarationProduction : CompoundAndCheckedProduction<MethodDeclarationProduction>
    {
        private readonly TypeOrVoidProduction typeOrVoidProduction = new TypeOrVoidProduction();
        private readonly ParamsDeclarationProduction paramsDeclarationProduction = new ParamsDeclarationProduction();
        private readonly PossibleVariableDeclarationProduction possibleVariableDeclarationProduction  = new PossibleVariableDeclarationProduction();
        private readonly BlockProduction blockProduction = new BlockProduction();
        public MethodDeclarationProduction()
            : base(10, "MethodDeclaration", "TypeOrVoid  ident \"(\" ParamsDeclaration \")\" PossibleVariableDeclaration Block") { }
        public override MethodDeclarationProduction Execute()
        {

            //TODO: Obtener el tipo del typeOrVoid
            typeOrVoidProduction.Execute();
            Check(TokenEnum.IDENT);
            
            BaseSymbol currentMethod = symbolTable.Insert(SymbolKind.Method, currentToken.StringRepresentation, type);
            symbolTable.OpenScope();

            Check(TokenEnum.LPAR);
            paramsDeclarationProduction.Execute();
            Check(TokenEnum.RPAR);
            possibleVariableDeclarationProduction.Execute();
            blockProduction.Execute();

            symbolTable.CloseScope(ref currentMethod);
            return this;
        }
        public override void InitProductions()
        {
            typeOrVoidProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            paramsDeclarationProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            possibleVariableDeclarationProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            blockProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
        public override bool ValidBegin(TokenEnum tokenExpected)
        {
            return typeOrVoidProduction.ValidBegin(tokenExpected);
        }
    }
}