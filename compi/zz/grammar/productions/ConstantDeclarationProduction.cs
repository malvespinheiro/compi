using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ConstantDeclarationProduction : CompoundProduction<ConstantDeclarationProduction>
    {

        private readonly TypeProduction typeProduction = new TypeProduction();
        private readonly NumberOrCharConstantProduction numberOrCharConstantProduction = new NumberOrCharConstantProduction();
        public override ConstantDeclarationProduction Execute()
        {
            Check(TokenEnum.CONST);

            BaseStruct type = typeProduction.Execute().Type;
            if (!symbolTable.IsValidConstantType(type))
            {
                errorHandler.ThrowParserError(ErrorMessages.invalidConstantType);
            }
            BaseSymbol constant = symbolTable.Insert(SymbolKind.Const, currentToken.StringRepresentation, type);

            Check(TokenEnum.IDENT);
            Check(TokenEnum.ASSIGN);
            numberOrCharConstantProduction.SetAttributes(type, constant).Execute();
            Check(TokenEnum.SEMICOLON);
            return this;
        }

        public override void InitProductions()
        {
            typeProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            numberOrCharConstantProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}