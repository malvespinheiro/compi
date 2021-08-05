using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleStatementProduction : CompoundProduction<PosibleStatementProduction>
    {

        private readonly TypeProduction typeProduction = new TypeProduction();
        private readonly StatementProduction statementProduction = new StatementProduction();

        public override PosibleStatementProduction Execute()
        {
            if (IsValidStatementBegining(lookingAheadToken.Kind))
            {
                statementProduction.Execute();
                Execute();
            }
            return this;
        }

        private bool IsValidStatementBegining(TokenEnum tokenKind)
        {
            if(tokenKind == TokenEnum.EOF)
                return false;
            if(tokenKind == TokenEnum.IDENT)
                return true;
            if(tokenKind == TokenEnum.IF)
                return true;
            if(tokenKind == TokenEnum.WHILE)
                return true;
            if(tokenKind == TokenEnum.BREAK)
                return true;
            if(tokenKind == TokenEnum.RETURN)
                return true;
            if(tokenKind == TokenEnum.READ)
                return true;
            if(tokenKind == TokenEnum.WRITE)
                return true;
            if(tokenKind == TokenEnum.WRITELN)
                return true;
            if(tokenKind == TokenEnum.LBRACE)
                return true;
            if(tokenKind == TokenEnum.SEMICOLON)
                return true;

            return false;
        }

        public override void InitProductions()
        {
            typeProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            statementProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}