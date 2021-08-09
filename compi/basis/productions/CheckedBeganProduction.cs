using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    abstract class CheckedBeganProduction<TProduction> : BaseProduction<TProduction>
    {
        public CheckedBeganProduction(int number, string name, string description)
            :base(number, name, description) { }
        public abstract bool ValidBegin(TokenEnum tokenExpected);
    }
}