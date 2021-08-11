using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleVariableDeclarationProduction : CompoundProduction<PossibleVariableDeclarationProduction>, IExecutor<PossibleVariableDeclarationProduction>
    {
        private readonly VariableDeclarationProduction variableDeclarationProduction = new VariableDeclarationProduction();
        public PossibleVariableDeclarationProduction()
            : base(14, "PossibleVariableDeclaration", " . | VariableDeclaration PossibleVariableDeclaration") { }

        public override void InitProductions()
        {
            variableDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
        public PossibleVariableDeclarationProduction Execute()
        {
            if (variableDeclarationProduction.ValidBegin(lookingAheadToken.Kind))
            {
                variableDeclarationProduction.Execute();
                Execute();
            }
            return this;
        }
    }
}