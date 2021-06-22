using System.Text;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.basis.language.token
{
public class Token:IToken {
        private TokenKind kind;
	    private int lineNumber;
	    private int columnNumber;
	    private int numericalRepresentation;
	    private string stringRepresentation;
	
	    public Token (int lineNumber, int columnNumber): 
                this(new TokenKind(TokenEnum.NONE), lineNumber, columnNumber, 0, null) {}

	    public Token (TokenKind kind, int lineNumber, int columnNumber): 
                this(kind, lineNumber, columnNumber, 0, null) {}

	    public Token (TokenKind kind, int lineNumber, int columnNumber, int numericalRepresentation): 
                this(kind, lineNumber, columnNumber, numericalRepresentation, null) {}

	    public Token (TokenKind kind, int lineNumber, int columnNumber, string stringRepresentation) : 
                this(kind, lineNumber, columnNumber, 0, stringRepresentation) {}

	    public Token (TokenKind kind, int lineNumber, int columnNumber, int numericalRepresentation, string stringRepresentation) {
		    this.Kind = kind;
		    this.LineNumber = lineNumber;
            this.ColumnNumber = columnNumber;
		    this.NumericalRepresentation = numericalRepresentation;
            this.StringRepresentation = stringRepresentation;
	    }

        public TokenKind Kind { get => kind; set => kind = value; }

        public int LineNumber { get => lineNumber; set => lineNumber = value; }

        public int ColumnNumber { get => columnNumber; set => columnNumber = value; }

        public int NumericalRepresentation { get => numericalRepresentation; set => numericalRepresentation = value; }

        public string StringRepresentation { get => stringRepresentation; set => stringRepresentation = value; }

        public bool Equals (Token t)
        {
		    if (Kind != t.Kind || LineNumber != t.LineNumber || ColumnNumber != t.ColumnNumber)
                    return false;

		    switch (Kind.Type) {
			    case TokenEnum.IDENT: return StringRepresentation == t.StringRepresentation;
			    case TokenEnum.NUMBER: return NumericalRepresentation == t.NumericalRepresentation && StringRepresentation == t.StringRepresentation;
			    case TokenEnum.CHARCONST: return NumericalRepresentation == t.NumericalRepresentation; 
		    }
		    return true;
	    }

	    public override string ToString () {
		    StringBuilder sb = new StringBuilder();
		    sb.AppendFormat("line {0}, col {1}: {2}", LineNumber, ColumnNumber, Kind.ToString());
		    switch (Kind.Type) {
			    case TokenEnum.IDENT:     sb.AppendFormat(" = {0}", StringRepresentation); break;
			    case TokenEnum.NUMBER:    sb.AppendFormat(" = {0} (\"{1}\")", NumericalRepresentation, StringRepresentation); break;
			    case TokenEnum.CHARCONST: sb.AppendFormat(" = '{0}'", (char)NumericalRepresentation); break;
		    }
		    return sb.ToString();
	    }	
    }

}
