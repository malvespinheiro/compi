using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
//TODO: Arreglar los nombres de las proucciones para que se coherente con el resto
namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleIdentifiersCommaSeparatedProduction : BaseProduction<PosibleIdentifiersCommaSeparatedProduction>
    {
        public override PosibleIdentifiersCommaSeparatedProduction Execute()
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