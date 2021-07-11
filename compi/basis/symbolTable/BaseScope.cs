namespace compi.basis.symbolTable
{
    class BaseScope
    {
        public BaseScope outer;    // reference to enclosing scope
        private BaseSymbol locals;  // symbol table of this scope
        public int nArgs;          // # of arguments in this scope (for address asignment)
        public int nLocs;          // # of local variables in this scope (for address asignment)

        internal BaseSymbol Locals { get => locals; set => locals = value; }
    }
}