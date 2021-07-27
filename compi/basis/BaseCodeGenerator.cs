using System;
using System.Reflection.Emit;
using System.Reflection;
using compi.basis.symbolTable;

namespace compi.basis
{
    class BaseCodeGenerator
    {
        public static int segmAnteriorGram = 0;
        static LocalBuilder ultimaVbleLocalDin;
        static bool primeraVez = true;
        public int ii;// = 100;
        //----- shortcuts to the relevant IL instruction codes of System.Reflection.Emit.OpCodes
        public static readonly OpCode
            // loading method arguments
            LDARG0 = OpCodes.Ldarg_0,
            LDARG1 = OpCodes.Ldarg_1,
            LDARG2 = OpCodes.Ldarg_2,
            LDARG3 = OpCodes.Ldarg_3,
            LDARG = OpCodes.Ldarg_S,
            // storing in method argument slots
            STARG = OpCodes.Starg_S,
            // loading local variables
            LDLOC0 = OpCodes.Ldloc_0,
            LDLOC1 = OpCodes.Ldloc_1,
            LDLOC2 = OpCodes.Ldloc_2,
            LDLOC3 = OpCodes.Ldloc_3,
            LDLOC = OpCodes.Ldloc_S,
            // storing local variables
            STLOC0 = OpCodes.Stloc_0,
            STLOC1 = OpCodes.Stloc_1,
            STLOC2 = OpCodes.Stloc_2,
            STLOC3 = OpCodes.Stloc_3,
            STLOC = OpCodes.Stloc_S,
            // loading constant values
            LDNULL = OpCodes.Ldnull,
            LDCM1 = OpCodes.Ldc_I4_M1,
            LDC0 = OpCodes.Ldc_I4_0,
            LDC1 = OpCodes.Ldc_I4_1,
            LDC2 = OpCodes.Ldc_I4_2,
            LDC3 = OpCodes.Ldc_I4_3,
            LDC4 = OpCodes.Ldc_I4_4,
            LDC5 = OpCodes.Ldc_I4_5,
            LDC6 = OpCodes.Ldc_I4_6,
            LDC7 = OpCodes.Ldc_I4_7,
            LDC8 = OpCodes.Ldc_I4_8,
            LDC = OpCodes.Ldc_I4,
            // stack manipulation
            DUP = OpCodes.Dup,
            POP = OpCodes.Pop,
            // method invocation
            CALL = OpCodes.Call,
            RET = OpCodes.Ret,
            // branching
            BR = OpCodes.Br,
            BEQ = OpCodes.Beq,
            BGE = OpCodes.Bge,
            BGT = OpCodes.Bgt,
            BLE = OpCodes.Ble,
            BLT = OpCodes.Blt,
            BNE = OpCodes.Bne_Un,
            // arithmetics
            ADD = OpCodes.Add,
            SUB = OpCodes.Sub,
            MUL = OpCodes.Mul,
            DIV = OpCodes.Div,
            REM = OpCodes.Rem,
            NEG = OpCodes.Neg,
            // field access
            LDFLD = OpCodes.Ldfld,
            STFLD = OpCodes.Stfld,
            LDSFLD = OpCodes.Ldsfld,
            STSFLD = OpCodes.Stsfld,
            // object creation
            NEWOBJ = OpCodes.Newobj,
            NEWARR = OpCodes.Newarr,
            // array handling 
            LDLEN = OpCodes.Ldlen,
            LDELEMCHR = OpCodes.Ldelem_U2,
            LDELEMINT = OpCodes.Ldelem_I4,
            LDELEMREF = OpCodes.Ldelem_Ref,
            STELEMCHR = OpCodes.Stelem_I2,
            STELEMINT = OpCodes.Stelem_I4,
            STELEMREF = OpCodes.Stelem_Ref,

            // exception handling
            THROW = OpCodes.Throw;

