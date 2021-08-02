using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class MethodDeclarationProduction : CompoundProduction<MethodDeclarationProduction>
    {
        private readonly TypeOrVoidProduction typeOrVoidProduction = new TypeOrVoidProduction();
        private readonly VariableDeclarationProduction variableDeclarationProduction = new VariableDeclarationProduction();
        private readonly FormParsProduction formParsProduction= new FormParsProduction();
        private readonly BlockProduction blockProduction= new BlockProduction();

        BaseSymbol currentMethod;
        public override MethodDeclarationProduction Execute()
        {
            BaseStruct type = new BaseStruct(StructKind.None);

            typeOrVoidProduction.SetAttributes(type).Execute();
            Check(TokenEnum.IDENT);
            Check(TokenEnum.LPAR);

            currentMethod = symbolTable.Insert(SymbolKind.Meth, currentToken.StringRepresentation, type);
            symbolTable.OpenScope(currentMethod);

            if (lookingAheadToken.Kind == TokenEnum.IDENT)
            {
                formParsProduction.Execute();
                Check(TokenEnum.RPAR);
            }
            else
            {
                Check(TokenEnum.RPAR);
            }

            while (lookingAheadToken.Kind != TokenEnum.LBRACE && lookingAheadToken.Kind != TokenEnum.EOF)
            {
                if (lookingAheadToken.Kind == TokenEnum.IDENT)
                {
                    variableDeclarationProduction.SetAttributes(SymbolKind.Local).Execute();
                }
                else
                {
                    errorHandler.ThrowParserError(ErrorMessages.variablesDeclarationExpected);
                }
            }

            blockProduction.Execute();

            symbolTable.CloseScope();

            return this;
        }

        public override void InitProductions()
        {
            typeOrVoidProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            variableDeclarationProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            formParsProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            blockProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}