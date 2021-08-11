using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ParamsDeclarationProduction : CompoundProduction<ParamsDeclarationProduction>, IExecutor<ParamsDeclarationProduction>
    {
        private readonly TypedIdentifierProduction typedIdentifierProduction= new TypedIdentifierProduction();
        private readonly PossibleTypedIdentifiersCommaSeparatedProduction possibleTypedIdentifiersCommaSeparatedProduction = new PossibleTypedIdentifiersCommaSeparatedProduction();
        public ParamsDeclarationProduction()
            : base(12, "ParamsDeclaration", " . | TypedIdentifier PossibleTypedIdentifiersCommaSeparated") { }

        public override void InitProductions()
        {
            typedIdentifierProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            possibleTypedIdentifiersCommaSeparatedProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public ParamsDeclarationProduction Execute()
        {
            if (typedIdentifierProduction.ValidBegin(lookingAheadToken.Kind))
            {
                typedIdentifierProduction.Execute();
                possibleTypedIdentifiersCommaSeparatedProduction.Execute();
            }
            return this;
        }
    }
}