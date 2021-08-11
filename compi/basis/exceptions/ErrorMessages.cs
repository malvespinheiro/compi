﻿namespace unsj.fcefn.compiladores.compi.basis.exceptions
{
    class ErrorMessages
    {
        public static readonly string invalidConstantType = "El tipo de la deficnición de la constante es incorreecto. Solo puede ser char, int o string.";
        public static readonly string wrongCharacter = "Token inválido debido a caracter: ";
        public static readonly string wrongFormatNumber = "El formato del caracter no es válido: ";
        public static readonly string wrongExpectedToken = "Se esperaba: ";
        public static readonly string constantOrVariableExpected = "Se esperaba Constant o Variable.";
        public static readonly string typeExpected = "Se esperaba un tipo.";
        public static readonly string typeNotFound = "No se encontro el tipo de la declaración.";
        public static readonly string intTypeExpected = "Se esperaba un tipo Int.";
        public static readonly string charTypeExpected = "Se esperaba un tipo Char.";
        public static readonly string wrongConstantDefinition = "La definición de constante es inválida.";
        public static readonly string variablesDeclarationExpected = "Se esperaba la declaracion de una variable.";
        public static readonly string typeOrVoidExpected = "Se esperaba Type o void.";
        public static readonly string identifierExpected = "Se esperaba un identificador.";
        public static readonly string identifierNotFound = "No se encontro el identificador declarado.";
        public static readonly string termExpected = "Se esperaba un término.";
        public static readonly string termOperatorExpected = "Se esperaba el operador de un término.";
        public static readonly string factorOperatorExpected = "Se esperaba el operador de un factor.";
        public static readonly string invalidFactor = "El factor es inválido.";
        public static readonly string invalidStatement = "La sentencia es inválida.";
        public static readonly string relationalOperatorExpected = "Se esperaba un operador relacional.";
    }
}