using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class RelationalOperatorProduction : BaseProduction<RelationalOperatorProduction>
    {
        public override RelationalOperatorProduction Execute()
        {
            switch (lookingAheadToken.Kind)
            {
                case TokenEnum.EQ:
                    Check(TokenEnum.EQ);
                    break;
                case TokenEnum.NE:
                    Check(TokenEnum.NE);
                    break;
                case TokenEnum.GT:
                    Check(TokenEnum.GT);
                    break;
                case TokenEnum.GE:
                    Check(TokenEnum.GE);
                    break;
                case TokenEnum.LT:
                    Check(TokenEnum.LT);
                    break;
                case TokenEnum.LE:
                    Check(TokenEnum.LE);
                    break;
                default:
                    errorHandler.ThrowParserError(ErrorMessages.relationalOperatorExpected);
                    break;
            }
            return this;
        }
    }
}