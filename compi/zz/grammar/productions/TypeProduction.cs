using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TypeProduction : BaseProduction<TypeProduction>
    {
        BaseStruct type;

        internal BaseStruct Type { get => type; set => type = value; }

        public override TypeProduction Execute()
        {
            if (lookingAheadToken.Kind != TokenEnum.IDENT)
            {
                errorHandler.ThrowParserError(ErrorMessages.typeExpected);
            }
            else
            {
                Check(TokenEnum.IDENT);
                BaseSymbol typeSymbol = symbolTable.Find(currentToken.StringRepresentation);
                if (typeSymbol == null)
                {
                    errorHandler.ThrowParserError(ErrorMessages.typeExpected);
                }
                else
                {
                    type = typeSymbol.type;
                };
            }
            return this;
        }
    }
}