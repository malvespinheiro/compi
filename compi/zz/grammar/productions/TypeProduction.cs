﻿using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class TypeProduction : BaseProduction<TypeProduction>
    {
        public override TypeProduction Execute()
        {
            Check(TokenEnum.IDENT);
            return this;
        }
    }
}