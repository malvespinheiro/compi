using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleTermProduction : CompoundProduction<PosibleTermProduction>
    {
        TermProduction termProduction = new TermProduction();
        public override PosibleTermProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.PLUS || lookingAheadToken.Kind == TokenEnum.MINUS)
            {
                Scan();
                termProduction.Execute();
                Execute();
            }
            return this;
        }
        public override void InitProductions()
        {
            termProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}