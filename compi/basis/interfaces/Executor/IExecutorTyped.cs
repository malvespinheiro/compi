using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis.interfaces
{
    interface IExecutorTyped<TProduction>
    {
        TProduction Execute(out BaseStruct type);
    }
}
