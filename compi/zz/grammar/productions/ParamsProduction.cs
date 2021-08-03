using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ParamsProduction : CompoundProduction<ParamsProduction>
    {
        private readonly FormParamsProduction formParamsProduction = new FormParamsProduction();

        private SymbolKind symbolKind;

        public ParamsProduction SetAttributes(SymbolKind symbolKind)
        {
            this.symbolKind = symbolKind;
            return this;
        }

        public override void InitProductions()
        {
            this.formParamsProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public override ParamsProduction Execute()
        {
            BaseStruct type = new BaseStruct(StructKind.None);
            if (lookingAheadToken.Kind == TokenEnum.IDENT)
            {
                formParamsProduction.Execute();

                Type(out type);
                Check(TokenEnum.IDENT);
                while (lookingAheadToken.Kind == TokenEnum.COMMA && lookingAheadToken.Kind != TokenEnum.EOF)
                {
                    Check(TokenEnum.COMMA);
                    Type(out type);
                    Check(TokenEnum.IDENT);
                }
            }
            return this;
        }
    }
}