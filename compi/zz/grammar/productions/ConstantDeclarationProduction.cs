using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class ConstantDeclarationProduction : BaseProduction<ConstantDeclarationProduction>
    {
        public override ConstantDeclarationProduction Execute()
        {
            Check(TokenEnum.CONST); 
            BaseStruct type;
            Type(out type);

            if (type != Tab.intType && type != Tab.charType)
            {
                Errors.Error("el tipo de una def de const sólo puede ser int o char");
            }

            Check(TokenEnum.IDENT);
            BaseSymbol constant = symbolTable.Insert(SymbolKind.Const, currentToken.StringRepresentation, type);
            Check(TokenEnum.ASSIGN);  //const
            switch (lookingAheadToken.Kind)
            {
                case TokenEnum.NUMBER:
                    {
                        if (type != Tab.intType)
                            Errors.Error("type debe ser int");

                        Check(TokenEnum.NUMBER);
                        constant.val = currentToken.NumericalRepresentation;
                        break;
                    }
                case TokenEnum.CHARCONST:
                    {
                        if (type != Tab.charType)
                            Errors.Error("type debe ser char");
                        Check(TokenEnum.CHARCONST);
                        constant.val = currentToken.NumericalRepresentation;
                        break;
                    }
                default:
                    {
                        Errors.Error("def de const erronea");
                        break;
                    }
            }
            Check(TokenEnum.SEMICOLON);
            return this;
        }

        public override void InitProductions()
        {
            throw new System.NotImplementedException();
        }
    }
}