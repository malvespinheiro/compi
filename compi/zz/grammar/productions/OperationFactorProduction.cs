using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class OperationFactorProduction : CompoundProduction<OperationFactorProduction>
    {
        FactorProduction factorProduction = new FactorProduction();
        public OperationFactorProduction()
            : base(30, "OperationFactor", "\"*\" | \"/\" | \"%\"") { }
        public OperationFactorProduction Execute()
        {
            if (lookingAheadToken.Kind != TokenEnum.TIMES && lookingAheadToken.Kind != TokenEnum.SLASH && lookingAheadToken.Kind != TokenEnum.REM)
            {
                errorHandler.ThrowParserError(ErrorMessages.factorOperatorExpected);
            }
            if (lookingAheadToken.Kind == TokenEnum.TIMES)
            {
                Check(TokenEnum.TIMES);
            }
            else
            {
                if (lookingAheadToken.Kind == TokenEnum.SLASH)
                {
                    Check(TokenEnum.SLASH);
                }
                else
                {
                    if (lookingAheadToken.Kind == TokenEnum.REM)
                    {
                        Check(TokenEnum.REM);
                    }
                    else
                    {
                        errorHandler.ThrowParserError(ErrorMessages.termOperatorExpected);
                    }
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