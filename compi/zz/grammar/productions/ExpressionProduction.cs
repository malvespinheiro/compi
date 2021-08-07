using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ExpressionProduction : CompoundProduction<ExpressionProduction>
    {
        PossibleMinusProduction possibleMinusProduction = new PossibleMinusProduction();
        TermProduction termProduction = new TermProduction();
        PossibleOperationTermProduction possibleOperationTermProduction = new PossibleOperationTermProduction();
        public override ExpressionProduction Execute()
        {
            possibleMinusProduction.Execute();
            termProduction.Execute();
            possibleOperationTermProduction.Execute();
            return this;
        }
        public override void InitProductions()
        {
            possibleMinusProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            possibleOperationTermProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }

        public bool IsValidExpressionBegining(TokenEnum tokenExpected)
        {
            return termProduction.IsValidTermBegining(tokenExpected) || tokenExpected == TokenEnum.MINUS;
        }
    }
}