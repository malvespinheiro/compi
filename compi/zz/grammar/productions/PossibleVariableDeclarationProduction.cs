using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleVariableDeclarationProduction : CompoundProduction<PossibleVariableDeclarationProduction>
    {
        private readonly VariableDeclarationProduction variableDeclarationProduction = new VariableDeclarationProduction();

        public override void InitProductions()
        {
            variableDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public override PossibleVariableDeclarationProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.IDENT)
            {
                variableDeclarationProduction.Execute();
                Execute();
            }
            return this;
        }
    }
}