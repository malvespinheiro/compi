using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PossibleParamsSendProduction : CompoundProduction<PossibleParamsSendProduction>, IExecutor<PossibleParamsSendProduction>
    {
        private readonly ParamsSendProduction paramsSendProduction  = new ParamsSendProduction();
        public PossibleParamsSendProduction()
            : base(24, "PossibleParamsSend", " . | ParamsSend") { }
        public PossibleParamsSendProduction Execute()
        {
            if (paramsSendProduction.ValidBegin(lookingAheadToken.Kind))
            {
                paramsSendProduction.Execute();
            }
            return this;
        }

        public override void InitProductions()
        {
            paramsSendProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}