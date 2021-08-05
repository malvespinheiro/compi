using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class DeclarationProduction : CompoundProduction<DeclarationProduction>
    {
        private readonly ConstantDeclarationProduction constantDeclarationProduction = new ConstantDeclarationProduction();
        private readonly ClassDeclarationProduction classDeclarationProduction = new ClassDeclarationProduction();
        private readonly VariableDeclarationProduction variableDeclarationProduction = new VariableDeclarationProduction();

        public override void InitProductions()
        {
            this.constantDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            this.classDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            this.variableDeclarationProduction.Init(ref this.scanner, ref this.symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

        }
        public override DeclarationProduction Execute()
        {
            switch (lookingAheadToken.Kind)
            {
                case TokenEnum.CONST:
                    {
                        constantDeclarationProduction.Execute();
                        break;
                    }
                case TokenEnum.IDENT:
                    {
                        variableDeclarationProduction.Execute();
                        break;
                    }
                case TokenEnum.CLASS:
                    {
                        classDeclarationProduction.Execute();
                        break;
                    }
                default:
                    {
                        errorHandler.ThrowParserError(ErrorMessages.classConstantOrVariableExpected);
                        break;
                    }
            }
            return this;
        }
    }
}