        const FieldAttributes GLOBALATTR = FieldAttributes.Assembly | FieldAttributes.Static;
        const FieldAttributes FIELDATTR = FieldAttributes.Assembly;
        const MethodAttributes METHATTR = MethodAttributes.Assembly | MethodAttributes.Static;
        const TypeAttributes INNERATTR = TypeAttributes.Class | TypeAttributes.NotPublic;
        const TypeAttributes PROGATTR = TypeAttributes.Class | TypeAttributes.Public;

        /* quick access to conditional branch instructions */
        static readonly OpCode[] brtrue = { BEQ, BGE, BGT, BLE, BLT, BNE };
        static readonly string[] brtrueString = { "beq", "bge", "bgt", "ble", "blt", "bne" };
        public enum BrtrueENUM { BEQenum, BGEenum, BGTenum, BLEenum, BLTenum, BNEenum };

        static readonly OpCode[] brfalse = { BNE, BLT, BLE, BGT, BGE, BEQ };
        static readonly string[] brfalseString = { "bne", "blt", "ble", "bgt", "bge", "beq" };
        public enum BrfalseENUM { BNEenum, BLTenum, BLEenum, BGTenum, BGEenum, BEQenum };

        public static BrtrueENUM vsrEnum = BrtrueENUM.BEQenum;

        public static BrfalseENUM[] brfalseVar;
        public static BrtrueENUM[] brtrueVar;

        /* No-arg contructor of class System.Object. */
        static readonly ConstructorInfo objCtor = typeof(object).GetConstructor(new Type[0]);

        /* No-arg constructor of class System.ExecutionEngineException, for functions without return */
        internal static readonly ConstructorInfo eeexCtor = typeof(System.ExecutionEngineException).GetConstructor(new Type[0]);

        //----- System.Reflection.Emit objects for metadata management	

        public static AssemblyBuilder assembly;  // metadata builder for the program assembly
        static ModuleBuilder module;      // metadata builder for the program module
        public static TypeBuilder program;       // metadata builder for the main class P
        static TypeBuilder inner;         // metadata builder for the currently compiled inner class
        internal static MethodBuilder     // builders for the basic I/O operations provided by the Z# keywords read and write
            readChar, readInt, writeChar, writeInt;
        //MethodBuilder writeStrMthd1;
        internal static ILGenerator il;   // IL stream of currently compiled method

        //----- metadata generation

        /* Creates the required metadata builder objects for the given Symbol.
         * Call this after you inserted you Symbol into the symbol table.
         */
        

