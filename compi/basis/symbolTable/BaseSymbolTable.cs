﻿using unsj.fcefn.compiladores.compi.basis.exceptions;

namespace compi.basis.symbolTable
{
    class BaseSymbolTable
    {
        public readonly BaseStruct noType = new BaseStruct(StructKind.None);
        public readonly BaseStruct intType = new BaseStruct(StructKind.Int);
        public readonly BaseStruct charType = new BaseStruct(StructKind.Char);
        public readonly BaseStruct stringType = new BaseStruct(StructKind.String);
        public readonly BaseStruct nullType = new BaseStruct(StructKind.Class);

        public readonly BaseSymbol noSymbol = new BaseSymbol(SymbolKind.Constant, "noBaseSymbol", new BaseStruct(StructKind.None));

        private BaseScope topScope;
        internal BaseScope TopScope { get => topScope; set => topScope = value; }

        private ErrorHandler errorHandler;

        public void Init(ref ErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
            OpenUniversalScope();
            InitStandardTypes();
        }

        private void OpenUniversalScope()
        {
            OpenScope();
        }

        private void InitStandardTypes()
        {
            Insert(SymbolKind.Type, "int", intType);
            Insert(SymbolKind.Type, "char", charType);
            Insert(SymbolKind.Type, "string", stringType);
            Insert(SymbolKind.Constant, "null", nullType);
        }

        public void OpenScope()
        {
            BaseScope s = new BaseScope
            {
                numberOfArguments = 0,
                numberOfLocals = 0,
                outer = TopScope
            };
            TopScope = s;
        }

        public void CloseScope(ref BaseSymbol symbol)
        {
            symbol.locals = TopScope.locals;
            symbol.nArgs = TopScope.numberOfArguments;
            symbol.nLocs = TopScope.numberOfLocals;

            TopScope = TopScope.outer;
        }

        public BaseSymbol Insert(SymbolKind kind, string name, BaseStruct type)
        {
            BaseSymbol symbol = new BaseSymbol(kind, name, type);
            symbol.next = null;

            switch (kind)
            {
                case SymbolKind.Argument: symbol.adr = TopScope.numberOfArguments++; break;
                case SymbolKind.Local: symbol.adr = TopScope.numberOfLocals++; break;
            }

            BaseSymbol foundSymbol = FindFromBaseSymbol(symbol.name, TopScope.locals);
            if (foundSymbol.kind == noSymbol.kind)
            {
                // TODO: El elemento ya esta declarado, registrar un error o lanzar exceptions
            }

            BaseSymbol lastSymbol = FindLastSymbol();

            if (lastSymbol == null)
                TopScope.locals = symbol;
            else
                lastSymbol.next = symbol;

            return symbol;
        }

        private BaseSymbol FindLastSymbol()
        {
            BaseSymbol currentSymbol = TopScope.locals;
            BaseSymbol lastSymbol = TopScope.locals;
            while (currentSymbol != null)
            {
                lastSymbol = currentSymbol;
                currentSymbol = currentSymbol.next;
            }
            return lastSymbol;
        }

        public BaseSymbol Find(string name)
        {
            BaseSymbol foundSymbol = noSymbol;
            for (BaseScope scope = TopScope; scope != null && foundSymbol.type.kind == noSymbol.type.kind; scope = scope.outer)
            {
                for (BaseSymbol symbol = scope.locals; symbol != null && foundSymbol.type.kind == noSymbol.type.kind; symbol = symbol.next)
                {
                    if (symbol.name == name)
                    {
                        foundSymbol = symbol;
                    }
                }
            }
            if (foundSymbol.type.kind == noSymbol.type.kind)
            {
                errorHandler.ThrowIdentifierError(ErrorMessages.identifierNotFound);
            }
            return noSymbol;
        }

        public BaseSymbol FindType(string name)
        {
            BaseSymbol symbol = Find(name);
            if(symbol.kind != SymbolKind.Type)
            {
                errorHandler.ThrowTypingError(ErrorMessages.typeNotFound);
            }
            return symbol;
        }

        public BaseSymbol FindFromBaseSymbol(string name, BaseSymbol baseSymbol)
        {
            for (BaseSymbol sym = baseSymbol; sym != null; sym = sym.next)
                if (sym.name == name)
                    return sym;
            return noSymbol;
        }

        public bool IsValidConstantType(BaseStruct type) {
            return type.kind == StructKind.Char || type.kind == StructKind.Int;
        }

        public bool IsValidIntType(BaseStruct type)
        {
            return type.kind == StructKind.Int;
        }

        public bool IsValidCharType(BaseStruct type)
        {
            return type.kind == StructKind.Char;
        }
    }
}