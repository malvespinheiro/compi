using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    // TODO. Entender si no conviene hacer las declaraciones de la Tabla de simbolos aca, en cualquier caso, 
    // siempre recibe lo que se declara salvo en el caso de las variables separadas por comma.
    // TODO: Chequear como se esta todo ok para mandar todo a la tabla de simbolos
    class TypedIdentifierProduction : CompoundProduction<TypedIdentifierProduction>
    {
        private readonly TypeProduction typeProduction = new TypeProduction();

        public override TypedIdentifierProduction Execute()
        {
            typeProduction.Execute();
            Check(TokenEnum.IDENT);
            return this;
        }

        public override void InitProductions()
        {
            typeProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}