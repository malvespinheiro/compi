using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.interfaces;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    abstract class BaseProduction<TProduction> : IProduction<TProduction>
    {
        protected string description;
        protected Token currentToken;
        protected Token lookingAheadToken;
        protected BaseScanner scanner;

        public string Description { get => description; set => description = value; }

        public abstract TProduction Execute();

        public void Init(ref BaseScanner scanner, ref Token currentToken, ref Token lookingAheadToken)
        {
            this.currentToken = currentToken;
            this.lookingAheadToken = lookingAheadToken;
            this.scanner = scanner;
        }

        public void Check(TokenEnum expected)
        {
            if (lookingAheadToken.Kind.Equals(expected))
            {
                Scan();
            }
            else
            {
                throw new ParserException(ErrorMessages.GetMessage(expected.ToString(), ErrorMessages.wrongExpectedToken));
            }
        }

        public void Scan()
        {
            currentToken = lookingAheadToken;
            lookingAheadToken = scanner.Next();
        }
    }
}