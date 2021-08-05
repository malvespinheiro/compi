using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleDeclarationProduction : CompoundProduction<PosibleDeclarationProduction>
    {
        private readonly DeclarationProduction declarationProduction = new DeclarationProduction();
        public override void InitProductions()
        {
            this.declarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
        public override PosibleDeclarationProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.CONST || lookingAheadToken.Kind == TokenEnum.IDENT || lookingAheadToken.Kind == TokenEnum.CLASS)
            {
                declarationProduction.Execute();
                Execute();
            }
            return this;
        }
    }
}