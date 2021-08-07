using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    abstract class CompoundAndCheckedProduction<TProduction> : CompoundProduction<TProduction>
    {
        public abstract bool ValidBegin(TokenEnum tokenExpected);
    }
}