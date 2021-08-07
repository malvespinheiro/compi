using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleOperationTermProduction : CompoundProduction<PosibleOperationTermProduction>
    {
        OperationTermProduction operationTermProduction = new OperationTermProduction();
        TermProduction termProduction = new TermProduction();
        public override PosibleOperationTermProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.PLUS || lookingAheadToken.Kind == TokenEnum.MINUS)
            {
                operationTermProduction.Execute();
                termProduction.Execute();
                Execute();
            }
            return this;
        }
        public override void InitProductions()
        {
            operationTermProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            termProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }

        private bool IsValidTermBegining(TokenEnum tokenKind)
        {
            if (tokenKind == TokenEnum.IDENT)
                return true;
            if (tokenKind == TokenEnum.NUMBER)
                return true;
            if(tokenKind == TokenEnum.CHARCONST)
                return true;
            if(tokenKind == TokenEnum.LPAR)
                return true;

            return false;
        }
    }
}