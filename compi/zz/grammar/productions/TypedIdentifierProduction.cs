using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;
using compi.basis.symbolTable;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TypedIdentifierProduction : CompoundAndCheckedProduction<TypedIdentifierProduction>, IExecutorTyped<TypedIdentifierProduction>
    {
        private readonly TypeProduction typeProduction = new TypeProduction();
        public TypedIdentifierProduction()
            : base(4, "TypedIdentifier", "Type ident") { }
        public TypedIdentifierProduction Execute(out BaseStruct type)
        {
            typeProduction.Execute(out type);
            Check(TokenEnum.IDENT);
            return this;
        }

        public override void InitProductions()
        {
            typeProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }

        public override bool ValidBegin(TokenEnum tokenExpected)
        {
            return typeProduction.ValidBegin(tokenExpected);
        }
    }
}