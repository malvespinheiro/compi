using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class OperationTermProduction : CompoundProduction<OperationTermProduction>
    {
        FactorProduction factorProduction = new FactorProduction();
        public override OperationTermProduction Execute()
        {
            if (lookingAheadToken.Kind != TokenEnum.PLUS && lookingAheadToken.Kind != TokenEnum.MINUS)
            {
                errorHandler.ThrowParserError(ErrorMessages.termOperatorExpected);
            }
            if (lookingAheadToken.Kind == TokenEnum.PLUS)
            {
                Check(TokenEnum.PLUS);
            }
            else
            {
                if (lookingAheadToken.Kind == TokenEnum.MINUS)
                {
                    Check(TokenEnum.MINUS);
                }
                else
                {
                    errorHandler.ThrowParserError(ErrorMessages.termOperatorExpected);
                }
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