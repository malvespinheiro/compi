using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleIdentifiersCommaSeparatedProduction : BaseProduction<PossibleIdentifiersCommaSeparatedProduction>
    {
        public PossibleIdentifiersCommaSeparatedProduction()
            : base(8, "PossibleIdentifiersCommaSeparated", " . | \",\" ident PossibleIdentifiersCommaSeparated") { }
        public override PossibleIdentifiersCommaSeparatedProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.COMMA)
            {
                Check(TokenEnum.COMMA);
                Check(TokenEnum.IDENT);
                Execute();
            }
            return this;
        }
    }
}