        internal static void CreateMetadata(BaseSymbol symbol)
        {
            switch (symbol.kind)
            {
                case SymbolKind.Global:
                    {
                        if (symbol.type.kind != BaseSymbolTable.noType)
                            symbol = program.DefineField(symbol.name, symbol.type.sysType, GLOBALATTR);
                        break;
                    }
                case SymbolKind.Field:
                    {
                        if (symbol.type != Tab.noType)
                            symbol.field = inner.DefineField(symbol.name, symbol.type.sysType, FIELDATTR);
                        break;
                    }
                case SymbolKind.Local:
                    {
                        LocalBuilder vbleLocalDin = il.DeclareLocal(symbol.type.sysType);
                        if (primeraVez)
                        {
                            ultimaVbleLocalDin = vbleLocalDin;
                            primeraVez = false;
                        }
                        break;
                    }
                case SymbolKind.Type:
                    inner = module.DefineType(symbol.name, INNERATTR);
                    symbol.type.sysType = inner;
                    // define default contructor (calls base constructor)
                    symbol.ctor = inner.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[0]);
                    il = symbol.ctor.GetILGenerator();
                    il.Emit(LDARG0);
                    il.Emit(CALL, typeof(object).GetConstructor(new Type[0]));
                    il.Emit(RET);
                    break;
                case SymbolKind.Meth:
                    {
                        symbol.meth = program.DefineMethod(symbol.name, MethodAttributes.Public, typeof(void), null);
                        il = symbol.meth.GetILGenerator();
                        if (symbol.name == "Main")
                        {
                            assembly.SetEntryPoint(symbol.meth);
                        }
                        break;
                    }

                case SymbolKind.Prog:
                    {
                        AssemblyName assemblyName = new AssemblyName();
                        assemblyName.Name = symbol.name;
                        assembly =
                            AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
                        module = assembly.DefineDynamicModule(symbol.name + "Module", symbol.name + ".exe");//".exe"
                        program = module.DefineType(symbol.name, PROGATTR);  //clase din para el program
                        Type objType = Type.GetType("System.Object");
                        ConstructorInfo objCtor = objType.GetConstructor(new Type[0]);
                        ConstructorBuilder pointCtor = program.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[0]);
                        ILGenerator ctorIL = pointCtor.GetILGenerator();
                        // First, you build the constructor.
                        ctorIL.Emit(OpCodes.Ldarg_0);
                        ctorIL.Emit(OpCodes.Call, objCtor);
                        ctorIL.Emit(OpCodes.Ret);
                        inner = null;
                        // build methods for I/O keywords (read, write)
                        BuildReadChar();
                        BuildReadInt();
                        BuildWriteChar();
                        BuildWriteInt();
                        break;
                    }
            }
        }

        /* Completes the system type of an inner class.
         * Call this at end of class declaration. */
        internal static void CompleteClass()
        {
            inner.CreateType();
            inner = null;
        }

        /* Load the operand x onto the expression stack. */
        internal static void Load(Item x)
        {
            switch (x.kind)
            {
                case Item.Kinds.Const:
                    if (x.type == Tab.nullType) il.Emit(LDNULL);
                    else LoadConst(x.val);
                    break;
                case Item.Kinds.Arg:
                    {
                        switch (x.adr)
                        {
                            case 0: il.Emit(LDARG0); break;
                            case 1: il.Emit(LDARG1); break;
                            case 2: il.Emit(LDARG2); break;
                            case 3: il.Emit(LDARG3); break;
                            default: il.Emit(LDARG, x.adr); break;
                        }
                        break;
                    }
                case Item.Kinds.Local:
                    {
                        Parser.nroDeInstrCorriente++;
                        Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.loadLocal;
                        Parser.cil[Parser.nroDeInstrCorriente].nro = x.adr;
                        //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                        switch (x.adr)
                        {
                            case 0:
                                il.Emit(LDLOC0); cargaInstr("ldloc.0   ");
                                break;
                            case 1:
                                il.Emit(LDLOC1); cargaInstr("ldloc.1   ");
                                break;
                            case 2:
                                il.Emit(LDLOC2); cargaInstr("ldloc.2   ");
                                break;
                            case 3:
                                il.Emit(LDLOC3); cargaInstr("ldloc.3   ");
                                break;
                            default:
                                string instr = "ldloc." + x.adr.ToString();
                                il.Emit(LDLOC, x.adr); cargaInstr(instr);
                                break;
                        }
                        //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                        break;
                    }
                case Item.Kinds.Static:
                    {
                        //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                        if (x.symbol.field != null)
                        {
                            il.Emit(LDSFLD, x.symbol.field);
                            cargaInstr(".field static assembly int32 " + x.symbol.name);
                        }
                        //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                        break;
                    }
                case Item.Kinds.Stack:
                    break; // nothing to do (already loaded)
                case Item.Kinds.Field:  // assert: object base address is on stack
                    {
                        //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                        if (x.symbol.field != null)
                        {
                            il.Emit(LDFLD, x.symbol.field);
                            cargaInstr(".field static assembly int32 " + x.symbol.name);
                        };
                        //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                        break;
                    }
                case Item.Kinds.Elem: // assert: array base address and index are on stack
                    {
                        if (x.type == Tab.charType) il.Emit(LDELEMCHR);
                        else if (x.type == Tab.intType) il.Emit(LDELEMINT);
                        else if (x.type.kind == Struct.Kinds.Class) il.Emit(LDELEMREF);
                        else Parser.Errors.Error("invalid array element type");
                        break;
                    }
                default:
                    {
                        Parser.Errors.Error("cannot load this value");
                        break;
                    }
            }
            x.kind = Item.Kinds.Stack;
        }//Fin internal static void Load(Item x)

        internal static void LoadConst(int n)
        {
            Parser.nroDeInstrCorriente++;
            Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.loadConst;
            Parser.cil[Parser.nroDeInstrCorriente].nro = n;  //aqui

            switch (n)
            {
                case -1: il.Emit(LDCM1); cargaInstr("ldc.i4 -1"); break;
                case 0: il.Emit(LDC0); cargaInstr("ldc.i4 0  "); break;
                case 1: il.Emit(LDC1); cargaInstr("ldc.i4 1  "); break;
                case 2: il.Emit(LDC2); cargaInstr("ldc.i4 2  "); break;
                case 3: il.Emit(LDC3); cargaInstr("ldc.i4 3  "); break;
                default: il.Emit(LDC, n); cargaInstr("ldc.i4 " + n.ToString() + blancos(3 - n.ToString().Length)); break;
            }
        }
        
        /* Generate an assignment x = y. */
        internal static void Assign(Item izq, Item der, System.Windows.Forms.TreeNode padrecito)
        {
            switch (izq.kind)
            {
                case Item.Kinds.Stack:  //Para el caso de x = 17. izq tendrá kind Stack
                    {
                        switch (izq.symbol.kind)
                        {
                            case SymbolKind.Arg:
                                {
                                    //Debo saber que nro de arg
                                    il.Emit(STARG, izq.adr);
                                    break;
                                }
                            case SymbolKind.Local:
                                {
                                    //Debo saber que nro de local
                                    int nroDeArg = izq.adr;
                                    Parser.nroDeInstrCorriente++;
                                    Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.storeLocal;
                                    Parser.cil[Parser.nroDeInstrCorriente].nro = nroDeArg; //cuando haya args hay restarle la cant de args
                                    //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                                    switch (nroDeArg)
                                    {
                                        case 0: il.Emit(STLOC0); cargaInstr("stloc.0   "); break;
                                        case 1: il.Emit(STLOC1); cargaInstr("stloc.1   "); break;
                                        case 2: il.Emit(STLOC2); cargaInstr("stloc.2   "); break;
                                        case 3: il.Emit(STLOC3); cargaInstr("stloc.3   "); break;
                                        default:
                                            il.Emit(STLOC, nroDeArg);
                                            cargaInstr("stloc." + nroDeArg.ToString());
                                            break;
                                    }
                                    //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                                    il.Emit(POP);
                                    //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                                    Parser.nroDeInstrCorriente++; cargaInstr("pop      ");
                                    Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.pop;
                                    //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                                    break;
                                }
                            case SymbolKind.Global:
                                {
                                    if (izq.symbol == null)
                                    {
                                        Console.Write("Error 3032928)"); if (ZZ.readKey) Console.ReadKey();
                                    }
                                    //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                                    il.Emit(STSFLD, izq.symbol.field); cargaInstr(".field static assembly int32 " + izq.symbol.name);
                                    il.Emit(POP); Parser.nroDeInstrCorriente++; cargaInstr("pop");
                                    //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                                    break;
                                }
                            default: Parser.Errors.Error("izq.kind=Stack, yo contemplè solo 3 casos: Arg, Local y Global"); break;
                        }//Fin switch (izq.symbol.kind)
                        break;
                    }
                case Item.Kinds.Field:
                    {
                        il.Emit(STFLD, izq.symbol.field); cargaInstr(".field static assembly int32 " + izq.symbol.name);
                        //////----------------------------------------------------------------Grupo 2 22/10/2015------------------------------------------------------
                        break;
                    }
                case Item.Kinds.Elem:
                    {
                        if (izq.type == Tab.intType) il.Emit(STELEMINT);
                        else if (izq.type == Tab.charType) il.Emit(STELEMCHR);
                        else il.Emit(STELEMREF);
                        break;
                    }
                default:
                    {
                        Parser.Errors.Error("caso no contemplado para izq.kind");
                        break;
                    }
            }//Fin switch (izq.kind)
        }//Fin internal static void Assign(Item izq, Item der)

        /* Unconditional jump. */
        internal static void Jump(Label lab)
        {
            il.Emit(BR, lab);
        }

        /* True Jump. Generates conditional branch instruction. */
        internal static void TJump(Item x)
        {
            il.Emit(brtrue[x.relop - Token.EQ], x.tLabel);
        }

        /* False Jump. Generates conditional branch instruction. */
        internal static void FJump(Item x)
        {
            il.Emit(brfalse[x.relop - Token.EQ], x.fLabel);

            Parser.nroDeInstrCorriente++;

            Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.fJump;
            Parser.cil[Parser.nroDeInstrCorriente].nroLinea = -1;  //el Br cond está indefinido
            Parser.cil[Parser.nroDeInstrCorriente].indBrFalse = brfalseVar[x.relop - Token.EQ]; //bge, etc (enum)

            cargaInstr(brfalseString[x.relop - Token.EQ] + "  " + Parser.cil[Parser.nroDeInstrCorriente].nroLinea.ToString());
        }
        
            /* Generate an executable .NET-PE-File. */

        public static void WritePEFile()
        {
            program.CreateType();
            if (inner != null) inner.CreateType();
            assembly.Save(assembly.GetName().Name + ".exe");
        }

        static void BuildReadChar()
        {
            readChar = program.DefineMethod("readc", MethodAttributes.Static, typeof(char), new Type[0]);
            il = readChar.GetILGenerator();
            il.EmitCall(CALL, typeof(Console).GetMethod("Read", new Type[0]), null);
            il.Emit(OpCodes.Conv_U2);
            il.Emit(RET);
        }

        static void BuildReadInt()
        {
            readInt = program.DefineMethod("readi", MethodAttributes.Static, typeof(int), new Type[0]);
            il = readInt.GetILGenerator();
            LocalBuilder neg = il.DeclareLocal(typeof(bool));
            il.Emit(LDC0);
            il.Emit(STLOC0);
            LocalBuilder x = il.DeclareLocal(typeof(int));
            il.Emit(LDC0);
            il.Emit(STLOC1);
            LocalBuilder ch = il.DeclareLocal(typeof(char));
            il.EmitCall(CALL, readChar, null);
            il.Emit(STLOC2);
            Label ifEnd = il.DefineLabel();
            il.Emit(LDLOC2);
            il.Emit(LDC, (int)'-');
            il.Emit(BNE, ifEnd);
            il.Emit(LDC1);
            il.Emit(STLOC0);
            il.EmitCall(CALL, readChar, null);
            il.Emit(STLOC2);
            il.MarkLabel(ifEnd);
            Label whileStart = il.DefineLabel();
            Label whileEnd = il.DefineLabel();
            il.MarkLabel(whileStart);
            il.Emit(LDC, (int)'0');
            il.Emit(LDLOC2);
            il.Emit(BGT, whileEnd);
            il.Emit(LDLOC2);
            il.Emit(LDC, (int)'9');
            il.Emit(BGT, whileEnd);
            il.Emit(LDC, 10);
            il.Emit(LDLOC1);
            il.Emit(MUL);
            il.Emit(LDLOC2);
            il.Emit(LDC, (int)'0');
            il.Emit(SUB);
            il.Emit(ADD);
            il.Emit(STLOC1);
            il.EmitCall(CALL, readChar, null);
            il.Emit(STLOC2);
            il.Emit(BR, whileStart);
            il.MarkLabel(whileEnd);
            ifEnd = il.DefineLabel();
            Label elseBranch = il.DefineLabel();
            il.Emit(LDLOC0);
            il.Emit(OpCodes.Brfalse, elseBranch);
            il.Emit(LDLOC1);
            il.Emit(NEG);
            il.Emit(BR, ifEnd);
            il.MarkLabel(elseBranch);
            il.Emit(LDLOC1);
            il.MarkLabel(ifEnd);
            il.Emit(RET);
        }

        static void BuildWriteChar()
        {
            writeChar = program.DefineMethod("write", MethodAttributes.Static, typeof(void), new Type[] { typeof(char), typeof(int) });
            il = writeChar.GetILGenerator();
            il.Emit(OpCodes.Ldstr, "{{0,{0}}}");
            il.Emit(LDARG1);
            il.Emit(OpCodes.Box, typeof(int));
            il.EmitCall(CALL, typeof(string).GetMethod("Format", new Type[] { typeof(string), typeof(object) }), null);
            il.Emit(LDARG0);
            il.Emit(OpCodes.Box, typeof(char));
            il.EmitCall(CALL, typeof(Console).GetMethod("Write", new Type[] { typeof(string), typeof(object) }), null);
            il.Emit(RET);
        }

        static void BuildWriteInt()
        {
            writeInt = program.DefineMethod("write", MethodAttributes.Static, typeof(void), new Type[] { typeof(int), typeof(int) });
            il = writeInt.GetILGenerator();
            il.Emit(OpCodes.Ldstr, "{{0,{0}}}");
            il.Emit(LDARG1);
            il.Emit(OpCodes.Box, typeof(int));
            il.EmitCall(CALL, typeof(string).GetMethod("Format", new Type[] { typeof(string), typeof(object) }), null);
            il.Emit(LDARG0);
            il.Emit(OpCodes.Box, typeof(int));
            il.EmitCall(CALL, typeof(Console).GetMethod("Write", new Type[] { typeof(string), typeof(object) }), null);
            il.Emit(RET);
        }
    }

    /* Z# Code Item.
     * An item stores the attributes of an operand during code generation.
     */
    class Item
    {
        public enum Kinds { Const, Arg, Local, Static, Field, Stack, Elem, Meth, Cond }

        public Kinds kind;            // Const, Local, Static, Stack, Field, Elem, Method, Cond
        public Struct type;           // item type
        public int val;               // Const: value
        public int adr;               // Arg, Local: offset
        public int relop;             // Cond: token code of relational operator
        public Symbol symbol;            // Field, Meth: node from symbolbol table
        public Label tLabel, fLabel;  // Cond: true jumps, false jumps

        public Item(Symbol symbol)
        {
            type = symbol.type;
            this.symbol = symbol;
            switch (symbol.kind)
            {
                case SymbolKind.Const: kind = Kinds.Const; val = symbol.val; break;
                case SymbolKind.Arg: kind = Kinds.Arg; adr = symbol.adr; break;
                case SymbolKind.Local: kind = Kinds.Local; adr = symbol.adr; break;
                case SymbolKind.Global: kind = Kinds.Static; break;
                case SymbolKind.Field: kind = Kinds.Field; break;
                case SymbolKind.Meth: kind = Kinds.Meth; break;
                default: Parser.Errors.Error(ErrorStrings.CREATE_ITEM); break;
            }
        }

        // special constructor for Const Items
        public Item(int val) { kind = Kinds.Const; type = Tab.intType; this.val = val; }

        // special constructor for Cond Items
        public Item(int relop, Struct type)
        {
            this.kind = Kinds.Cond;
            this.type = type;
            this.relop = relop;
            tLabel = Code.il.DefineLabel();
            fLabel = Code.il.DefineLabel();
        }

        // special constructor for Stack Items
        internal Item(Struct type)
        {
            kind = Kinds.Stack;
            this.type = type;
        }
    }
}
