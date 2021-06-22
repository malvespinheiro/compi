using text_Box_Mio.refactoring.bases.interfaces;
using text_Box_Mio.refactoring.bases;

namespace text_Box_Mio.refactoring.compiler.bases
{
    public abstract class AbstractParser:IParser
    {
        AbstractProduction rootProduction;

        public AbstractParser init()
        {
            rootProduction
        }

        public AbstractParser compile()
        {

        }


        static void Program()
        {
            Check(Token.CLASS);
            Check(Token.IDENT);
            Symbol prog = Tab.Insert(Symbol.Kinds.Prog, token.str, Tab.noType);
            Code.CreateMetadata(prog);
            Tab.OpenScope(prog);
            while (la != Token.LBRACE && la != Token.EOF)
            {
                switch (la)
                {
                    case Token.CONST:
                        {
                            ConstDecl
                               ();
                            break;
                        }
                    case Token.IDENT:
                        {
                            VardDecl(Symbol.Kinds.Global);
                            break;
                        }
                    case Token.CLASS:
                        {
                            ClassDecl();
                            break;
                        }
                    default:
                        {
                            token = laToken;
                            Errors.Error("Se esperaba Const, Tipo, Class");
                            break;
                        }
                }
            }

            Check(Token.LBRACE);
            while ((la == Token.IDENT || la == Token.VOID) && la != Token.EOF)
            {
                MethodDecl(methodDeclsOpc);
            }

            Check(Token.RBRACE);


            prog.locals = Tab.topScope.locals;

            Tab.CloseScope();
        }
    }
}