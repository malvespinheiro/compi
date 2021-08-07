using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class RestOfStatementProduction : CompoundProduction<RestOfStatementProduction>
    {
        ExpressionProduction expressionProduction = new ExpressionProduction();
        PosibleParamsSendProduction posibleParamsSendProduction = new PosibleParamsSendProduction();
        public override RestOfStatementProduction Execute()
        {
            switch (lookingAheadToken.Kind)
            {
                case TokenEnum.ASSIGN: 
                    {
                        Check(TokenEnum.ASSIGN);
                        expressionProduction.Execute();
                        Check(TokenEnum.SEMICOLON);
                        break;
                    }
                case TokenEnum.LPAR: 
                    {
                        Check(TokenEnum.LPAR);
                        posibleParamsSendProduction.Execute();
                        Check(TokenEnum.RPAR);
                        break;
                    }
                case TokenEnum.PLUSPLUS:
                    {
                        Check(TokenEnum.PLUSPLUS);
                        break;
                    }
                case TokenEnum.MINUSMINUS:
                    {
                        Check(TokenEnum.MINUSMINUS);
                        break;
                    }
            }
            return this;
        }
        public override void InitProductions()
        {
            expressionProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            posibleParamsSendProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}