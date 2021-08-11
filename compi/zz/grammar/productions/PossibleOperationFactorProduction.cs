using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleOperationFactorProduction : CompoundProduction<PossibleOperationFactorProduction>, IExecutor<PossibleOperationFactorProduction>
    {
        OperationFactorProduction operationFactorProduction = new OperationFactorProduction();
        FactorProduction factorProduction = new FactorProduction();
        public PossibleOperationFactorProduction()
            : base(21, "PossibleOperationFactor", " . |  OperationFactor Factor") { }
        public PossibleOperationFactorProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.TIMES || lookingAheadToken.Kind == TokenEnum.SLASH || lookingAheadToken.Kind != TokenEnum.REM)
            {
                operationFactorProduction.Execute();
                factorProduction.Execute();
                Execute();
            }
            return this;
        }
        public override void InitProductions()
        {
        operationFactorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
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