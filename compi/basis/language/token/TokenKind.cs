
namespace unsj.fcefn.compiladores.compi.basis.language.token
{
    public class TokenKind
    {
        private TokenEnum type;

        public TokenKind(TokenEnum type)
        {
            this.Type = type;
        }

        public TokenEnum Type { get => type; set => type = value; }

        public override string ToString()
        {
            switch (Type)
            {
                default: { return "?"; }
                case TokenEnum.IDENT: { return "identifier"; }
                case TokenEnum.NUMBER: { return "number"; }
                case TokenEnum.CHARCONST: { return "character constant"; }
                case TokenEnum.PLUS: { return "+"; }
                case TokenEnum.MINUS: { return "-"; }
                case TokenEnum.TIMES: { return "*"; }
                case TokenEnum.SLASH: { return "/"; }
                case TokenEnum.REM: { return "%"; }
                case TokenEnum.EQ: { return "=="; }
                case TokenEnum.GE: { return ">="; }
                case TokenEnum.GT: { return ">"; }
                case TokenEnum.LE: { return "<="; }
                case TokenEnum.LT: { return "<"; }
                case TokenEnum.NE: { return "!="; }
                case TokenEnum.AND: { return "&&"; }
                case TokenEnum.OR: { return "||"; }
                case TokenEnum.ASSIGN: { return "="; }
                case TokenEnum.PLUSPLUS: { return "++"; }
                case TokenEnum.MINUSMINUS: { return "--"; }
                case TokenEnum.SEMICOLON: { return ";"; }
                case TokenEnum.COMMA: { return ","; }
                case TokenEnum.PERIOD: { return "."; }
                case TokenEnum.LPAR: { return "("; }
                case TokenEnum.RPAR: { return ")"; }
                case TokenEnum.LBRACK: { return "["; }
                case TokenEnum.RBRACK: { return "]"; }
                case TokenEnum.LBRACE: { return "{"; }
                case TokenEnum.RBRACE: { return "}"; }
                case TokenEnum.BREAK: { return "break"; }
                case TokenEnum.CLASS: { return "class"; }
                case TokenEnum.CONST: { return "const"; }
                case TokenEnum.ELSE: { return "else"; }
                case TokenEnum.IF: { return "if"; }
                case TokenEnum.NEW: { return "new"; }
                case TokenEnum.READ: { return "read"; }
                case TokenEnum.RETURN: { return "return"; }
                case TokenEnum.VOID: { return "void"; }
                case TokenEnum.WHILE: { return "while"; }
                case TokenEnum.WRITE: { return "write"; }
                case TokenEnum.EOF: { return "end of file"; }
                case TokenEnum.DOUBLEQUOTE: { return "\""; }
            }
        }

        public bool Equals(TokenKind tokenKind)
        {
            return this.type.Equals(tokenKind.type);
        }

        public static TokenKind Create(TokenEnum tokenEnum)
        {
            return new TokenKind(tokenEnum);
        }
    }
}