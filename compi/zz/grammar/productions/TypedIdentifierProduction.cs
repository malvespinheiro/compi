using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TypedIdentifierProduction : CompoundAndCheckedProduction<TypedIdentifierProduction>, IExecutor<TypedIdentifierProduction>
    {
        private readonly TypeProduction typeProduction = new TypeProduction();
        public TypedIdentifierProduction()
            : base(4, "TypedIdentifier", "Type ident") { }
        public TypedIdentifierProduction Execute()
        {
            typeProduction.Execute();
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