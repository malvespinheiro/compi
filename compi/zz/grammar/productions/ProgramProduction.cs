using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ProgramProduction : CompoundProduction<ProgramProduction>, IExecutor<VariableDeclarationProduction>
    {
        private readonly PossibleDeclarationProduction possibleDeclarationProduction = new PossibleDeclarationProduction();
        private readonly PossibleMethodDeclarationProduction possibleMethodDeclarationProduction = new PossibleMethodDeclarationProduction();
        public ProgramProduction()
            : base(0, "Program", "\"program \" ident PossibleDeclaration \"{\" PossibleMethodDeclaration \"}\"") { }
        public override void InitProductions()
        {
            this.possibleDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            this.possibleMethodDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public ProgramProduction Execute()
        {
            Check(TokenEnum.PROGRAM);
            Check(TokenEnum.IDENT);

            BaseSymbol progamSymbol = symbolTable.Insert(SymbolKind.Program, currentToken.StringRepresentation, symbolTable.noType);
            symbolTable.OpenScope();
            
            possibleDeclarationProduction.Execute();
            Check(TokenEnum.LBRACE);
            possibleMethodDeclarationProduction.Execute();
            Check(TokenEnum.RBRACE);

            symbolTable.CloseScope(ref progamSymbol);

            return this;
        }
    }
}