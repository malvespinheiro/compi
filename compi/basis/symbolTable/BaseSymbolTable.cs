namespace compi.basis.symbolTable
{
    class BaseSymbolTable
    {
        public readonly BaseStruct noType = new BaseStruct(StructKind.None);
        public readonly BaseStruct intType = new BaseStruct(StructKind.Int);
        public readonly BaseStruct charType = new BaseStruct(StructKind.Char);
        public readonly BaseStruct stringType = new BaseStruct(StructKind.String);
        public readonly BaseStruct nullType = new BaseStruct(StructKind.Class);

        public readonly BaseSymbol noSym = new BaseSymbol(SymbolKind.Const, "noBaseSymbol", new BaseStruct(StructKind.None));

        private BaseScope topScope;
        internal BaseScope TopScope { get => topScope; set => topScope = value; }

        public void Init()
        {
            OpenUniversalScope();
            InitStandardTypes();
            InitStandardMethods();
        }

        private void OpenUniversalScope()
        {
            OpenScope(null);
        }

        private void InitStandardTypes()
        {
            Insert(SymbolKind.Type, "int", intType);
            Insert(SymbolKind.Type, "char", charType);
            Insert(SymbolKind.Const, "null", nullType);
        }

        private void InitStandardMethods() { }

        public void OpenScope(BaseSymbol sym)
        {
            BaseScope s = new BaseScope
            {
                nArgs = 0,
                nLocs = 0,
                outer = TopScope
            };
            TopScope = s;
        }

        public void CloseScope()
        {
            TopScope = TopScope.outer;
        }

        public BaseSymbol Insert(SymbolKind kind, string name, BaseStruct type)
        {
            BaseSymbol symbol = new BaseSymbol(kind, name, type);
            symbol.next = null;

            switch (kind)
            {
                case SymbolKind.Arg: symbol.adr = TopScope.nArgs++; break;
                case SymbolKind.Local: symbol.adr = TopScope.nLocs++; break;
            }

            BaseSymbol foundSymbol = FindFromBaseSymbol(symbol.name, TopScope.Locals);
            if (foundSymbol.kind == noSym.kind)
            {
                // TODO: El elemento ya esta declarado, registrar un error o lanzar exceptions
            }

            BaseSymbol lastSymbol = FindLastSymbol();

            if (lastSymbol == null)
                TopScope.Locals = symbol;
            else
                lastSymbol.next = symbol;

            return symbol;
        }

        private BaseSymbol FindLastSymbol()
        {
            BaseSymbol currentSymbol = TopScope.Locals;
            BaseSymbol lastSymbol = TopScope.Locals;
            while (currentSymbol != null)
            {
                lastSymbol = currentSymbol;
                currentSymbol = currentSymbol.next;
            }
            return lastSymbol;
        }

        public BaseSymbol Find(string name)
        { 
            for (BaseScope s = TopScope; s != null; s = s.outer)
                for (BaseSymbol sym = s.Locals; sym != null; sym = sym.next)
                    if (sym.name == name)
                        return sym;
            return noSym;
        }

        public BaseSymbol FindFromBaseSymbol(string name, BaseSymbol baseSymbol)
        {
            for (BaseSymbol sym = baseSymbol; sym != null; sym = sym.next)
                if (sym.name == name)
                    return sym;
            return noSym;
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