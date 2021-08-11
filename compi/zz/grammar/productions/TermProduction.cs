using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TermProduction : CompoundAndCheckedProduction<TermProduction>, IExecutor<TermProduction>
    {
        FactorProduction factorProduction = new FactorProduction();
        PossibleOperationFactorProduction possibleOperationFactorProduction = new PossibleOperationFactorProduction();
        public TermProduction()
            : base(21, "Term", "Factor PossibleOperationFactor") { }
        public TermProduction Execute()
        {
            if (!ValidBegin(lookingAheadToken.Kind))
            {
                errorHandler.ThrowParserError(ErrorMessages.termExpected);
            }
            factorProduction.Execute();
            possibleOperationFactorProduction.Execute();
            return this;
        }
        public override void InitProductions()
        {
            factorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            possibleOperationFactorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
        public override bool ValidBegin(TokenEnum tokenExpected)
        {
            return factorProduction.ValidBegin(tokenExpected);
        }
    }
}