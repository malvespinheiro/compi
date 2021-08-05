using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class StatementProduction : CompoundProduction<StatementProduction>
    {

        private readonly RestOfStatementProduction restOfStatementProduction = new RestOfStatementProduction();

        public override StatementProduction Execute()
        {
            if (!IsValidStatementBegining(lookingAheadToken.Kind))
            {
                errorHandler.ThrowParserError(ErrorMessages.statementExpected);
            }

            if (lookingAheadToken.Kind == TokenEnum.IDENT)
            {
                Check(TokenEnum.IDENT);
                restOfStatementProduction.Execute();
                Check(TokenEnum.COMMA);
            }
            else
            {
                switch (lookingAheadToken.Kind)
                {
                    case TokenEnum.IF:
                        Check(TokenEnum.IF);
                        Check(TokenEnum.LPAR);
                        Condition(out x);
                        Check(TokenEnum.RPAR);
                        Statement(nstatement);
                        if (lookingAheadToken.Kind == TokenEnum.ELSE)
                        {
                            Check(TokenEnum.ELSE);
                            Statement(nelse);
                        }
                        break;

                    case TokenEnum.WHILE:
                        Check(TokenEnum.WHILE);
                        Check(TokenEnum.LPAR);
                        Condition(out x);
                        Check(TokenEnum.RPAR);
                        Check(TokenEnum.LBRACE);
                        while (la != TokenEnum.RBRACE && la != TokenEnum.EOF)
                        {
                            Statement(nstatement2);
                        }
                        Check(TokenEnum.RBRACE);
                        break;
                    case TokenEnum.BREAK:
                        Check(TokenEnum.BREAK);
                        Check(TokenEnum.SEMICOLON);
                        break;
                    case TokenEnum.RETURN:
                        Check(TokenEnum.RETURN);
                        if (lookingAheadToken.Kind == TokenEnum.MINUS || lookingAheadToken.Kind == TokenEnum.IDENT || lookingAheadToken.Kind == TokenEnum.NUMBER ||
                            lookingAheadToken.Kind == TokenEnum.CHARCONST || lookingAheadToken.Kind == TokenEnum.NEW || lookingAheadToken.Kind == TokenEnum.LPAR)
                            Expr(out item, null);
                        Check(TokenEnum.SEMICOLON);
                        break;
                    case TokenEnum.READ:
                        Check(TokenEnum.READ);
                        Check(TokenEnum.LPAR);
                        if (lookingAheadToken.Kind == TokenEnum.IDENT)
                            Designator(out item, null);
                        Check(TokenEnum.RPAR);
                        Check(TokenEnum.SEMICOLON);
                        break;
                    case TokenEnum.WRITELN: 
                        ///////////////////////// Este bloque agrega y muestra writeln en el arbol y selecciona la gramatica
                        Check(TokenEnum.WRITELN);

                        //token queda con WRITELN y laToken =  "(" y ch con Comm Doble
                        //equivalente a Check(TokenEnum.LPAR);
                        //debe quedar token = "("  y laToken = "texto posiblem vacio"               
                        if (lookingAheadToken.Kind == TokenEnum.LPAR) //ch = Comm Doble
                        {
                            if (Scanner.ch != '\"')
                                Errors.Error("Se esperaba una COMILLA DOBLE");
                            else
                            {
                                string argStr = "";
                                Scanner.NextCh(); //ch = 2º com doble o Primer char del argStr

                                while (Scanner.ch != '\"')
                                {
                                    //if (ch == EOF) return new Token(TokenEnum.EOF, line, col);
                                    argStr = argStr + Scanner.ch.ToString();
                                    Scanner.NextCh();  //ch = 2º char del argStr o Com Doble
                                }
                                //ch = Com Doble
                                token = new Token(Scanner.line, Scanner.col);
                                token.kind = TokenEnum.COMILLADOBLE; //se va a llamar argDeWriteLine
                                token.str = argStr; // excluye las comillas dobles
                                //token.line lo deja =
                                token.col = token.col - argStr.Length; //+ 1; // -3; //DESPUES DEL "("

                                Scanner.NextCh(); //ch=")"
                                token = laToken; //token queda con argDeWriteLine
                                laToken = Scanner.Next(); //la token queda con ")"
                                la = laToken.kind;

                                Check(TokenEnum.RPAR);
                                Check(TokenEnum.SEMICOLON);
                            }
                        }
                        break;
                    case TokenEnum.WRITE: ///  En Statement

                        // G3 - PERUWRITE
                        //////////////// Agrega 'write' al arbol y lo muestra y colorea
                        Check(TokenEnum.WRITE);
                        Check(TokenEnum.LPAR);

                        // First(Expr)
                        if (lookingAheadToken.Kind == TokenEnum.MINUS || lookingAheadToken.Kind == TokenEnum.IDENT || lookingAheadToken.Kind == TokenEnum.NUMBER ||
                            lookingAheadToken.Kind == TokenEnum.CHARCONST || lookingAheadToken.Kind == TokenEnum.NEW || lookingAheadToken.Kind == TokenEnum.LPAR)

                            AA(out item); ///?????

                        Expr(out item, expr1); // Crea la Expr
                        if (la != TokenEnum.RBRACE) // Le provee 10 espacios de escritura sino manda ningun numero
                        // Por ej. write(x);
                        {
                            Check(TokenEnum.COMMA);

                            Expr(out itemAncho, expr2);
                            Check(TokenEnum.RPAR);
                        }
                        Check(TokenEnum.SEMICOLON);
                        break;
                    case TokenEnum.LBRACE:
                        Block(blockint);  //bloque(blockint = bloque interior)dentro de una sentencia
                        break;
                    case TokenEnum.SEMICOLON:
                        Check(TokenEnum.SEMICOLON);
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
        }
    }
}