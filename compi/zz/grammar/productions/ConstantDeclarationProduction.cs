using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ConstantDeclarationProduction : CompoundProduction<ConstantDeclarationProduction>
    {

        private readonly TypeProduction typeProduction = new TypeProduction();
        public override ConstantDeclarationProduction Execute()
        {
            Check(TokenEnum.CONST);
            BaseStruct type = typeProduction.Execute().Type;

            if (!symbolTable.IsValidConstantType(type))
            {
                errorHandler.ThrowParserError(ErrorMessages.invalidConstantType);
            }

            Check(TokenEnum.IDENT);
            BaseSymbol constant = symbolTable.Insert(SymbolKind.Const, currentToken.StringRepresentation, type);
            Check(TokenEnum.ASSIGN);
            switch (lookingAheadToken.Kind)
            {
                case TokenEnum.NUMBER:
                    {
                        if (!symbolTable.IsValidIntType(type))
                        {
                            errorHandler.ThrowParserError(ErrorMessages.intTypeExpected);
                        }
                        Check(TokenEnum.NUMBER);
                        constant.val = currentToken.NumericalRepresentation;
                        break;
                    }
                case TokenEnum.CHARCONST:
                    {
                        if (!symbolTable.IsValidCharType(type))
                        {
                            errorHandler.ThrowParserError(ErrorMessages.charTypeExpected);
                        }
                        Check(TokenEnum.CHARCONST);
                        constant.val = currentToken.NumericalRepresentation;
                        break;
                    }
                default:
                    {
                        errorHandler.ThrowParserError(ErrorMessages.wrongConstantDefinition);
                        break;
                    }
            }
            Check(TokenEnum.SEMICOLON);
            return this;
        }

        public override void InitProductions()
        {
            this.typeProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}