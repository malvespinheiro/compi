using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleTypedIdentifiersCommaSeparatedProduction : CompoundProduction<PossibleTypedIdentifiersCommaSeparatedProduction>
    {
        private readonly TypedIdentifierProduction typedIdentifierProduction = new TypedIdentifierProduction();
        public PossibleTypedIdentifiersCommaSeparatedProduction()
            : base(13, "PossibleTypedIdentifiersCommaSeparated", " . |  \", \" TypedIdentifier PosibleTypedIdentifiersCommaSeparated") { }
        public override PossibleTypedIdentifiersCommaSeparatedProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.COMMA)
            {
                Check(TokenEnum.COMMA);
                typedIdentifierProduction.Execute();
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