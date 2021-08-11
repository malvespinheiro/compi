using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class NumberOrCharConstantProduction : BaseProduction<NumberOrCharConstantProduction>
    {
        public NumberOrCharConstantProduction()
            : base(6, "NumberOrCharConstant", "number | charConst") { }
        public NumberOrCharConstantProduction Execute()
        {
            switch (lookingAheadToken.Kind)
            {
                case TokenEnum.NUMBER:
                    {
                        Check(TokenEnum.NUMBER);
                        break;
                    }
                case TokenEnum.CHARCONST:
                    {
                        Check(TokenEnum.CHARCONST);
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