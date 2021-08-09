using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ConstantDeclarationProduction : CompoundProduction<ConstantDeclarationProduction>
    {
        private readonly TypedIdentifierProduction typedIdentifierProduction = new TypedIdentifierProduction();
        private readonly NumberOrCharConstantProduction numberOrCharConstantProduction = new NumberOrCharConstantProduction();
        public ConstantDeclarationProduction()
            : base(3, "ConstantDeclaration", "\"const\" TypedIdentifier \"=\" NumberOrCharConst \";\"") { }
        public override ConstantDeclarationProduction Execute()
        {
            Check(TokenEnum.CONST);
            typedIdentifierProduction.Execute();
            Check(TokenEnum.ASSIGN);
            numberOrCharConstantProduction.Execute();
            Check(TokenEnum.SEMICOLON);
            return this;
        }

        public override void InitProductions()
        {
            typedIdentifierProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            numberOrCharConstantProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}