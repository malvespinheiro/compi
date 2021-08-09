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
            : base(10, "MethodDeclaration", "TypeOrVoid  ident \"(\" ParamsDeclaration \")\" PosibleVariableDeclaration Block") { }
        public override MethodDeclarationProduction Execute()
        {
            typeOrVoidProduction.Execute();
            Check(TokenEnum.IDENT);
            Check(TokenEnum.LPAR);
            paramsDeclarationProduction.Execute();
            Check(TokenEnum.RPAR);
            possibleVariableDeclarationProduction.Execute();
            blockProduction.Execute();
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