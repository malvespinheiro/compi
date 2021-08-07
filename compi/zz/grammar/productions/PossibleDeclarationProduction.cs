using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleDeclarationProduction : CompoundProduction<PossibleDeclarationProduction>
    {
        private readonly DeclarationProduction declarationProduction = new DeclarationProduction();
        public override void InitProductions()
        {
            this.declarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
        public override PossibleDeclarationProduction Execute()
        {
            if (declarationProduction.ValidBegin(lookingAheadToken.Kind))
            {
                declarationProduction.Execute();
                Execute();
            }
            return this;
        }
    }
}