using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TypedIdentifierProduction : CompoundAndCheckedProduction<TypedIdentifierProduction>
    {
        private readonly TypeProduction typeProduction = new TypeProduction();
        public override TypedIdentifierProduction Execute()
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