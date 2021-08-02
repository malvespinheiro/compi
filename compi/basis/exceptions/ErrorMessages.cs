namespace unsj.fcefn.compiladores.compi.basis.exceptions
{
    class ErrorMessages
    {
        public static readonly string invalidConstantType = "El tipo de la deficnición de la constante es incorreecto. Solo puede ser char, int o string.";
        public static readonly string wrongCharacter = "Token inválido debido a caracter: ";
        public static readonly string wrongFormatNumber = "El formato del caracter no es válido: ";
        public static readonly string wrongExpectedToken = "Se esperaba: ";
        public static readonly string classConstantOrVariableExpected = "Se esperaba Class, Constant o Variable.";
        public static readonly string typeExpected = "Se esperaba un tipo.";
        public static readonly string intTypeExpected = "Se esperaba un tipo Int.";
        public static readonly string charTypeExpected = "Se esperaba un tipo Char.";
        public static readonly string wrongConstantDefinition = "La definición de constante es inválida.";
        public static readonly string variablesDeclarationExpected = "Se esperaba la declaracion de una variable.";
        public static readonly string statementExpected = "Se esperaba una sentencia.";
        public static readonly string typeOrVoidExpected = "Se esperaba Type o void";
    }
}