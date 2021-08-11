using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TypeProduction : CheckedBeganProduction<TypeProduction>, IExecutorTyped<TypeProduction>
    {
        public TypeProduction()
            : base(5, "Type", "ident") { }
        
        public TypeProduction Execute(out BaseStruct type)
        {
            Check(TokenEnum.IDENT);

            type = symbolTable.FindType(currentToken.StringRepresentation).type;

            return this;
        }

        public override bool ValidBegin(TokenEnum tokenExpected)
        {
            return tokenExpected == TokenEnum.IDENT;
        }
    }
}