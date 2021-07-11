using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ProgramProduction : BaseProduction<ProgramProduction>
    {
        private readonly ConstantDeclarationProduction constantDeclarationProduction = new ConstantDeclarationProduction();
        private readonly ClassDeclarationProduction classDeclarationProduction = new ClassDeclarationProduction();
        private readonly VariableDeclarationProduction variableDeclarationProduction = new VariableDeclarationProduction();
        private readonly MethodDeclarationProduction methodDeclarationProduction = new MethodDeclarationProduction();

        public override void InitProductions()
        {
            this.constantDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken);
            this.classDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken);
            this.variableDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken);
            this.methodDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken);

        }
        public override ProgramProduction Execute()
        {
            Check(TokenEnum.CLASS);
            Check(TokenEnum.IDENT);

            BaseSymbol progamSymbol = symbolTable.Insert(SymbolKind.Prog, currentToken.StringRepresentation, symbolTable.noType);
            // Code.CreateMetadata(prog);
            symbolTable.OpenScope(progamSymbol);

            while (lookingAheadToken.Kind != TokenEnum.LBRACE && lookingAheadToken.Kind != TokenEnum.EOF)
            {
                switch (lookingAheadToken.Kind)
                {
                    case TokenEnum.CONST:
                        {
                            constantDeclarationProduction.Execute();
                            break;
                        }
                    case TokenEnum.IDENT:
                        {
                            variableDeclarationProduction.Execute();
                            break;
                        }
                    case TokenEnum.CLASS:
                        {
                            classDeclarationProduction.Execute();
                            break;
                        }
                    default:
                        {
                            Scan();
                            //TODO: Error de parseo: Se esperaba Const, tipo, class
                            break;
                        }
                }
            }

            Check(TokenEnum.LBRACE);
            while ((lookingAheadToken.Kind == TokenEnum.IDENT || lookingAheadToken.Kind == TokenEnum.VOID) && lookingAheadToken.Kind != TokenEnum.EOF)
            {
                methodDeclarationProduction.Execute();
            }

            Check(TokenEnum.RBRACE);


            progamSymbol.Locals = symbolTable.TopScope.Locals;

            symbolTable.CloseScope();

            return this;
        }
    }
}