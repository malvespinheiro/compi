using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleCommaFormParamsProduction : BaseProduction<PosibleCommaFormParamsProduction>
    {
        BaseStruct type;
        SymbolKind kind;

        internal BaseStruct Type { get => type; set => type = value; }
        internal SymbolKind Kind { get => kind; set => kind = value; }

        public PosibleCommaFormParamsProduction SetAttributes(BaseStruct type, SymbolKind kind)
        {
            this.type = type;
            this.kind = kind;
            return this;
        }

        public override PosibleCommaFormParamsProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.COMMA && lookingAheadToken.Kind != TokenEnum.EOF)
            {
                Check(TokenEnum.COMMA);
                Check(TokenEnum.IDENT);
                BaseSymbol variable = symbolTable.Insert(kind, currentToken.StringRepresentation, type);
                Execute();
            }
            return this;
        }
    }
}