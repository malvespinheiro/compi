﻿namespace compi.basis.symbolTable
{
    class BaseSymbol
    {
        public string name;
        public int val;
        public int adr;
        public int nArgs;
        public int nLocs;
        public SymbolKind kind;
        public BaseStruct type;
        public BaseSymbol next;
        public BaseSymbol locals;
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
                case SymbolKind.Constant: return val == sym.val;
                case SymbolKind.Argument:
                case SymbolKind.Local: return adr == sym.adr;
                case SymbolKind.Method: return nArgs == sym.nArgs && nLocs == sym.nLocs && EqualsCompleteList(locals, sym.locals);
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
