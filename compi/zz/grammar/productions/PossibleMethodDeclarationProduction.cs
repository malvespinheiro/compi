using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleMethodDeclarationProduction : CompoundProduction<PossibleMethodDeclarationProduction>, IExecutor<PossibleMethodDeclarationProduction>
    {
        private readonly MethodDeclarationProduction methodDeclarationProduction = new MethodDeclarationProduction();
        public PossibleMethodDeclarationProduction()
            : base(9, "PossibleMethodDeclaration", " . | MethodDeclaration PossibleMethodDeclaration") { }
        public override void InitProductions()
        {
            this.methodDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public PossibleMethodDeclarationProduction Execute()
        {
            if (methodDeclarationProduction.ValidBegin(lookingAheadToken.Kind))
            {
                methodDeclarationProduction.Execute();
                Execute();
            }
            return this;
        }
    }
}