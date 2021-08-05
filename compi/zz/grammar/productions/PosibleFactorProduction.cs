using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleFactorProduction : CompoundProduction<PosibleFactorProduction>
    {
        FactorProduction factorProduction = new FactorProduction();
        public override PosibleFactorProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.TIMES || lookingAheadToken.Kind == TokenEnum.SLASH || lookingAheadToken.Kind == TokenEnum.REM)
            {
                switch (lookingAheadToken.Kind)
                {
                    case TokenEnum.TIMES:
                        {
                            Check(TokenEnum.TIMES);
                            break;
                        }
                    case TokenEnum.SLASH:
                        {
                            Check(TokenEnum.SLASH);
                            break;
                        }
                    case TokenEnum.REM:
                        {
                            Check(TokenEnum.REM);
                            break;
                        }
                    default:
                        {
                            errorHandler.ThrowParserError(ErrorMessages.termOperatorExpected);
                            break;
                        }
                }
                factorProduction.Execute();
                Execute();
            }
            return this;
        }
        public override void InitProductions()
        {
            factorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }

        private bool IsValidTermBegining(TokenEnum tokenKind)
        {
            if (tokenKind == TokenEnum.IDENT)
                return true;
            if (tokenKind == TokenEnum.NUMBER)
                return true;
            if(tokenKind == TokenEnum.CHARCONST)
                return true;
            if(tokenKind == TokenEnum.NEW)
                return true;
            if(tokenKind == TokenEnum.LPAR)
                return true;

            return false;
        }
    }
}