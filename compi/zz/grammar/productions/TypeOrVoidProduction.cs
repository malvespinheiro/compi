using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TypeOrVoidProduction : CompoundAndCheckedProduction<TypeOrVoidProduction>, IExecutor<TypeOrVoidProduction>
    {
        private readonly TypeProduction typeProduction = new TypeProduction();
        public TypeOrVoidProduction()
            : base(11, "TypeOrVoid", "Type | \"void\"") { }
        public TypeOrVoidProduction Execute()
        {
            switch (lookingAheadToken.Kind)
            {
                case TokenEnum.VOID:
                    {
                        Check(TokenEnum.VOID);
                        break;
                    }
                case TokenEnum.IDENT:
                    {
                        typeProduction.Execute();
                        break;
                    }
                default:
                    {
                        errorHandler.ThrowParserError(ErrorMessages.typeOrVoidExpected);
                        break;
                    }
            }
            return this;
        }
        public override void InitProductions()
        {
            typeProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
        public override bool ValidBegin(TokenEnum tokenExpected)
        {
            return tokenExpected == TokenEnum.IDENT || tokenExpected == TokenEnum.VOID;
        }
    }
}