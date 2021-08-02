using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ProgramProduction : CompoundProduction<ProgramProduction>
    {
        private readonly PosibleDeclarationProduction posibleDeclarationProduction = new PosibleDeclarationProduction();
        private readonly PosibleMethodDeclarationProduction posibleMethodDeclarationProduction = new PosibleMethodDeclarationProduction();

        public override void InitProductions()
        {
            this.posibleDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            this.posibleMethodDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public override ProgramProduction Execute()
        {
            Check(TokenEnum.CLASS);
            Check(TokenEnum.IDENT);

            BaseSymbol progamSymbol = symbolTable.Insert(SymbolKind.Prog, currentToken.StringRepresentation, symbolTable.noType);
            symbolTable.OpenScope(progamSymbol);

            posibleDeclarationProduction.SetAttributes(SymbolKind.Global).Execute();

            Check(TokenEnum.LBRACE);
            posibleMethodDeclarationProduction.Execute();
            Check(TokenEnum.RBRACE);

            progamSymbol.Locals = symbolTable.TopScope.locals;
            symbolTable.CloseScope();

            return this;
        }
    }
}