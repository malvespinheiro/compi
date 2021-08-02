using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class StatementProduction : CompoundProduction<StatementProduction>
    {

        private readonly TypeProduction typeProduction = new TypeProduction();

        public override StatementProduction Execute()
        {
            if (la == Token.IDENT)
            {
                Designator(out itemIzq); //val   en statement
                switch (la)
                {
                    case Token.ASSIGN:  //asignacion  Designator = ....
                        {
                            Check(Token.ASSIGN);
                            Expr(out itemDer, nexpr);
                            break;
                        }
                    case Token.LPAR: 
                        {
                            Check(Token.LPAR);
                            if (la == Token.MINUS || la == Token.IDENT ||
                                la == Token.NUMBER || la == Token.CHARCONST ||
                                la == Token.NEW || la == Token.LPAR)
                                ActPars();
                            Check(Token.RPAR);
                            break;
                        }
                    case Token.PPLUS:
                        {
                            Check(Token.PPLUS);
                            break;
                        }
                    case Token.MMINUS:
                        {
                            Check(Token.MMINUS);
                            break;
                        }
                }
                Check(Token.SEMICOLON);
            }
            else
            {
                switch (la)
                {
                    case Token.IF:
                        Check(Token.IF);
                        Check(Token.LPAR);
                        Condition(out x);
                        Check(Token.RPAR);
                        Statement(nstatement);
                        if (la == Token.ELSE)
                        {
                            Check(Token.ELSE);
                            Statement(nelse);
                        }
                        break;

                    case Token.WHILE:
                        Check(Token.WHILE);
                        Check(Token.LPAR);
                        Condition(out x);
                        Check(Token.RPAR);
                        Check(Token.LBRACE);
                        while (la != Token.RBRACE && la != Token.EOF)
                        {
                            Statement(nstatement2);
                        }
                        Check(Token.RBRACE);
                        break;
                    case Token.BREAK:
                        Check(Token.BREAK);
                        Check(Token.SEMICOLON);
                        break;
                    case Token.RETURN:
                        Check(Token.RETURN);
                        if (la == Token.MINUS || la == Token.IDENT || la == Token.NUMBER ||
                            la == Token.CHARCONST || la == Token.NEW || la == Token.LPAR)
                            Expr(out item, null);
                        Check(Token.SEMICOLON);
                        break;
                    case Token.READ:
                        Check(Token.READ);
                        Check(Token.LPAR);
                        if (la == Token.IDENT)
                            Designator(out item, null);
                        Check(Token.RPAR);
                        Check(Token.SEMICOLON);
                        break;
                    case Token.WRITELN: 
                        ///////////////////////// Este bloque agrega y muestra writeln en el arbol y selecciona la gramatica
                        Check(Token.WRITELN);

                        //token queda con WRITELN y laToken =  "(" y ch con Comm Doble
                        //equivalente a Check(Token.LPAR);
                        //debe quedar token = "("  y laToken = "texto posiblem vacio"               
                        if (la == Token.LPAR) //ch = Comm Doble
                        {
                            if (Scanner.ch != '\"')
                                Errors.Error("Se esperaba una COMILLA DOBLE");
                            else
                            {
                                string argStr = "";
                                Scanner.NextCh(); //ch = 2º com doble o Primer char del argStr

                                while (Scanner.ch != '\"')
                                {
                                    //if (ch == EOF) return new Token(Token.EOF, line, col);
                                    argStr = argStr + Scanner.ch.ToString();
                                    Scanner.NextCh();  //ch = 2º char del argStr o Com Doble
                                }
                                //ch = Com Doble
                                token = new Token(Scanner.line, Scanner.col);
                                token.kind = Token.COMILLADOBLE; //se va a llamar argDeWriteLine
                                token.str = argStr; // excluye las comillas dobles
                                //token.line lo deja =
                                token.col = token.col - argStr.Length; //+ 1; // -3; //DESPUES DEL "("

                                Scanner.NextCh(); //ch=")"
                                token = laToken; //token queda con argDeWriteLine
                                laToken = Scanner.Next(); //la token queda con ")"
                                la = laToken.kind;

                                Check(Token.RPAR);
                                Check(Token.SEMICOLON);
                            }
                        }
                        break;
                    case Token.WRITE: ///  En Statement

                        // G3 - PERUWRITE
                        //////////////// Agrega 'write' al arbol y lo muestra y colorea
                        Check(Token.WRITE);
                        Check(Token.LPAR);

                        // First(Expr)
                        if (la == Token.MINUS || la == Token.IDENT || la == Token.NUMBER ||
                            la == Token.CHARCONST || la == Token.NEW || la == Token.LPAR)

                            AA(out item); ///?????

                        Expr(out item, expr1); // Crea la Expr
                        if (la != Token.RBRACE) // Le provee 10 espacios de escritura sino manda ningun numero
                        // Por ej. write(x);
                        {
                            Check(Token.COMMA);

                            Expr(out itemAncho, expr2);
                            Check(Token.RPAR);
                        }
                        Check(Token.SEMICOLON);
                        break;
                    case Token.LBRACE:
                        Block(blockint);  //bloque(blockint = bloque interior)dentro de una sentencia
                        break;
                    case Token.SEMICOLON:
                        Check(Token.SEMICOLON);
                        break;
                    default:
                        Errors.Error("Espero una sentencia");
                        break;
                }
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
        }
    }
}