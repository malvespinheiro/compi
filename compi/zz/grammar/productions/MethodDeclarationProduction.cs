using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class MethodDeclarationProduction : CompoundProduction<MethodDeclarationProduction>
    {
        private readonly TypeOrVoidProduction typeOrVoidProduction = new TypeOrVoidProduction();
        private readonly VariableDeclarationProduction variableDeclarationProduction = new VariableDeclarationProduction();
        private readonly ParamsDeclarationProduction paramsDeclarationProduction = new ParamsDeclarationProduction();
        private readonly PosibleVariableDeclarationProduction posibleVariableDeclarationProduction  = new PosibleVariableDeclarationProduction();
        private readonly BlockProduction blockProduction = new BlockProduction();

        BaseSymbol currentMethod;
        public override MethodDeclarationProduction Execute()
        {
            typeOrVoidProduction.Execute();
            Check(TokenEnum.IDENT);
            Check(TokenEnum.LPAR);
            paramsDeclarationProduction.Execute();
            Check(TokenEnum.RPAR);
            posibleVariableDeclarationProduction.Execute();
            blockProduction.Execute();
            return this;
        }

        public override void InitProductions()
        {
            typeOrVoidProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            variableDeclarationProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            paramsDeclarationProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            posibleVariableDeclarationProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            blockProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}