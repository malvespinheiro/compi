using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
//TODO: Arreglar los nombres de las proucciones para que se coherente con el resto
namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleIdentifiersProduction : BaseProduction<PosibleIdentifiersProduction>
    {
        BaseStruct type;
        SymbolKind kind;

        internal BaseStruct Type { get => type; set => type = value; }
        internal SymbolKind Kind { get => kind; set => kind = value; }

        public PosibleIdentifiersProduction SetAttributes(BaseStruct type, SymbolKind kind)
        {
            this.type = type;
            this.kind = kind;
            return this;
        }

        public override PosibleIdentifiersProduction Execute()
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