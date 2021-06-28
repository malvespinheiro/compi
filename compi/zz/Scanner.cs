using System;
using System.Collections;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz
{
    class Scanner:BaseScanner
    {
        public override Token Next()
        {
            while ((currentCharacter == ' ') || (currentCharacter == LF) || (currentCharacter == CR))
                NextCharacter();

            if (currentCharacter == EOF)
                return new Token(TokenEnum.EOF, lineNumber, columnNumber);

            Token token = new Token(lineNumber, columnNumber);
            
            if ((currentCharacter >= 'a' && currentCharacter <= 'z') || (currentCharacter >= 'A' && currentCharacter <= 'Z')) //es Letra
                ReadName(token);
            else
             if ('0' <= currentCharacter && '9' >= currentCharacter)
                ReadNumber(token);
            else
                switch (currentCharacter)
                {
                    // -----------------------
                    //| tokens simples        |
                    // -----------------------

                    case ';':
                        token.Kind = TokenEnum.SEMICOLON;
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case ',':
                        token.StringRepresentation = ","; 
                        token.StringRepresentation = currentCharacter.ToString();
                        token.Kind = TokenEnum.COMMA;
                        NextCharacter();
                        break;
                    case '.':
                        token.Kind = TokenEnum.PERIOD;
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '*':
                        token.Kind = TokenEnum.TIMES;
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '%':
                        token.Kind = TokenEnum.REM;
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '(':
                        token.Kind = TokenEnum.LPAR;
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case ')':
                        token.Kind = TokenEnum.RPAR;
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '[':
                        token.Kind = TokenEnum.LBRACK;
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case ']':
                        token.Kind = TokenEnum.RBRACK;
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '{':
                        token.Kind = TokenEnum.LBRACE;
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '}':
                        token.Kind = TokenEnum.RBRACE;
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '\"':
                        NextCharacter();
                        token.Kind = TokenEnum.DOUBLEQUOTE;
                        token.StringRepresentation = "\"";
                        break;
                    case EOF:
                        token.Kind = TokenEnum.EOF;
                        break;
                    // -----------------------
                    //| tokens compuestos     |
                    // -----------------------
                    case '=':
                        NextCharacter();
                        if (currentCharacter == '=')
                        {
                            NextCharacter();
                            token.Kind = TokenEnum.EQ;
                            token.StringRepresentation = "==";
                        }
                        else
                        {
                            token.Kind = TokenEnum.ASSIGN; 
                            token.StringRepresentation = "=";
                        }
                        break;
                    case '!':
                        NextCharacter();
                        if (currentCharacter == '=')
                        {
                            NextCharacter();
                            token.Kind = TokenEnum.NE; 
                            token.StringRepresentation = "!=";
                        }
                        else
                        {
                            token.Kind = TokenEnum.NONE;
                            throw new ScannerException(ErrorMessages.GetMessage(currentCharacter.ToString(), ErrorMessages.wrongCharacter));
                        };
                        break;
                    case '+':
                        NextCharacter();
                        if (currentCharacter == '+')
                        {
                            NextCharacter();
                            token.Kind = TokenEnum.PLUSPLUS;
                            token.StringRepresentation = "++";
                        }
                        else
                        {
                            token.Kind = TokenEnum.PLUS; 
                            token.StringRepresentation = currentCharacter.ToString();
                        }
                        break;
                    case '-':
                        NextCharacter();
                        if (currentCharacter == '-')
                        {
                            NextCharacter();
                            token.Kind = TokenEnum.MINUSMINUS;
                            token.StringRepresentation = "--";
                        }
                        else
                        {
                            token.Kind = TokenEnum.MINUS; 
                            token.StringRepresentation = currentCharacter.ToString();
                        }
                        break;
                    case '&':
                        NextCharacter();
                        if (currentCharacter == '&')
                        {
                            NextCharacter();
                            token.Kind = TokenEnum.AND; 
                            token.StringRepresentation = "&&";
                        }
                        else
                        {
                            token.Kind = TokenEnum.NONE;
                        }
                        break;
                    case '|':
                        NextCharacter();
                        if (currentCharacter == '|')
                        {
                            NextCharacter();
                            token.Kind = TokenEnum.OR; 
                            token.StringRepresentation = "||";
                        }
                        else
                        {
                            token.Kind = TokenEnum.NONE;
                        }
                        break;
                    case '>':
                        NextCharacter();
                        if (currentCharacter == '=')
                        {
                            NextCharacter();
                            token.Kind = TokenEnum.GE; 
                            token.StringRepresentation = ">=";
                        }
                        else
                        {
                            token.Kind = TokenEnum.GT; 
                            token.StringRepresentation = ">";
                        }
                        break;
                    case '<':
                        NextCharacter();
                        if (currentCharacter == '=')
                        {
                            NextCharacter();
                            token.Kind = TokenEnum.LE; 
                            token.StringRepresentation = "<=";

                        }
                        else
                        {
                            NextCharacter(); 
                            token.Kind = TokenEnum.LT; 
                            token.StringRepresentation = "<";
                        }
                        break;
                    //  --------------------
                    // | CONSTANTE CARACTER
                    //  --------------------
                    case '\'':
                        NextCharacter(); 
                        if (currentCharacter == '\\')
                        {
                            token.NumericalRepresentation = 0;
                            NextCharacter();
                            switch (currentCharacter)
                            {
                                case 'n':
                                    token.NumericalRepresentation = '\n';
                                    NextCharacter();
                                    break;
                                case 'r':
                                    token.NumericalRepresentation = '\r';
                                    NextCharacter();
                                    break;
                                case '\'':
                                    token.NumericalRepresentation = '\\';
                                    break;
                                default:
                                    throw new ScannerException(ErrorMessages.GetMessage(currentCharacter.ToString(), ErrorMessages.wrongCharacter));
                            }
                        }
                        else 
                        {

                            if (((currentCharacter < 'A') && (currentCharacter > 'Z')) ||
                                ((currentCharacter < 'a') && (currentCharacter > 'z')) ||
                                (currentCharacter != '\''))
                            {
                                throw new ScannerException(ErrorMessages.GetMessage(currentCharacter.ToString(), ErrorMessages.wrongCharacter));
                            }

                            NextCharacter();

                            if (currentCharacter != '\'')
                            {
                                throw new ScannerException(ErrorMessages.GetMessage(currentCharacter.ToString(), ErrorMessages.wrongCharacter));
                            }


                            token.NumericalRepresentation = currentCharacter;
                            token.StringRepresentation = currentCharacter.ToString();
                            token.Kind = TokenEnum.CHARCONST;
                            NextCharacter();
                        }
                        break;

                    // -----------------------
                    //| comentarios           |
                    // -----------------------   
                    case '/':
                        NextCharacter();
                        if (currentCharacter == '*')
                        {
                            Stack stack = new Stack();
                            stack.Push("comment");
                            while ((currentCharacter != EOF) && stack.Count > 0)
                            {
                                NextCharacter();
                                if (currentCharacter == '*')
                                {
                                    NextCharacter();
                                    if ((currentCharacter == '/') && stack.Count > 0)
                                    {
                                        stack.Pop();
                                        if (stack.Count == 0)
                                        {
                                            //bandera = true;
                                            NextCharacter();
                                            token = Next();
                                        }
                                    }
                                }
                                else
                                {
                                    if (currentCharacter == '/')
                                    {
                                        NextCharacter();
                                        if (currentCharacter == '*')
                                            stack.Push("comment");
                                    }
                                }
                            }
                        }
                        else
                        {
                            token.Kind = TokenEnum.SLASH;
                        }
                        break;

                    default:
                        {
                            throw new ScannerException(ErrorMessages.GetMessage(currentCharacter.ToString(), ErrorMessages.wrongCharacter));
                        }
                }
            return token;
        }

        private void ReadName(Token token)
        {
            while ((currentCharacter >= 'a' && currentCharacter <= 'z') || (currentCharacter >= 'A' && currentCharacter <= 'Z') || currentCharacter == '_')
            {
                token.StringRepresentation = token.StringRepresentation + currentCharacter;
                NextCharacter();
            }
            if (keywords.IsKeyword(token.StringRepresentation))
                switch (token.StringRepresentation)
                {
                    case "break":
                        token.Kind = TokenEnum.BREAK;
                        break;
                    case "class":
                        token.Kind = TokenEnum.CLASS;
                        break;
                    case "const":
                        token.Kind = TokenEnum.CONST;
                        break;
                    case "else":
                        token.Kind = TokenEnum.ELSE;
                        break;
                    case "if":
                        token.Kind = TokenEnum.IF;
                        break;
                    case "new":
                        token.Kind = TokenEnum.NEW;
                        break;
                    case "read":
                        token.Kind = TokenEnum.READ;
                        break;
                    case "return":
                        token.Kind = TokenEnum.RETURN;
                        break;
                    case "void":
                        token.Kind = TokenEnum.VOID;
                        break;
                    case "while":
                        token.Kind = TokenEnum.WHILE;
                        break;
                    case "write":
                        token.Kind = TokenEnum.WRITE;
                        break;
                    case "writeln":
                        token.Kind = TokenEnum.WRITELN;
                        break;

                }
            else
            {
                token.Kind = TokenEnum.IDENT;
            }

        }

        private void ReadNumber(Token t)
        {
            while (currentCharacter >= '0' && currentCharacter <= '9' && currentCharacter != EOF)
            {
                t.StringRepresentation = t.StringRepresentation + currentCharacter;
                NextCharacter();
            }

            if (t.StringRepresentation != null)
                try
                {
                    t.NumericalRepresentation = Int16.Parse(t.StringRepresentation );
                    t.Kind = TokenEnum.NUMBER;
                }
                catch (Exception)
                {
                    throw new ScannerException(ErrorMessages.GetMessage(currentCharacter.ToString(), ErrorMessages.wrongFormatNumber));
                }
        }
    }
}