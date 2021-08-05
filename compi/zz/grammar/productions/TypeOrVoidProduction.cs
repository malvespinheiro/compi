using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TypeOrVoidProduction : CompoundProduction<TypeOrVoidProduction>
    {
        private readonly TypeProduction typeProduction = new TypeProduction();

        public override TypeOrVoidProduction Execute()
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
    }
}