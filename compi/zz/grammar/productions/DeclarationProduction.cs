﻿using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class DeclarationProduction : CompoundAndCheckedProduction<DeclarationProduction>
    {
        private readonly ConstantDeclarationProduction constantDeclarationProduction = new ConstantDeclarationProduction();
        private readonly VariableDeclarationProduction variableDeclarationProduction = new VariableDeclarationProduction();

        public override void InitProductions()
        {
            constantDeclarationProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            variableDeclarationProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);

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
                default:
                    {
                        errorHandler.ThrowParserError(ErrorMessages.constantOrVariableExpected);
                        break;
                    }
            }
            return this;
        }

        public override bool ValidBegin(TokenEnum tokenExpected)
        {
            return tokenExpected == TokenEnum.CONST || tokenExpected == TokenEnum.IDENT;
        }
    }
}