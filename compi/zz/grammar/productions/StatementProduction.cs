using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class StatementProduction : CompoundProduction<StatementProduction>
    {

        private readonly RestOfStatementProduction restOfStatementProduction = new RestOfStatementProduction();
        private readonly PosibleElseProduction posibleElseProduction = new PosibleElseProduction();
        private readonly BlockProduction blockProduction = new BlockProduction();
        private readonly ExpressionProduction expressionProduction = new ExpressionProduction();
        private readonly ConditionProduction conditionProduction = new ConditionProduction();
        private readonly StringOrExpressionProduction stringOrExpressionProduction = new StringOrExpressionProduction();

        public override StatementProduction Execute()
        {
            if (!IsValidStatementBegining(lookingAheadToken.Kind))
            {
                errorHandler.ThrowParserError(ErrorMessages.statementExpected);
            }

            switch (lookingAheadToken.Kind)
            {
                case TokenEnum.IDENT:
                    {
                        Check(TokenEnum.IDENT);
                        restOfStatementProduction.Execute();
                        Check(TokenEnum.COMMA);
                        break;
                    }
                case TokenEnum.IF:
                    {
                        Check(TokenEnum.IF);
                        Check(TokenEnum.LPAR);
                        conditionProduction.Execute();
                        Check(TokenEnum.RPAR);
                        Execute();
                        posibleElseProduction.Execute();
                        break;
                    }
                case TokenEnum.WHILE:
                    {
                        Check(TokenEnum.WHILE);
                        Check(TokenEnum.LPAR);
                        conditionProduction.Execute();
                        Check(TokenEnum.RPAR);
                        blockProduction.Execute();
                        break;
                    }
                case TokenEnum.BREAK:
                    {
                        Check(TokenEnum.BREAK);
                        Check(TokenEnum.SEMICOLON);
                        break;
                    }
                case TokenEnum.RETURN:
                    {
                        Check(TokenEnum.RETURN);
                        if (expressionProduction.IsValidExpressionBegining(lookingAheadToken.Kind))
                            expressionProduction.Execute();
                        Check(TokenEnum.SEMICOLON);
                        break;
                    }
                case TokenEnum.READ:
                    {
                        Check(TokenEnum.READ);
                        Check(TokenEnum.LPAR);
                        if (lookingAheadToken.Kind == TokenEnum.IDENT)
                            Check(TokenEnum.IDENT);
                        Check(TokenEnum.RPAR);
                        Check(TokenEnum.SEMICOLON);
                        break;
                    }
                case TokenEnum.WRITE:
                    {
                        Check(TokenEnum.WRITELN);
                        Check(TokenEnum.LPAR);
                        expressionProduction.Execute();
                        if (lookingAheadToken.Kind == TokenEnum.COMMA)
                        {
                            Check(TokenEnum.COMMA);
                            expressionProduction.Execute();
                        }
                        Check(TokenEnum.RPAR);
                        Check(TokenEnum.SEMICOLON);
                        break;
                    }
                case TokenEnum.WRITELN:
                    {
                        Check(TokenEnum.WRITELN);
                        Check(TokenEnum.LPAR);
                        stringOrExpressionProduction.Execute();
                        Check(TokenEnum.RPAR);
                        Check(TokenEnum.SEMICOLON);
                        break;
                    }
                case TokenEnum.LBRACE:
                    {
                        blockProduction.Execute();
                        break;
                    }
                case TokenEnum.SEMICOLON:
                    {
                        Check(TokenEnum.SEMICOLON);
                        break;
                    }
                default:
                    errorHandler.ThrowParserError(ErrorMessages.invalidStatement);
                    break;
            }
            return this;
        }
        private bool IsValidStatementBegining(TokenEnum tokenKind)
        {
            if (tokenKind == TokenEnum.EOF)
                return false;
            if (tokenKind == TokenEnum.IDENT)
                return true;
            if (tokenKind == TokenEnum.IF)
                return true;
            if (tokenKind == TokenEnum.WHILE)
                return true;
            if (tokenKind == TokenEnum.BREAK)
                return true;
            if (tokenKind == TokenEnum.RETURN)
                return true;
            if (tokenKind == TokenEnum.READ)
                return true;
            if (tokenKind == TokenEnum.WRITE)
                return true;
            if (tokenKind == TokenEnum.WRITELN)
                return true;
            if (tokenKind == TokenEnum.LBRACE)
                return true;
            if (tokenKind == TokenEnum.SEMICOLON)
                return true;

            return false;
        }
        public override void InitProductions()
        {
            restOfStatementProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            posibleElseProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            blockProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            stringOrExpressionProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            conditionProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            expressionProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}