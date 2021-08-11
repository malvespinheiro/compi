using System.Text;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.basis.language.token
{
     class Token {
        private TokenEnum kind;
	    private int lineNumber;
	    private int columnNumber;
	    private int numericalRepresentation;
	    private string stringRepresentation;

        public Token() :
            this(0, 0){ }

        public Token(int lineNumber, int columnNumber): 
                this(TokenEnum.NONE, lineNumber, columnNumber, 0, null) {}

	    public Token(TokenEnum kind, int lineNumber, int columnNumber): 
                this(kind, lineNumber, columnNumber, 0, null) {}

	    public Token(TokenEnum kind, int lineNumber, int columnNumber, int numericalRepresentation): 
                this(kind, lineNumber, columnNumber, numericalRepresentation, null) {}

	    public Token(TokenEnum kind, int lineNumber, int columnNumber, string stringRepresentation) : 
                this(kind, lineNumber, columnNumber, 0, stringRepresentation) {}

	    public Token(TokenEnum kind, int lineNumber, int columnNumber, int numericalRepresentation, string stringRepresentation) {
		    this.Kind = kind;
		    this.LineNumber = lineNumber;
            this.ColumnNumber = columnNumber;
		    this.NumericalRepresentation = numericalRepresentation;
            this.StringRepresentation = stringRepresentation;
	    }

        public TokenEnum Kind{ get => kind; set => kind =value; }

        public int LineNumber { get => lineNumber; set => lineNumber = value; }

        public int ColumnNumber { get => columnNumber; set => columnNumber = value; }

        public int NumericalRepresentation { get => numericalRepresentation; set => numericalRepresentation = value; }

        public string StringRepresentation { get => stringRepresentation; set => stringRepresentation = value; }

        public bool Equals(Token t)
        {
            if (Kind != t.Kind || LineNumber != t.LineNumber || ColumnNumber != t.ColumnNumber)
                return false;

            switch (Kind)
            {
                case TokenEnum.IDENT: return StringRepresentation == t.StringRepresentation;
                case TokenEnum.NUMBER: return NumericalRepresentation == t.NumericalRepresentation && StringRepresentation == t.StringRepresentation;
                case TokenEnum.CHARCONST: return NumericalRepresentation == t.NumericalRepresentation;
            }
            return true;
        }

        public string KindToString(Token t)
        {
            switch (Kind)
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
                case TokenEnum.STRINGCONSTANT: { return "string"; }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("line {0}, col {1}: {2}", LineNumber, ColumnNumber, Kind.ToString());
            switch (Kind)
            {
                case TokenEnum.IDENT: sb.AppendFormat(" = {0}", StringRepresentation); break;
                case TokenEnum.NUMBER: sb.AppendFormat(" = {0} (\"{1}\")", NumericalRepresentation, StringRepresentation); break;
                case TokenEnum.CHARCONST: sb.AppendFormat(" = '{0}'", (char)NumericalRepresentation); break;
            }
            return sb.ToString();
        }
    }

}