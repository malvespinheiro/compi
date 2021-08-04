using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleTypedIdentifiersCommaSeparatedProduction : CompoundProduction<PosibleTypedIdentifiersCommaSeparatedProduction>
    {
        private readonly TypedIdentifierProduction typedIdentifierProduction = new TypedIdentifierProduction();

        BaseStruct type;
        SymbolKind kind;

        internal BaseStruct Type { get => type; set => type = value; }
        internal SymbolKind Kind { get => kind; set => kind = value; }

        public PosibleTypedIdentifiersCommaSeparatedProduction SetAttributes(BaseStruct type, SymbolKind kind)
        {
            this.type = type;
            this.kind = kind;
            return this;
        }

        public override PosibleTypedIdentifiersCommaSeparatedProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.COMMA && lookingAheadToken.Kind != TokenEnum.EOF)
            {
                Check(TokenEnum.COMMA);
                Execute();
            }
            return this;
        }

        public override void InitProductions()
        {
            typedIdentifierProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}