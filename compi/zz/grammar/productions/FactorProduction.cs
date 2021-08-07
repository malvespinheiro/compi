using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class FactorProduction : CompoundProduction<FactorProduction>
    {
        PosibleRestOfMethodCallProduction posibleRestOfMethodCallProduction = new PosibleRestOfMethodCallProduction();
        ExpressionProduction expressionProduction = new ExpressionProduction();
        public override FactorProduction Execute()
        {
            switch (lookingAheadToken.Kind)
            {
                case TokenEnum.IDENT:
                    {
                        Check(TokenEnum.IDENT);
                        posibleRestOfMethodCallProduction.Execute();
                        break;
                    }
                case TokenEnum.NUMBER:
                    {
                        Check(TokenEnum.NUMBER);
                        break;
                    }
                case TokenEnum.LPAR:
                    {
                        Check(TokenEnum.LPAR);
                        expressionProduction.Execute();
                        Check(TokenEnum.RPAR);
                        break;
                    }
                default:
                    {
                        errorHandler.ThrowParserError(ErrorMessages.invalidFactor);
                        break;
                    }
            }
            return this;
        }
        public override void InitProductions()
        {
            posibleRestOfMethodCallProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            expressionProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}