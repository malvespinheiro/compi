using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class RestOfStatementProduction : CompoundProduction<RestOfStatementProduction>
    {
        public override RestOfStatementProduction Execute()
        {
            switch (lookingAheadToken.Kind)
            {
                case TokenEnum.ASSIGN: 
                    {
                        Check(TokenEnum.ASSIGN);
                        Expr(out itemDer, nexpr);
                        break;
                    }
                case TokenEnum.LPAR: 
                    {
                        Check(TokenEnum.LPAR);
                        if (lookingAheadToken.Kind == TokenEnum.MINUS || lookingAheadToken.Kind == TokenEnum.IDENT ||
                            lookingAheadToken.Kind == TokenEnum.NUMBER || lookingAheadToken.Kind == TokenEnum.CHARCONST ||
                            lookingAheadToken.Kind == TokenEnum.NEW || lookingAheadToken.Kind == TokenEnum.LPAR)
                            ActPars();
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

        }
    }
}