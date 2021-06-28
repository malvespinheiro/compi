using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class Program : BaseProduction<Program>
    {
        public override Program Execute()
        {
            Check(TokenEnum.CLASS);
            Check(TokenEnum.IDENT);

            Symbol prog = Tab.Insert(Symbol.Kinds.Prog, token.str, Tab.noType);
            Code.CreateMetadata(prog);
            Tab.OpenScope(prog);

            while (lookingAheadToken.Kind != TokenEnum.LBRACE && lookingAheadToken.Kind != TokenEnum.EOF)
            {
                switch (lookingAheadToken.Kind)
                {
                    case TokenEnum.CONST:
                        {
                            ConstDecl
                               ();
                            break;
                        }
                    case TokenEnum.IDENT:
                        {
                            VardDecl(Symbol.Kinds.Global);
                            break;
                        }
                    case TokenEnum.CLASS:
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

            Check(TokenEnum.LBRACE);
            while ((lookingAheadToken.Kind == TokenEnum.IDENT || lookingAheadToken.Kind == TokenEnum.VOID) && lookingAheadToken.Kind != TokenEnum.EOF)
            {
                MethodDecl(methodDeclsOpc);
            }

            Check(TokenEnum.RBRACE);


            prog.locals = Tab.topScope.locals;

            Tab.CloseScope();

            return this;
        }
    }
}