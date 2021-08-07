using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ProgramProduction : CompoundProduction<ProgramProduction>
    {
        private readonly PossibleDeclarationProduction possibleDeclarationProduction = new PossibleDeclarationProduction();
        private readonly PossibleMethodDeclarationProduction possibleMethodDeclarationProduction = new PossibleMethodDeclarationProduction();

        public override void InitProductions()
        {
            this.possibleDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            this.possibleMethodDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public override ProgramProduction Execute()
        {
            Check(TokenEnum.CLASS);
            Check(TokenEnum.IDENT);
            possibleDeclarationProduction.Execute();
            Check(TokenEnum.LBRACE);
            possibleMethodDeclarationProduction.Execute();
            Check(TokenEnum.RBRACE);
            return this;
        }
    }
}