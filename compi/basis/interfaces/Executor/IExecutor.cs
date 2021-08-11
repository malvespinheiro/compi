using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis.interfaces
{
    interface IExecutor<TProduction>
    {
        TProduction Execute();
    }
}
