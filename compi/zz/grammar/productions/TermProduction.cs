﻿using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TermProduction : CompoundProduction<TermProduction>
    {
        FactorProduction factorProduction = new FactorProduction();
        PosibleOperationFactorProduction posibleOperationFactorProduction = new PosibleOperationFactorProduction();
        public override TermProduction Execute()
        {
            if (!IsValidTermBegining(lookingAheadToken.Kind))
            {
                errorHandler.ThrowParserError(ErrorMessages.termExpected);
            }

            factorProduction.Execute();
            posibleOperationFactorProduction.Execute();
            
            return this;
        }
        public override void InitProductions()
        {
            factorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
            posibleOperationFactorProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }

        public bool IsValidTermBegining(TokenEnum tokenKind)
        {
            if (tokenKind == TokenEnum.IDENT)
                return true;
            if (tokenKind == TokenEnum.NUMBER)
                return true;
            if(tokenKind == TokenEnum.CHARCONST)
                return true;
            if(tokenKind == TokenEnum.NEW)
                return true;
            if(tokenKind == TokenEnum.LPAR)
                return true;

            return false;
        }
    }
}