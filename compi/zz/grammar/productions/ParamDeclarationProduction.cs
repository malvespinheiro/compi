using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ParamDeclarationProduction : CompoundProduction<ParamDeclarationProduction>
    {
        private readonly TypeProduction typeProduction = new TypeProduction();
        private readonly PosibleCommaTypeIdentifiersProduction posibleCommaTypeIdentifiersProduction = new PosibleCommaTypeIdentifiersProduction();

        private SymbolKind symbolKind;

        public ParamDeclarationProduction SetAttributes(SymbolKind symbolKind)
        {
            this.symbolKind = symbolKind;
            return this;
        }

        public override void InitProductions()
        {
            this.typeProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public override ParamDeclarationProduction Execute()
        {
            BaseStruct type = typeProduction.Execute().Type;
            Check(TokenEnum.IDENT);
            return this;
        }
    }
}