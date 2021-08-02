using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class MethodDeclarationProduction : CompoundProduction<MethodDeclarationProduction>
    {

        private readonly TypeProduction typeProduction = new TypeProduction();
        private readonly VariableDeclarationProduction variableDeclarationProduction = new VariableDeclarationProduction();
        private readonly FormParsProduction formParsProduction= new FormParsProduction();
        private readonly BlockProduction blockProduction= new BlockProduction();

        BaseSymbol currentMethod;
        public override MethodDeclarationProduction Execute()
        {
            BaseStruct type = new BaseStruct(StructKind.None);
            if (lookingAheadToken.Kind == TokenEnum.VOID || lookingAheadToken.Kind == TokenEnum.IDENT)
            {
                if (lookingAheadToken.Kind == TokenEnum.VOID)
                {
                    Check(TokenEnum.VOID);
                    type = symbolTable.noType;
                }
                else
                {
                    if (lookingAheadToken.Kind == TokenEnum.IDENT)
                    {
                        type = typeProduction.Execute().Type;
                    }
                }
                    
                Check(TokenEnum.IDENT);
                currentMethod = symbolTable.Insert(SymbolKind.Meth, currentToken.StringRepresentation, type);
                symbolTable.OpenScope(currentMethod);
                Check(TokenEnum.LPAR);
                if (lookingAheadToken.Kind == TokenEnum.IDENT)
                {
                    formParsProduction.Execute();
                    Check(TokenEnum.RPAR);
                }
                else
                {
                    Check(TokenEnum.RPAR);
                }

                // Code.CreateMetadata(currentMethod); 
                while (lookingAheadToken.Kind != TokenEnum.LBRACE && lookingAheadToken.Kind != TokenEnum.EOF)
                {
                    if (lookingAheadToken.Kind == TokenEnum.IDENT)
                    {
                        variableDeclarationProduction.SetAttributes(SymbolKind.Local).Execute();
                    }
                    else
                    {
                        errorHandler.ThrowParserError(ErrorMessages.variablesDeclarationExpected);
                    }
                }

                blockProduction.Execute(); 
                //TODO: Entender para que sirven estas asignaciones
                // currentMethod.nArgs = symbolTable.TopScope.nArgs;
                // currentMethod.nLocs = symbolTable.TopScope.nLocs;
                // currentMethod.locals = symbolTable.TopScope.locals;
                symbolTable.CloseScope();

                // Code.il.Emit(Code.RET);  //si lo saco se clava en el InvokeMember
                // Parser.nroDeInstrCorriente++;
                // Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.ret;
                // Code.cargaInstr("ret");
            }
            return this;
        }

        public override void InitProductions()
        {
            typeProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            variableDeclarationProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            formParsProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            blockProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}