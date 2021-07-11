namespace compi.basis.symbolTable
{
    class BaseSymbol
    {
        public SymbolKind kind;
        public string name;
        public BaseStruct type;
        public BaseSymbol next;
        public int val;
        public int adr;
        public int nArgs;
        public int nLocs;

        private BaseSymbol locals;
        internal BaseSymbol Locals { get => locals; set => locals = value; }

        public BaseSymbol(SymbolKind kind, string name, BaseStruct type)
        {
            this.kind = kind;
            this.name = name;
            this.type = type;
        }
        public override bool Equals(object o)
        {
            if (this == o)
                return true;

            if (!(o is BaseSymbol sym))
                return false;

            return Equals(sym);
        }
        public bool Equals(BaseSymbol sym)
        {
            if (kind != sym.kind || name != sym.name || !type.Equals(sym.type))
                return false;
            switch (kind)
            {
                case SymbolKind.Const: return val == sym.val;
                case SymbolKind.Arg:
                case SymbolKind.Local: return adr == sym.adr;
                case SymbolKind.Meth: return nArgs == sym.nArgs && nLocs == sym.nLocs && EqualsCompleteList(Locals, sym.Locals);
            }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public bool EqualsCompleteList(BaseSymbol sym1, BaseSymbol sym2)
        {
            if (sym1 == sym2)
                return true;

            while (sym1 != null && sym1.Equals(sym2))
            {
                sym1 = sym1.next;
                sym2 = sym2.next;
            }

            if (sym1 != null || sym2 != null)
                return false;

            return true;
        }
    }
}
