using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class FormParsProduction : CompoundProduction<FormParsProduction>
    {

        private readonly TypeProduction typeProduction = new TypeProduction();

        public override FormParsProduction Execute()
        {
            BaseStruct type = new BaseStruct(StructKind.None);
            if (lookingAheadToken.Kind == TokenEnum.IDENT)
            {
                type = typeProduction.Execute().Type;
                Check(TokenEnum.IDENT);
                while (lookingAheadToken.Kind == TokenEnum.COMMA && lookingAheadToken.Kind != TokenEnum.EOF)
                {
                    Check(TokenEnum.COMMA);
                    type = typeProduction.Execute().Type;
                    Check(TokenEnum.IDENT);
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