using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleMethodDeclarationProduction : CompoundProduction<PossibleMethodDeclarationProduction>
    {
        private readonly MethodDeclarationProduction methodDeclarationProduction = new MethodDeclarationProduction();

        public override void InitProductions()
        {
            this.methodDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public override PossibleMethodDeclarationProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.IDENT || lookingAheadToken.Kind == TokenEnum.VOID)
            {
                methodDeclarationProduction.Execute();
                Execute();
            }
            return this;
        }
    }
}