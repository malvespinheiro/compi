using System;
using System.Collections;
using System.IO;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.interfaces;
using unsj.fcefn.compiladores.compi.basis.language;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    public abstract class BaseScanner:IScanner
    {
        private const char EOF = '\u0080';
        private const char CR = '\r';
        private const char LF = '\n';

        private TextReader input;
        private TextWriter output;

        private char currentCharacter;
        private int lineNumber, columnNumber;

        private  BaseKeywords keywords;

        public void Init(TextReader input)
        {
            this.input = input;
            this.output = Console.Out;
            this.lineNumber = 1;
            this.columnNumber = 0;
            this.keywords.Init();
            this.NextCharacter();
        }

        public void NextCharacter()
        {
            try
            {
                currentCharacter = (char)input.Read();
                columnNumber++;
                switch (currentCharacter)
                {
                    case LF:
                        lineNumber++;
                        columnNumber = 0;
                        break;
                    case CR:
                        columnNumber = 0;
                        break;
                    case '\uffff': 
                        currentCharacter = EOF;
                        break;
                }
            }
            catch (IOException) { currentCharacter = EOF; }
        }

        public Token Next()
        {
            while ((currentCharacter == ' ') || (currentCharacter == LF) || (currentCharacter == CR))
                NextCharacter();

            if (currentCharacter == EOF)
                return new Token(TokenKind.Create(TokenEnum.EOF), lineNumber, columnNumber);

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
                        token.Kind = TokenKind.Create(TokenEnum.SEMICOLON);
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case ',':
                        token.StringRepresentation = ","; 
                        token.StringRepresentation = currentCharacter.ToString();
                        token.Kind = TokenKind.Create(TokenEnum.COMMA);
                        NextCharacter();
                        break;
                    case '.':
                        token.Kind = TokenKind.Create(TokenEnum.PERIOD);
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '*':
                        token.Kind = TokenKind.Create(TokenEnum.TIMES);
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '%':
                        token.Kind = TokenKind.Create(TokenEnum.REM);
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '(':
                        token.Kind = TokenKind.Create(TokenEnum.LPAR);
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case ')':
                        token.Kind = TokenKind.Create(TokenEnum.RPAR);
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '[':
                        token.Kind = TokenKind.Create(TokenEnum.LBRACK);
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case ']':
                        token.Kind = TokenKind.Create(TokenEnum.RBRACK);
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '{':
                        token.Kind = TokenKind.Create(TokenEnum.LBRACE);
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '}':
                        token.Kind = TokenKind.Create(TokenEnum.RBRACE);
                        token.StringRepresentation = currentCharacter.ToString(); 
                        NextCharacter();
                        break;
                    case '\"':
                        NextCharacter();
                        token.Kind = TokenKind.Create(TokenEnum.DOUBLEQUOTE);
                        token.StringRepresentation = "\"";
                        break;
                    case EOF:
                        token.Kind = TokenKind.Create(TokenEnum.EOF);
                        break;
                    // -----------------------
                    //| tokens compuestos     |
                    // -----------------------
                    case '=':
                        NextCharacter();
                        if (currentCharacter == '=')
                        {
                            NextCharacter();
                            token.Kind = TokenKind.Create(TokenEnum.EQ);
                            token.StringRepresentation = "==";
                        }
                        else
                        {
                            token.Kind = TokenKind.Create(TokenEnum.ASSIGN); 
                            token.StringRepresentation = "=";
                        }
                        break;
                    case '!':
                        NextCharacter();
                        if (currentCharacter == '=')
                        {
                            NextCharacter();
                            token.Kind = TokenKind.Create(TokenEnum.NE); 
                            token.StringRepresentation = "!=";
                        }
                        else
                        {
                            token.Kind = TokenKind.Create(TokenEnum.NONE);
                            throw new ScannerException(ErrorMessages.GetMessage(currentCharacter.ToString(), ErrorMessages.wrongCharacter));
                        };
                        break;
                    case '+':
                        NextCharacter();
                        if (currentCharacter == '+')
                        {
                            NextCharacter();
                            token.Kind = TokenKind.Create(TokenEnum.PLUSPLUS);
                            token.StringRepresentation = "++";
                        }
                        else
                        {
                            token.Kind = TokenKind.Create(TokenEnum.PLUS); 
                            token.StringRepresentation = currentCharacter.ToString();
                        }
                        break;
                    case '-':
                        NextCharacter();
                        if (currentCharacter == '-')
                        {
                            NextCharacter();
                            token.Kind = TokenKind.Create(TokenEnum.MINUSMINUS);
                            token.StringRepresentation = "--";
                        }
                        else
                        {
                            token.Kind = TokenKind.Create(TokenEnum.MINUS); 
                            token.StringRepresentation = currentCharacter.ToString();
                        }
                        break;
                    case '&':
                        NextCharacter();
                        if (currentCharacter == '&')
                        {
                            NextCharacter();
                            token.Kind = TokenKind.Create(TokenEnum.AND); 
                            token.StringRepresentation = "&&";
                        }
                        else
                        {
                            token.Kind = TokenKind.Create(TokenEnum.NONE);
                        }
                        break;
                    case '|':
                        NextCharacter();
                        if (currentCharacter == '|')
                        {
                            NextCharacter();
                            token.Kind = TokenKind.Create(TokenEnum.OR); 
                            token.StringRepresentation = "||";
                        }
                        else
                        {
                            token.Kind = TokenKind.Create(TokenEnum.NONE);
                        }
                        break;
                    case '>':
                        NextCharacter();
                        if (currentCharacter == '=')
                        {
                            NextCharacter();
                            token.Kind = TokenKind.Create(TokenEnum.GE); 
                            token.StringRepresentation = ">=";
                        }
                        else
                        {
                            token.Kind = TokenKind.Create(TokenEnum.GT); 
                            token.StringRepresentation = ">";
                        }
                        break;
                    case '<':
                        NextCharacter();
                        if (currentCharacter == '=')
                        {
                            NextCharacter();
                            token.Kind = TokenKind.Create(TokenEnum.LE); 
                            token.StringRepresentation = "<=";

                        }
                        else
                        {
                            NextCharacter(); 
                            token.Kind = TokenKind.Create(TokenEnum.LT); 
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
                            token.Kind = TokenKind.Create(TokenEnum.CHARCONST);
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
                            token.Kind = TokenKind.Create(TokenEnum.SLASH);
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
                        token.Kind = TokenKind.Create(TokenEnum.BREAK);
                        break;
                    case "class":
                        token.Kind = TokenKind.Create(TokenEnum.CLASS);
                        break;
                    case "const":
                        token.Kind = TokenKind.Create(TokenEnum.CONST);
                        break;
                    case "else":
                        token.Kind = TokenKind.Create(TokenEnum.ELSE);
                        break;
                    case "if":
                        token.Kind = TokenKind.Create(TokenEnum.IF);
                        break;
                    case "new":
                        token.Kind = TokenKind.Create(TokenEnum.NEW);
                        break;
                    case "read":
                        token.Kind = TokenKind.Create(TokenEnum.READ);
                        break;
                    case "return":
                        token.Kind = TokenKind.Create(TokenEnum.RETURN);
                        break;
                    case "void":
                        token.Kind = TokenKind.Create(TokenEnum.VOID);
                        break;
                    case "while":
                        token.Kind = TokenKind.Create(TokenEnum.WHILE);
                        break;
                    case "write":
                        token.Kind = TokenKind.Create(TokenEnum.WRITE);
                        break;
                    case "writeln":
                        token.Kind = TokenKind.Create(TokenEnum.WRITELN);
                        break;

                }
            else
            {
                token.Kind = TokenKind.Create(TokenEnum.IDENT);
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
                    t.Kind = TokenKind.Create(TokenEnum.NUMBER);
                }
                catch (Exception)
                {
                    throw new ScannerException(ErrorMessages.GetMessage(currentCharacter.ToString(), ErrorMessages.wrongFormatNumber));
                }
        }
    }
}