using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class FactorProduction : CompoundProduction<FactorProduction>
    {
        PosibleMinusProduction posibleMinusProduction = new PosibleMinusProduction();
        public override FactorProduction Execute()
        {
            Factor(out item);
            if (la == Token.TIMES || la == Token.SLASH || la == Token.REM)
            {
                switch (la)
                {
                    case Token.TIMES:
                        {
                            Check(Token.TIMES);
                            break;
                        }
                    case Token.SLASH:
                        {
                            Check(Token.SLASH);
                            break;
                        }
                    case Token.REM:
                        {
                            Check(Token.REM);
                            break;
                        }
                    default:
                        {
                            Errors.Error(ErrorStrings.MUL_OP);
                            break;
                        }
                }
                Factor(out itemSig);
                Execute();
            }
            return this;
        }
        public override void InitProductions()
        {
            posibleMinusProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
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