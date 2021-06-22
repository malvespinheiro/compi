using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.interfaces;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    class BaseProduction:IProduction
    {
        private string description;
        private Token currentToken;
        private Token lookingAheadToken;
        private IScanner scanner;

        public string Description { get => description; set => description = value; }

        public IProduction Execute()
        {
            return null;
        }

        public IProduction Init(ref IScanner scanner, ref Token currentToken, ref Token lookingAheadToken)
        {
            this.currentToken = currentToken;
            this.lookingAheadToken = lookingAheadToken;
            this.scanner = scanner;
            return null;
        }

        public void Check(TokenKind expected)
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