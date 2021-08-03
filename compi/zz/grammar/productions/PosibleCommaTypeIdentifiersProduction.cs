using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleCommaTypeIdentifiersProduction : CompoundProduction<PosibleCommaTypeIdentifiersProduction>
    {
        private readonly TypeProduction typeProduction = new TypeProduction();

        SymbolKind kind;

        internal SymbolKind Kind { get => kind; set => kind = value; }

        public PosibleCommaTypeIdentifiersProduction SetAttributes(SymbolKind kind)
        {
            this.kind = kind;
            return this;
        }

        public override PosibleCommaTypeIdentifiersProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.COMMA && lookingAheadToken.Kind != TokenEnum.EOF)
            {
                Check(TokenEnum.COMMA);
                BaseStruct type = typeProduction.Execute().Type;
                Check(TokenEnum.IDENT);
                BaseSymbol variable = symbolTable.Insert(kind, currentToken.StringRepresentation, type);
                Execute();
            }
            return this;
        }

        public override void InitProductions()
        {
            this.typeProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}