using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class OperationTermProduction : BaseProduction<OperationTermProduction>
    {
        public OperationTermProduction()
            : base(28, "OperationTerm", "\"+\" | \"-\"") { }
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
    }
}