using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ExpressionProduction : CompoundAndCheckedProduction<ExpressionProduction>, IExecutor<ExpressionProduction>
    {
        PossibleMinusProduction possibleMinusProduction = new PossibleMinusProduction();
        TermProduction termProduction = new TermProduction();
        PossibleOperationTermProduction possibleOperationTermProduction = new PossibleOperationTermProduction();
        public ExpressionProduction()
            : base(18, "Expression", "PossibleMinus Term PossibleOperationTerm") { }
        public ExpressionProduction Execute()
        {
            possibleMinusProduction.Execute();
            termProduction.Execute();
            possibleOperationTermProduction.Execute();
            return this;
        }
        public override void InitProductions()
        {
            possibleMinusProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            termProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            possibleOperationTermProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
        public override bool ValidBegin(TokenEnum tokenExpected)
        {
            return possibleMinusProduction.ValidBegin(tokenExpected) || termProduction.ValidBegin(tokenExpected);
        }
    }
}