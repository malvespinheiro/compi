using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ExpressionProduction : CompoundProduction<ExpressionProduction>
    {
        PosibleMinusProduction posibleMinusProduction = new PosibleMinusProduction();
        TermProduction termProduction = new TermProduction();
        PosibleOperationTermProduction posibleOperationTermProduction = new PosibleOperationTermProduction();
        public override ExpressionProduction Execute()
        {
            posibleMinusProduction.Execute();
            termProduction.Execute();
            posibleOperationTermProduction.Execute();
            return this;
        }
        public override void InitProductions()
        {
            posibleMinusProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            posibleOperationTermProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }

        public bool IsValidExpressionBegining(TokenEnum tokenExpected)
        {
            return termProduction.IsValidTermBegining(tokenExpected) || tokenExpected == TokenEnum.MINUS;
        }
    }
}