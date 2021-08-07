using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class PosibleParamsSendProduction : CompoundProduction<PosibleParamsSendProduction>
    {
        private readonly ExpressionProduction expressionProduction = new ExpressionProduction();
        private readonly ParamsSendProduction paramsSendProduction  = new ParamsSendProduction();

        public override PosibleParamsSendProduction Execute()
        {
            if (lookingAheadToken.Kind == TokenEnum.MINUS || expressionProduction.IsValidExpressionBegining(lookingAheadToken.Kind))
            {
                paramsSendProduction.Execute();
            }
            return this;
        }

        public override void InitProductions()
        {
            expressionProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            paramsSendProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}