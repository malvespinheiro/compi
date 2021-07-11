namespace compi.basis.symbolTable
{
    class BaseStruct
    {
        public StructKind kind;
        public BaseStruct elementsTypeArray;
        public BaseSymbol fieldsClass;

        public BaseStruct(StructKind kind) : this(kind, null) { }
        public BaseStruct(StructKind kind, BaseStruct elementsTypeArray)
        {
            this.kind = kind;
            this.elementsTypeArray = elementsTypeArray;
        }

        public override bool Equals(object o)
        {
            if (this == o)
                return true;

            if (!(o is BaseStruct s))
                return false;

            return Equals(s);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(BaseStruct other)
        {
            if (kind == StructKind.Arr)
                return other.kind == StructKind.Arr && elementsTypeArray.Equals(other.elementsTypeArray);

            return this == other;
        }

        public bool IsRefType() { return kind == StructKind.Class || kind == StructKind.Arr; }

        public bool CompatibleWith(BaseStruct other)    
        {
            return  this.Equals(other) || other.IsRefType() || this.IsRefType();
        }

        public bool AssignableTo(BaseStruct dest)
        {
            return this.Equals(dest) ||
                   dest.IsRefType() ||
                   (kind == StructKind.Arr && dest.kind == StructKind.Arr && dest.elementsTypeArray.kind == this.elementsTypeArray.kind);
        }
    }
}
