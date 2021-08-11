using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.interfaces;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    abstract class BaseProduction<TProduction> : IProduction<TProduction>
    {
        protected int number;
        protected string name;
        protected string description;
        protected Token currentToken;
        protected Token lookingAheadToken;
        protected BaseScanner scanner;
        protected BaseSymbolTable symbolTable;
        protected ErrorHandler errorHandler;

        public BaseProduction(int number, string name, string description)
        {
            this.number = number;
            this.name = name;
            this.description = description;
        }
        public string Description { get => description; set => description = value; }

        public virtual void Init(
            ref BaseScanner scanner, 
            ref BaseSymbolTable symbolTable, 
            ref Token currentToken, 
            ref Token lookingAheadToken,
            ref ErrorHandler errorHandler)
        {
            this.currentToken = currentToken;
            this.lookingAheadToken = lookingAheadToken;
            this.scanner = scanner;
            this.symbolTable = symbolTable;
            this.errorHandler = errorHandler;
        }

        public void Check(TokenEnum expected)
        {
            if (lookingAheadToken.Kind.Equals(expected))
            {
                Scan();
            }
            else
            {
                errorHandler.ThrowParserError(ErrorMessages.wrongExpectedToken + expected.ToString());
            }
        }

        public void Scan()
        {
            currentToken = lookingAheadToken;
            lookingAheadToken = scanner.Next();
        }

        public override string ToString()
        {
            return number + ". " + name + " = " + description;
        }
    }
}