using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    abstract class CompoundAndCheckedProduction<TProduction> : CompoundProduction<TProduction>
    {
        public CompoundAndCheckedProduction(int number, string name, string description)
            : base(number, name, description) { }
        public abstract bool ValidBegin(TokenEnum tokenExpected);
    }
}