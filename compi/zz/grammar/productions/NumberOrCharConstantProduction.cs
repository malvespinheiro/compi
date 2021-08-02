using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class NumberOrCharConstantProduction : BaseProduction<NumberOrCharConstantProduction>
    {
        BaseStruct type;
        BaseSymbol constant;

        public NumberOrCharConstantProduction SetAttributes(BaseStruct type, BaseSymbol constant)
        {
            this.type = type;
            this.constant = constant;
            return this;
        }
        public override NumberOrCharConstantProduction Execute()
        {
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
            return this;
        }
    }
}