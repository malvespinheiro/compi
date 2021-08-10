﻿using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class VariableDeclarationProduction : CompoundAndCheckedProduction<VariableDeclarationProduction>
    {
        private readonly TypedIdentifierProduction typedIdentifierProduction = new TypedIdentifierProduction();
        private readonly PossibleIdentifiersCommaSeparatedProduction possibleIdentifiersCommaSeparatedProduction = new PossibleIdentifiersCommaSeparatedProduction();
        public VariableDeclarationProduction()
            : base(7, "VariableDeclaration", "TypedIdentifier PossibleIdentifiersCommaSeparated \";\"") { }
        public override VariableDeclarationProduction Execute()
        {
            //TODO: Obtener el type del typedIdentifier
            //TODO: Obtener el kind como parametro de entrada
            typedIdentifierProduction.Execute();
            BaseSymbol variable = symbolTable.Insert(SymbolKind.Local, currentToken.StringRepresentation, type);
            possibleIdentifiersCommaSeparatedProduction.Execute();
            Check(TokenEnum.SEMICOLON);
            return this;
        }
        public override void InitProductions()
        {
            typedIdentifierProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            possibleIdentifiersCommaSeparatedProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }

        public override bool ValidBegin(TokenEnum tokenExpected)
        {
            return typedIdentifierProduction.ValidBegin(tokenExpected);
        }
    }
}