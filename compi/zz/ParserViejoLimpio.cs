using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compi.zz
{
    class ParserViejoLimpio
    {
        static void Program()
        {
            
            //antes del Check (Token.CLASS), token = ...(1,1),  laToken = ..."class".. y la = Token.CLASS
            Check(Token.CLASS);   //class ProgrPpal
            Check(Token.IDENT); // "ProgrPpal" => debo insertar el token en la tabla de símbolos
            Symbol prog = Tab.Insert(Symbol.Kinds.Prog, token.str, Tab.noType);//lo cuelga de universe
            Code.CreateMetadata(prog);
            Tab.OpenScope(prog); //topScore queda ahora apuntando a un nuevo Scope
            while (la != Token.LBRACE && la != Token.EOF) //Si no existen declaraciones, la = Token.LBRACE
                VarDecl | ClassDecl.");
                switch (la)
                {
                    case Token.CONST:
                        {
                            ConstDecl(hijodeclar);
                            break;
                        }
                    case Token.IDENT:  //Type ident..
                        {
                            VardDecl(Symbol.Kinds.Global, hijo1); //En program  //Table val;
                            break;
                        }
                    case Token.CLASS:
                        {
                            ClassDecl();/*No se encuentra la gramatica para implementar declaracione de clases" */
                            break;
                        }
                    default:
                        {
                            token = laToken;
                            break;
                        }
                }
            }
            
            Check(Token.LBRACE);
            while ((la == Token.IDENT || la == Token.VOID) && la != Token.EOF)
            {
                MethodDecl(methodDeclsOpc);  //void Main() int x,i; {val = new Table;....}
            }
            Check(Token.RBRACE);
                Console.WriteLine("antes de prog.locals = Tab.topScope.locals; Tab.CloseScope()");
                if (ZZ.readKey)
                    Console.ReadKey();
            };
            prog.locals = Tab.topScope.locals;
            if (ZZ.parser)
            {
                Console.WriteLine("mostrarSymbol");
                prog.mostrarSymbol("");
                if (ZZ.readKey) Console.ReadKey();
            };
            Tab.CloseScope();
            Tab.mostrarTab();
            bool Depuracion = false;
            //if (!Depuracion)
            //  ParteFinal1();
            if (ZZ.parser)
            {
                Console.WriteLine("despues de prog.locals = Tab.topScope.locals; Tab.CloseScope()");
                if (ZZ.readKey) Console.ReadKey();
                Tab.mostrarTab();
            };
        }//Fin Program
        Forms.TreeNode hijo1 = new System.Windows.Forms.TreeNode("Declaration = ConstDecl.");
                        ' Type ident '=' NumberOrCharConst");
                        Check(Token.CONST);  //const int i = 3;
            
            ;
            Code.cargaProgDeLaGram("Declarations = Declaration Declarations.");
            Code.cargaProgDeLaGram("Declaration = ConstDecl.");
            //token=const  laToken=int
            Struct type;
            //= new Struct(Struct.Kinds.None); se podria haber hecho de 2 modos mas: ref y x valor
            // en ambos casos necesito Struct type = new...; 
            Type(out type); //En ConstDecl()  /
            + type.kind.ToString());
            if (type != Tab.intType && type != Tab.charType)
            {
                Errors.Error("el tipo de una def de const sólo puede ser int o char");
            }
            Check(Token.IDENT);
            
            
            if ( ;
            //token quedó con i, laToken con =
            // debo agregar a la tabla de símbolos un nuevo símbolo  
            Symbol constante = Tab.Insert(Symbol.Kinds.Const, token.str, type);
            if (ZZ.parser)
                Console.WriteLine("termina de insertar constante con type = " + type.kind);
            Check(Token.ASSIGN);  //const
            olorear("token"); if (
            //token quedó con =, laToken con 10
            
                        switch (la)
            {
                case Token.NUMBER:
                    {
                        if (type != Tab.intType) Errors.Error("type debe ser int");
                        Check(Token.NUMBER);
                        
                        ////
                        
                        ////
                        if (
                        constante.val = token.val;
                        break;
                    }
                case Token.CHARCONST:
                    {
                        if (type != Tab.charType) Errors.Error("type debe ser char");
                        Check(Token.CHARCONST);
                        
                         if (
                        constante.val = token.val;
                        break;
                    }
                default:
                    {
                        Errors.Error("def de const erronea");
                        break;
                    }
            }
            if (ZZ.parser)
                Console.WriteLine("Ahora actualizó el valor");
            if (ZZ.parser)
                Tab.mostrarTab();
            Check(Token.SEMICOLON);
            
            Fin ConstDecl
        //NUEVA FUNCION RECURSIVA QUE CUELGA LOS IDENTIFIEROPC
        {
            if (la == Token.COMMA && la != Token.EOF)
            {

                Scan();
                
                Code.cargaProgDeLaGram("IdentifiersOpc = ',' ident  IdentifiersOpc.");//deberia extender el arbol
                uestraProducciones
                Check(Token.IDENT); //otro identif
                if (muestraProducciones
                
                                
                                //FGF INICIO 23/10
                cantVarLocales++;
                Symbol vble = Tab.Insert(kind, token.str, type);
                Code.CreateMetadata(vble);
                //FGF FIN  580 Identif
                Identifieropc(identifieropc1, type, kind);
            }
            else
            
                xpandAll();
            }
        }//Fin Identifieropc
        //si es "int[] pos" y viene de "Class Tabla {", kind es "Field"
            // si es Tabla val y viene de "class P {", kind es "Global"
            Struct type;// = new Struct(Struct.Kinds.None); //int i;
            
            if (
            Code.cargaProgDeLaGram("VarDecl = Type  ident IdentifiersOpc ';'");
            //-------------------------------------------------Grupo 2 28/9/2015----------------------------------------------------------------------- 
            //type
                                    
            //-------------------------------------------------Grupo 2 28/9/2015----------------------------------------------------------------------- 
            Type(out type);  //En VardDecl
                                //int[] en el caso del "int[] pos",... int, Table, Persona, int[], etc  
                                //Table en el caso de Table val;
                                //int en int x;
                                //-------------------------------------------------Grupo 2 28/9/2015----------------------------------------------------------------------- 
            
            
                        
            //-------------------------------------------------Grupo 2 28/9/2015----------------------------------------------------------------------- 
            
            //-------------------------------------------------Grupo 2 28/9/2015
            //-------------------------------------------------<GrupoUnico2017>----------------------------------------------------------------------- 

            if (type.kind.ToString() == "Arr")
            {
                
                ------------------------------<test>-----------------------
                                                Check(Token.IDENT); // "pos", en int pos,   .....int,....  x, i, etc
                
                // Hace referencia a la 
                
                
                                Symbol vble = Tab.Insert(kind, token.str, type);
                //vble no, poner simbolo (para pos, en int[] pos)
                //pues en este caso  es campo, y devuelve el Symbol p/pos,  type es int[]
                //puede ser val, en Tabla val, y type es Table //y devuelve el Symbol p/val
                Code.CreateMetadata(vble); //Para el campo pos (en int[] pos)Global, Field o .....
                                            //o Para la vbe Global val
                                            //o para x en int x;
                
                Identifieropc(hijo2, type, kind);

                
                Check(Token.SEMICOLON)
                
                
                eleccLaProdEnLaGram(8);
                Code.cargaProgDeLaGram("IdentifiersOpc = .");
                //------------------------------</test>-----------------------
            }
            else
            {
                upoUnico2017>----------------------------------------------------------------------- 

                                                //-------------------------------------------------Grupo 2 28/9/2015----------------------------------------------------------------------- 
                Check(Token.IDENT); // "pos", en int pos,   .....int,....  x, i, etc
                
                // Hace referencia a la 
                
                
                                //-------------------------------------------------Grupo 2 28/9/2015----------------------------------------------------------------------- 
                ////
                // debo insertar el token en la tabla de símbolos
                cantVarLocales++; //provisorio: esto deberia hacerlo solo para el caso de var locales (no para var globales)
                Symbol vble = Tab.Insert(kind, token.str, type);
                //vble no, poner simbolo (para pos, en int[] pos)
                //pues en este caso  es campo, y devuelve el Symbol p/pos,  type es int[]
                //puede ser val, en Tabla val, y type es Table //y devuelve el Symbol p/val
                Code.CreateMetadata(vble); //Para el campo pos (en int[] pos)Global, Field o .....
                                            //o Para la vbe Global val
                                            //o para x en int x;
                
                Identifieropc(hijo2, type, kind);
                
                Check(Token.SEMICOLON)
                
                
                eleccLaProdEnLaGram(8);
                //-------------------------------------------------Grupo 2 28/9/2015-----------------------------------------------------------------------
                Code.cargaProgDeLaGram("IdentifiersOpc = .");
            }
        }//Fin VardDecl
        TreeNode methodDecl = new System.Windows.Forms.TreeNode("MethodDecl"); //cuelga ESTE NODO DESPUES DE pintar el void
            Struct type = new Struct(Struct.Kinds.None);
            //Pone por defecto void
            if (la == Token.VOID || la == Token.IDENT)
            {
                if (la == Token.VOID)
                {
                    
                    Check(Token.VOID); //token = void laToken = Main
                                        ///// Agrega 'MethodDecl' al arbol y lo cuelga de MethodDeclsOpc
                                                                                ///// Agrega 'TypeOrVoid' al arbol y lo cuelga de MethodDecl
                                                                                ///// Agrega 'void' al arbol y lo cuelga de typeorvoid
                    ;
                    typeOrVoid.Expand()
                    
                    type = Tab.noType; //  para void
                }
                else
                    if (la == Token.IDENT)
                {
                    Type(out type);  //  token = UnTipo laToken = Main
                    
                    /////////// Agrega 'Type' al arbol y lo cuelga de typeorvoid
                    
                                        ind.ToString());
                                    }
                                
                Check(Token.IDENT);  //Main por ej.  //token = Main, laToken = "("
                
                curMethod = Tab.Insert(Symbol.Kinds.Meth, token.str, type);//inserta void Main 
                Tab.OpenScope(curMethod);
                oken.LPAR);  //Si Main() => no tiene FormPars
                
                ///// Agrega 'pars' a MethodDecl
                
                                               if (la == Token.IDENT)
                {
                    FormPars(pars);  //Aqui hay que crear los symbolos para los args 
                      //pinta el ")"
                    oken.RPAR);
                }
                else
                {
                    //infiere que no hay params => 1) debe venir un ")". 2) La pocion de la produccion es "."
                      //pinta el ")"
                    Check(Token.RPAR);
                    
                    xpandAll();
                                    //Comienza Nodo Declaration.
                
                                               //bool encuentraDecl = false;
                Code.CreateMetadata(curMethod);  //genera il
                //Declaraciones  por ahora solo decl de var, luego habria q agregar const y clases
                while (la != Token.LBRACE && la != Token.EOF)
                //void Main()==> int x,i; {val = new Table;....}
                {
                    if (la == Token.IDENT)
                    {
                        //encuentraDecl = true;
                         //colorea "int"  en int i; 
                        //Infiere la 2° opcion de PosDeclars   aaaaaaaa
                        
                                                                        
                        
                                                                        
                        VardDecl(Symbol.Kinds.Local, varDecl); // int x,i; en MethodDecl()  con int ya consumido
                    }
                    else
                    {
                        token = laToken;
                        Errors.Error("espero una declaracion de variable");
                    }
                }
                //Termina Vardecl.
                

                if (cantVarLocales > 0)
                {
                    //----------------------------------<test>--------------------------------------------
                    Symbol actual = Tab.topScope.locals, ultimo = null;
                    int descontador = 0;
                    int contadordearreglos = 0;
                    while (actual != null)  //Fran sólo es necesario buscar en el Scope actual
                    {
                        ultimo = actual;
                        actual = actual.next;
                    }
                    actual = Tab.topScope.locals;
                    //string instrParaVarsLocs = ".locals init(int32 V_0";
                    // Dentro del for originalmente va i=1, con el test va cantVarLocales-descontador+contadordearreglos+1
                    string instrParaVarsLocs = ".locals init(";
                    //for (int i = 0; i < cantVarLocales-descontador+contadordearreglos+1; i++)
                    int i = 0;
                    while (actual != null)
                    {
                        instrParaVarsLocs = instrParaVarsLocs + "," + "\n       int32 V_" + i.ToString(); // +"  ";
                        actual = actual.next;
                        i++;
                    }

                    //----------------------------------</test>--------------------------------------------
                    instrParaVarsLocs = instrParaVarsLocs + ")";
                    Code.cargaInstr(instrParaVarsLocs);

                }
                                
                xpandAll();
                                  
                                //Comienza Block
                Block(methodDecl);  //Bloque dentro de MethodDecl() 
                curMethod.nArgs = Tab.topScope.nArgs;
                curMethod.nLocs = Tab.topScope.nLocs;
                curMethod.locals = Tab.topScope.locals;
                Tab.CloseScope();
                Tab.mostrarTab();
                Code.il.Emit(Code.RET);  //si lo saco se clava en el InvokeMember
                Parser.nroDeInstrCorriente++;
                Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.ret;
                Code.cargaInstr("ret");
            }
        }//Fin MethodDecl
        new Struct(Struct.Kinds.None);
            if (la == Token.IDENT)
            {
                Type(out type); // 
                
                Code.cargaProgDeLaGram("PossFormPars = FormPar CommaFormParsOpc.");
                
                Check(Token.IDENT);
                
                while (la == Token.COMMA && la != Token.EOF)
                {
                    Check(Token.COMMA);
                    Code.cargaProgDeLaGram("CommaFormParsOpc = ',' FormPar CommaFormParsOpc.");
                    
                    Type(out type);
                    Check(Token.IDENT);
                    
                    Code.cargaProgDeLaGram("PossFormPars = FormPar CommaFormParsOpc.");
                    
                }//Fin while
                Code.cargaProgDeLaGram("CommaFormParsOpc = .");
            }
        }//Fin FormPars
        static void Type(out Struct xType)
        {
            
            Code.cargaProgDeLaGram("Type = ident LbrackOpc.");
            if (la != Token.IDENT)  //debe venir un tipo (int por ej)
            {
                Errors.Error("espera un tipo");
                xType = Tab.noType;
            }
            else
            {
                Check(Token.IDENT); //=> token=int y laToken=[,  .....token=int y laToken=size, en int size 
                                    //i viene de... yaPintado = true => no pinta nada

                Symbol sym = Tab.Find(token.str);  //busca int  y devuelve el Symbol p/int
                                                    //Busca Table y devuelve el Symbol p/Table
                if (ZZ.parser)
                    Console.WriteLine("Tab.Find(" + token.str + ") =>" + sym.ToString() + "..."); //if (ZZ.readKey) Console.ReadKey();
                if (sym == null)
                {
                    Errors.Error("debe venir un tipo");//Fran
                    xType = Tab.noType;
                }
                else
                {
                    xType = sym.type; //Devuelve int como tipo (Struct), no como nodo Symbol 
                };
                //n "[" o lo que sigue al type (un ident en int ident1)
                if (la == Token.LBRACK)  // 
                {
                    Code.cargaProgDeLaGram("LbrackOpc = '[' number ']'.");
                    Check(Token.LBRACK);
                    int n = getnumber(Token.NUMBER);
                    Check(Token.NUMBER);

                    Check(Token.RBRACK);                  //int tipo del elem del array

                    xType = new Struct(Struct.Kinds.Arr, sym.type);
                    //podria haber sido xType (Struct del int) en vez de sym.type  
                    //el nuevo xType que obtiene es un array de int
                }
                else Code.cargaProgDeLaGram("LbrackOpc = .");
            }
        }//Fin Type 
        Console.WriteLine("Comienza statement:" + laToken.str);
            if (la == Token.IDENT)
            {
                 //laToken (ident)  "writeln"  ya pintado  o "var1" en var1 = 10;
                Item itemIzq, itemDer; // = new Item();  // 
                  //scroll needed
                                                //-------------------------------------------------Grupo 2 28/9/2015-----------------------------------------------------------
                
                                
                //-------------------------------------------------Grupo 2 28/9/2015-----------------------------------------------------------
                Designator(out itemIzq, designator); //val   en statement
                String parteFinalDelDesign = token.str;
                //-------------------------------------------------Grupo 2 28/9/2015-----------------------------------------------------------
                
                                                
                                
                //-------------------------------------------------Grupo 2 28/9/2015-----------------------------------------------------------
                if (ZZ.parser)
                    Console.WriteLine("pasa el Designator()");
                switch (la)
                {
                    case Token.ASSIGN:  //asignacion  Designator = ....
                        {
                            Check(Token.ASSIGN);
                            
                            //-------------------------------------------------Grupo 2 30/9/2015-----------------------------------------------------------
                            xpandAll();
                            //------------------------------------------------unico grupo 2017------------------------------------------------------------
                            if (la == 27)
                            {
                                
                                
                                                                //ArrayDecl();
                            }
                            else
                            {
                                
                                
                                                                Expr(out itemDer, nexpr);
                                Code.Load(itemDer);
                                Code.Assign(itemIzq, itemDer, nexpr);
                            }
                            //-------------------------------------------------Grupo 2 30/9/2015-----------------------------------------------------------
                            Expr(out itemDer, nexpr);
                            Code.Load(itemDer);
                            Code.Assign(itemIzq, itemDer, nexpr);*/
                            if (ZZ.parser)
                            {
                                Console.WriteLine("Termina statement de asign: ..." + parteFinalDelDesign
                                    + " = ....." + Token.names[token.kind] + " str=" + token.str);
                                if (ZZ.readKey) Console.ReadKey();
                            };
                            break;
                        }
                    case Token.LPAR:   //Designator(....  metodo(.....
                        {
                            Check(Token.LPAR);
                            if (la == Token.MINUS || la == Token.IDENT ||
                                la == Token.NUMBER || la == Token.CHARCONST ||
                                la == Token.NEW || la == Token.LPAR)
                                ActPars();
                            Check(Token.RPAR);
                            break;
                        }
                    case Token.PPLUS: // Designator++   var++
                        {
                            Check(Token.PPLUS);
                            Z.parser) Console.WriteLine("reconoció el ++"); //zzzzzz
                            break;
                        }
                    case Token.MMINUS:
                        {
                            Check(Token.MMINUS);
                                                    }
                }
                Check(Token.SEMICOLON);//falta nodo aca//
            }
            else
            {
                Item item, itemAncho;
                switch (la)
                {
                    case Token.IF:
                        int nroInstrParaRectificarElIf;
                        Item x; Label end;
                        Check(Token.IF);

                                                Check(Token.LPAR);
                        ut x);
                        
                                                if (ZZ.parser) Console.WriteLine("reconoció la cond del if");
                        Check(Token.RPAR);
                        Jump(x);  //dentro del if (i<10) 
                                        //Code.FJump(x) => bge x.fLabel, i.e. si >= debe ir a x.fLabel (debe saltar el then)
                                        //x.fLabel está indefinido, luego habrá un  //luego habrà un Code.il.MarkLabel(x.fLabel);

                        //Code.FJump(x)=> Parser.cil[Parser.nroDeInstrCorriente]...=> bge -1 (por ej) 
                        nroInstrParaRectificarElIf = Parser.nroDeInstrCorriente;
                        //luego habrà un Parser.cil[nroInstrParaRectificarElIf].nroLinea = label...
                        //reemplazando "bge -1" con "bge label..."
                        //////////
                        
                                                /////////
                        Statement(nstatement); //en el if de una statement
                        if (ZZ.parser) Console.WriteLine("reconoció la Statem del if");
                        if (la == Token.ELSE)
                        {
                            Check(Token.ELSE);
                            ///////////
                            
                                                        //////////
                            end = Code.il.DefineLabel();
                            int endMio = -1;
                            Code.Jump(end);  //=> il.Emit(BR, end); 
                            Parser.nroDeInstrCorriente++;
                            Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.branchInc;
                            Parser.cil[Parser.nroDeInstrCorriente].nroLinea = endMio;  //Br Incond está indefinido
                            Code.cargaInstr("br" + "  " + Parser.cil[Parser.nroDeInstrCorriente].nroLinea.ToString());
                            //br end => br -1
                            int nroInstrParaRectificarElEndDelIf = Parser.nroDeInstrCorriente;

                            Code.il.MarkLabel(x.fLabel);
                            markLabelMio(nroInstrParaRectificarElIf, nelse);//agregar una nop
                                                                            //más: ir a la linea correspondiente y marcar el label con la instr corriente
                                                                            //más: reescribe cil (nuevoRichTexBox3) rectificando la marca

                            Statement(nelse);  //en el else de una statemnet
                            if (ZZ.parser) Console.WriteLine("reconoció la Statem del else del if");
                            Code.il.MarkLabel(end);
                            markLabelMio(nroInstrParaRectificarElEndDelIf, nelse);//agregar una nop
                                                                                    //más: ir a la linea correspondiente y marcar el label con la instr corriente
                                                                                    //más: reescribe cil (nuevoRichTexBox3) rectificando la marca
                        }
                        else
                        {
                            Code.il.MarkLabel(x.fLabel);
                            markLabelMio(nroInstrParaRectificarElIf, nstatement);//agregar una nop
                                                                                    //más: ir a la linea correspondiente y marcar el label con la instr corriente
                                                                                    //más: reescribe cil (nuevoRichTexBox3) rectificando la marca
                        }
                        break;

                    case Token.WHILE:
                        //Item x;
                        int nroInstrParaRectificarElWhile;
                        Check(Token.WHILE);

                                                Label top = Code.il.DefineLabel();
                        int topMio = -1;
                        Code.il.MarkLabel(top);
                        topMio = Parser.nroDeInstrCorriente + 1; //(instr sig a la actual)
                                                                    //para luego..Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.branchInc;
                                                                    //Parser.cil[Parser.nroDeInstrCorriente].nroLinea = topMio;  //Br Incond está definido
                        Check(Token.LPAR);
                        Condition(out x);
                        
                        if (ZZ.parser) { Console.WriteLine("Termina con la cond del while"); };
                        Check(Token.RPAR);
                        Code.FJump(x); //dentro del while (i<10) 
                                        //Code.FJump(x) => bge x.fLabel, i.e. si >= debe ir a x.fLabel (debe salir del loop)
                                        //x.fLabel está indefinido, luego habrá un  //luego habrà un Code.il.MarkLabel(x.fLabel);
                                        //Code.FJump(x)=> Parser.cil[Parser.nroDeInstrCorriente]...=> bge -1 (por ej) 
                        nroInstrParaRectificarElWhile = Parser.nroDeInstrCorriente;
                        //luego habrà un Parser.cil[nroInstrParaRectificarElWhile].nroLinea = label...
                        //reemplazando "bge -1" con "bge label..."
                        Check(Token.LBRACE);
                        erpo del while  
                        while (la != Token.RBRACE && la != Token.EOF)
                        {
                            
                                                        Statement(nstatement2);
                        } //dentro del while
                        Check(Token.RBRACE);
                        Z.parser) { Console.WriteLine("Termina statement while"); if (ZZ.readKey) Console.ReadKey(); };
                        Code.Jump(top);
                        Parser.nroDeInstrCorriente++;
                        Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.branchInc;
                        Parser.cil[Parser.nroDeInstrCorriente].nroLinea = topMio;  //Br Incond está definido
                        Code.cargaInstr("br" + "  " + Parser.cil[Parser.nroDeInstrCorriente].nroLinea.ToString());
                        //br top
                        Code.il.MarkLabel(x.fLabel);
                        //agregar una nop
                        Parser.nroDeInstrCorriente++;
                        Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.nop;
                        //Parser.cil[Parser.nroDeInstrCorriente].instrString =
                        Code.cargaInstr("nop   ");
                        //ir a la linea correspondiente y marcar el label con la instr corriente
                        Parser.cil[nroInstrParaRectificarElWhile].nroLinea = nroDeInstrCorriente;//Br cond ahora está definido
                        Parser.cil[nroInstrParaRectificarElWhile].instrString =
                            Parser.cil[nroInstrParaRectificarElWhile].instrString.Substring(0,
                                Parser.cil[nroInstrParaRectificarElWhile].instrString.Length - 2)
                                + nroDeInstrCorriente.ToString();
                        Program1.form1.richTextBox3.Text = "";
                        //System.Windows.Forms.MessageBox.Show("empieza......");
                        //reescribe cil (nuevoRichTexBox3) rectificando la marca
                        string nuevoRichTexBox3 = cil[0].instrString;
                        for (int i = 1; i <= nroDeInstrCorriente; i++)
                        {
                            nuevoRichTexBox3 = nuevoRichTexBox3 + "\n" + cil[i].instrString;
                        }
                        Program1.form1.richTextBox3.Text = nuevoRichTexBox3;
                        break;
                    case Token.BREAK:
                        Check(Token.BREAK);
                        Check(Token.SEMICOLON);
                        break;
                    case Token.RETURN:
                        Check(Token.RETURN);
                        // First(Expr)
                        if (la == Token.MINUS || la == Token.IDENT || la == Token.NUMBER ||
                            la == Token.CHARCONST || la == Token.NEW || la == Token.LPAR)
                            Expr(out item, null);//Falta procesar
                        Check(Token.SEMICOLON);
                        break;
                    case Token.READ:
                        Check(Token.READ);
                        Check(Token.LPAR);
                        if (la == Token.IDENT)
                            Designator(out item, null);//En el READ
                        Check(Token.RPAR);
                        Check(Token.SEMICOLON);
                        //ZZ.parser = true; 
                        if (ZZ.parser) Console.WriteLine("reconoció el Read");
                        break;
                    case Token.WRITELN: /// En Statement G3 PERUWRITELN
                        //token queda con ";" y laToken = WRITELN y ch con '('               
                        ///////////////////////// Este bloque agrega y muestra writeln en el arbol y selecciona la gramatica
                        Check(Token.WRITELN);

                                                
                        

                        ////////////////////////// 

                        //token queda con WRITELN y laToken =  "(" y ch con Comm Doble
                        //equivalente a Check(Token.LPAR);
                        //debe quedar token = "("  y laToken = "texto posiblem vacio"               
                        if (la == Token.LPAR) //ch = Comm Doble
                        {
                            //Scan(); //token = "("
                            ////////////////////////// Agrega '(' al arbol y lo muestra
                            xpandAll(); // G3 ;
                            //////////////////////////
                             //pinta el "("
                             //solo para que deje yaPintado en false

                            if (Scanner.ch != '\"')
                                Errors.Error("Se esperaba una COMILLA DOBLE");
                            else
                            {
                                string argStr = "";
                                Scanner.NextCh(); //ch = 2º com doble o Primer char del argStr

                                while (Scanner.ch != '\"')
                                {
                                    //if (ch == EOF) return new Token(Token.EOF, line, col);
                                    argStr = argStr + Scanner.ch.ToString();
                                    Scanner.NextCh();  //ch = 2º char del argStr o Com Doble
                                }
                                //ch = Com Doble
                                token = new Token(Scanner.line, Scanner.col);
                                token.kind = Token.COMILLADOBLE; //se va a llamar argDeWriteLine
                                token.str = argStr; // excluye las comillas dobles
                                                    //token.line lo deja =
                                token.col = token.col - argStr.Length; //+ 1; // -3; //DESPUES DEL "("

                                ////////////////////////////  Agrega 'argString' al arbol y lo muestra 
                                 // G3 ;
                                

                                ////////////////////////////
                                Parser.nroDeInstrCorriente++;
                                //Agregar  ldString  argStr, 
                                Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.ldstr;
                                Parser.cil[Parser.nroDeInstrCorriente].argDelWriteLine = argStr;

                                muestraCargaDeInstrs = false; // -- G3 -  (Es para que no muestre la pantalla)
                                Code.cargaInstr("ldstr \"" + argStr + "\" ");
                                muestraCargaDeInstrs = true; // -- G3 -

                                Parser.nroDeInstrCorriente++;
                                Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.writeln;
                                muestraCargaDeInstrs = false; // -- G3 - (Es para que no muestre la pantalla)
                                Code.cargaInstr("call writeln#(string)");
                                muestraCargaDeInstrs = true; // -- G3 -
                                                                //Parser.cil[Parser.nroDeInstrCorriente].nro = item.val; // item.val;           //item.val;  aaaaaaa 
                                                                //Parser.cil[Parser.nroDeInstrCorriente].argDelWriteLine = argStr;  //Provisorio ya no se usa argDelWriteLine


                                Scanner.NextCh(); //ch=")"
                                token = laToken; //token queda con argDeWriteLine
                                laToken = Scanner.Next(); //la token queda con ")"
                                la = laToken.kind;
                                Code.il.EmitWriteLine(argStr);

                                ////////////////////////////// Agrega ')' al arbol y lo muestra

                                Check(Token.RPAR);
                                
                                /////////////////////////////  Agrega ';' al arbol y lo muestra

                                                                Check(Token.SEMICOLON);
                                

                            }
                        }

                        break;
                    case Token.WRITE: ///  En Statement

                        // G3 - PERUWRITE
                        //////////////// Agrega 'write' al arbol y lo muestra y colorea
                        Check(Token.WRITE);

                                                

                                               /////////////////
                        ///////////////// Agrega '(' al arbol y lo muestra y colorea
                        Check(Token.LPAR);
                        de.Colorear("token");
                        ////////////////
                        //////////////// Agrega 'Expr' al arbol y lo muestra y colorea y selecciona la regla de Expr
                        
                                                
                        
                        ////////////////

                        // First(Expr)
                        if (la == Token.MINUS || la == Token.IDENT || la == Token.NUMBER ||
                            la == Token.CHARCONST || la == Token.NEW || la == Token.LPAR)
                            //Code.il.EmitWriteLine("dentro del WRITE, antes del Expr(out item)");

                            AA(out item); ///?????

                        Exprout item, expr1); // Crea la Expr
                        
                        if (la == Token.RBRACE) // Le provee 10 espacios de escritura sino manda ningun numero
                                                // Por ej. write(x);
                        {
                            olorear("latoken");
                        }
                        else
                        {
                            /////////////// Agrega ',' al arbol y lo muestra
                            Check(Token.COMMA);
                            
                            
                            /////////////// Agrega 'Expr' al arbol y lo muestra y seecciona la regla de Expr

                                                        
                            //////////////

                            Expr(out itemAncho, expr2);
                            Code.il.EmitCall(Code.CALL, Code.writeInt, null); //Probar   provisorio

                            Parser.nroDeInstrCorriente++;
                            Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.write;
                            Parser.cil[Parser.nroDeInstrCorriente].nro = item.val; // item.val;           //item.val;  aaaaaaa 

                            Code.cargaInstr("call write#(int32,int32)");
                            /////////////// Agrega ')' al arbol y lo muestra
                            
                            Check(Token.RPAR);
                            olorear("token");
                            ///////////////
                        
                        ////////////// Agrega ';' al arbol y lo muestra
                        Check(Token.SEMICOLON);
                        olorear("token");
                        ///////////////
                        break;
                    case Token.LBRACE:
                        
                                                Block(blockint);  //bloque(blockint = bloque interior)dentro de una sentencia
                        break;
                    case Token.SEMICOLON:
                        Check(Token.SEMICOLON);
                                            default:
                        Errors.Error("Espero una sentencia");
                        break;
                }
            }
        } // Fin Statement
        TreeNode block = new System.Windows.Forms.TreeNode("Block");
            
                        
            ////// Agrega '{' al arbol
            Check(Token.LBRACE);
            xpandAll();
            
            /////// Agrega 'StatementsOpc' al arbol
            
                        
            
            /////// Agrega '.' al arbol si el block esta vacio
            if (la == Token.RBRACE)
            {
                
                xpandAll();
            }
            int ii = 1;
            while (la != Token.RBRACE)
            {
                if ((la == Token.IDENT || la == Token.IF || la == Token.WHILE || la == Token.BREAK
                    || la == Token.RETURN || la == Token.READ || la == Token.WRITE || la == Token.WRITELN
                    || la == Token.LBRACE || la == Token.SEMICOLON) && la != Token.EOF)
                {
                    
                    
                                        
                    
                    if (ZZ.ParserStatem)
                    {
                        Console.WriteLine(".......Comienza statement nro:");
                        Console.Write(ii); Console.WriteLine("->" + laToken.str);
                    }

                    Statement(statement);  //dentro de block()

                }//Fin if 
                else
                {
                    token.line = Scanner.line; token.col = Scanner.col - 1;
                    token.str = "?";
                    Errors.Error("Espero una sentencia");
                }
                ii++;
                
            }//Fin 
            Check(Token.RBRACE);
            
            olorear("token");
        }//Fin Block
        static void ActPars()
        {
            Item item;
            Expr(out item, null);
            while (la == Token.COMMA && la != Token.EOF)
            {
                Check(Token.COMMA);
                Expr(out item, null);
            }
        }//Fin ActPars
        static void Condition(out Item x)
        {
            Item y;
            CondTerm(out x);
            while (la == Token.OR && la != Token.EOF)
            {
                Check(Token.OR);
                Code.TJump(x);
                Code.il.MarkLabel(x.fLabel);
                CondTerm(out y);
                x.relop = y.relop; x.fLabel = y.fLabel;
            }
        }//Fin Condition
        TreeNode hijo = new System.Windows.Forms.TreeNode("Término");
                        CondTerm(hijo);
            while (la == Token.OR && la != Token.EOF)
            {
                Check(Token.OR);
                
                                CondTerm(hijo1);
            }
        }//Fin Condition
        static void CondTerm(out Item x)
        {
            Item y;
            CondFact(out x);
            while (la == Token.AND && la != Token.EOF)
            {
                Check(Token.AND);
                Code.FJump(x);
                CondFact(out y);
                x.relop = y.relop; x.tLabel = y.tLabel;
            }
        }//Fin CondTerm
        TreeNode hijo = new System.Windows.Forms.TreeNode("Factor");
                        CondFact(hijo);
            while (la == Token.AND && la != Token.EOF)
            {
                Check(Token.AND);
                
                                CondFact(hijo1);
            }
        }//Fin CondTerm
        static void Expr(out Item item)
        {
            OpCode op; Item itemSig;

            if (la == Token.MINUS)
            {
                Check(Token.MINUS);
                Term(out item, null);  //
                if (item.type != Tab.intType) Errors.Error("Operando debe ser de tipo int");
                if (item.kind == Item.Kinds.Const) item.val = -item.val;
                else
                {
                    Code.Load(item); Code.il.Emit(Code.NEG);
                };
            }
            else
            {
                Code.cargaProgDeLaGram("OpcMinus = .");
                Code.cargaProgDeLaGram("Term = Factor  OpcMulopFactor.");
                Code.cargaProgDeLaGram("Factor = Designator  OpcRestOfMethCall.");
                Code.cargaProgDeLaGram("Designator = ident opcRestOfDesignator.");
                //1º parte de Term (y de Factor), por ej 
                Term(out item);
            }
            string opString = "";
            while ((la == Token.PLUS || la == Token.MINUS) && la != Token.EOF)
            {
                Code.cargaProgDeLaGram("OpcAddopTerm = Addop Term.");
                if (la == Token.PLUS)
                {
                    Scan(); op = Code.ADD; opString = "add       ";

                    Code.cargaProgDeLaGram("Addop = '+'.");
                    Code.cargaProgDeLaGram("Term = Factor OpcMulopFactor.");
                                   }
                else if (la == Token.MINUS)
                {
                    Scan(); op = Code.SUB; opString = "sub       "; Code.cargaProgDeLaGram("Addop = '-'.");

                    Code.cargaProgDeLaGram("Addop = '-'.");
                    Code.cargaProgDeLaGram("Term = Factor OpcMulopFactor.");
                                   }
                else op = Code.DUP;
                
                Code.Load(item);
                Term(out itemSig);
                Code.Load(itemSig);
                if (item.type != Tab.intType || itemSig.type != Tab.intType)
                    Errors.Error("Los operandos deben ser de tipo int");

                nroDeInstrCorriente++;
                Code.il.Emit(op);
                Code.cargaInstr(opString);
                if (op == Code.ADD)
                    cil[nroDeInstrCorriente].accionInstr = AccionInstr.add;
                else if (op == Code.SUB)
                    cil[nroDeInstrCorriente].accionInstr = AccionInstr.sub;
                else
                    System.Windows.Forms.MessageBox.Show("aun no implementado 343323");
            }//Fin While
        }//Fin Expr
        static void CondFact(out Item x)
        {
            Item y; int op;
            Expr(out x); Code.Load(x);
            Relop(out op);
            Expr(out y); Code.Load(y);
            if (!x.type.CompatibleWith(y.type))
                Errors.Error("type mismatch");
            else if (x.type.IsRefType() &&
                    op != Token.EQ && op != Token.NE)
                Errors.Error("only equality checks ...");
            x = new Item(op, x.type);
        }//Fin CondFact
        TreeNode hijo1 = new System.Windows.Forms.TreeNode("Expresión");
                        Item item1, item2;
            Expr(out item1, hijo1);
            
                        Relop(hijo2);
            
                        Expr(out item2, hijo3);
        }//Fin CondFact
        //Inicio Modificación - Grupo 1 - 28/10/15 - Se Arregló Expr
        ; Item itemSig;
            System.Windows.Forms.TreeNode OpcMinus = new System.Windows.Forms.TreeNode("OpcMinus");
            

            if (la == Token.MINUS)
            {
                Check(Token.MINUS);
                                
                                Parser.Term(out item, Term);
                if (item.type != Tab.intType)
                    Errors.Error("Operando debe ser de tipo int");
                if (item.kind == Item.Kinds.Const)
                    item.val = -item.val;
                else
                    Code.Load(item); Code.il.Emit(Code.NEG);
            }
            else
            {
                if (la == Token.NUMBER)
                {
                    
                    xpandAll();
                    Parser.Term(out item, Term);
                }
                else
                {
                    
                    xpandAll();
                                        
                                        Parser.Term(out item, Term);
                }
            }
            string opString = "";
            
                        bool existe_Addop_opc = false;
            while ((la == Token.PLUS || la == Token.MINUS) && la != Token.EOF)
            {
                
                                
                existe_Addop_opc = true;
                if (la == Token.PLUS)
                {
                    Scan();
                    op = Code.ADD;
                    opString = "add       ";
                    
                    xpandAll();
                }
                else if (la == Token.MINUS)
                {
                    Scan();
                    op = Code.SUB;
                    opString = "sub       ";
                    Code.cargaProgDeLaGram("AddOp = '-'.");
                    
                    xpandAll();
                }
                else op = Code.DUP;
                
                Code.Load(item);
                
                                Parser.Term(out itemSig, Term_OpcAddop);
                Code.Load(itemSig);
                //-------------------------------------------<test>-----------------------------------------------
                if (item.type != Tab.intType || itemSig.type != Tab.intType)
                    if (item.type.kind.ToString() != "Arr" && itemSig.type.kind.ToString() != "Arr")
                        if (item.type.kind.ToString() != "Arr" && itemSig.type != Tab.intType)
                            if (item.type != Tab.intType && itemSig.type.kind.ToString() != "Arr")
                                Errors.Error("Los operandos deben ser de tipo int");
                //-------------------------------------------<test>-----------------------------------------------
                //if (item.type != Tab.intType || itemSig.type != Tab.intType)
                //   Errors.Error("Los operandos deben ser de tipo int");
                nroDeInstrCorriente++;
                Code.il.Emit(op);
                Code.cargaInstr(opString);
                if (op == Code.ADD)
                    cil[nroDeInstrCorriente].accionInstr = AccionInstr.add;
                else if (op == Code.SUB)
                    cil[nroDeInstrCorriente].accionInstr = AccionInstr.sub;
                else
                    System.Windows.Forms.MessageBox.Show("Aun no implementado 343323");
            }//Fin While

            if (existe_Addop_opc == false)
            {
                
                
            }
        }//Fin Expr
        static void Designator(out Item item)
        {
            Check(Token.IDENT);
            
            Code.cargaProgDeLaGram("Designator = ident  opcRestOfDesignator.");
            Symbol sym = Tab.Find(token.str);
            if (ZZ.ParserStatem)
                Console.WriteLine("token.str:" + token.str);
            if (sym == null)
                Errors.Error(sym.name + "..no está en la Tab");
            item = new Item(sym);
            if ((la == Token.PERIOD || la == Token.LBRACK) && la != Token.EOF)
            {
                while ((la == Token.PERIOD || la == Token.LBRACK) && la != Token.EOF)
                {
                    if (ZZ.parser) Console.Write("field..." + token.str + " (val)");
                    if (la == Token.PERIOD)
                    {
                        Check(Token.PERIOD);
                        Code.cargaProgDeLaGram("opcRestOfDesignator =  '.' ident.");
                        
                        if (muestraProducciones
                        Check(Token.IDENT);
                        
                        if (muestraProducciones
                        if (ZZ.parser)
                            Console.WriteLine(" . " + token.str + " (pos)");
                        if (item.type.kind == Struct.Kinds.Class)
                        {
                            Code.Load(item);
                            Symbol symField = Tab.FindSymbol(token.str, sym.type.fields);
                            Struct xTypeField;
                            if (symField == null)
                            {
                                Errors.Error("..--debe venir un tipo");
                                xTypeField = Tab.noType;
                            }
                            else
                            {
                                if (ZZ.parser) Console.WriteLine("encuentra " + symField.name);
                                xTypeField = symField.type; //Devuelve int como tipo (Struct), no como nodo Symbol 
                            };
                            item.sym = symField;
                            item.type = item.sym.type;
                        }
                        else Errors.Error(sym.name + " is not an object");
                        item.kind = Item.Kinds.Field;
                    }
                    else
                        if (la == Token.LBRACK)
                    {
                        Check(Token.LBRACK);
                        Code.cargaProgDeLaGram("opcRestOfDesignator =  '[' Expr ']'.");
                        
                        if (

                        Code.Load(item);
                        Item itemSig;
                        Expr(out itemSig);

                        if (item.type.kind == Struct.Kinds.Arr)
                        {
                            if (itemSig.type != Tab.intType) Errors.Error("index must be of type int");
                            Code.Load(itemSig);
                            itemSig.type = item.type.elemType;
                        }
                        else Errors.Error(sym.name + " is not an array");
                        item.kind = Item.Kinds.Elem;
                        Check(Token.RBRACK);
                    }
                }//Fin while
            }
            else
            {
                Code.cargaProgDeLaGram("opcRestOfDesignator =  .");
                
                if (muestraProducciones
                Code.Load(item);
            }
        }//Fin Designator
        static void Factor(out Item item)
        {
            Struct xType;
            if (la == Token.IDENT)
            {

                Designator(out item); //en el Factor
                if (la == Token.LPAR)
                {
                    Check(Token.LPAR);
                    Code.cargaProgDeLaGram("OpcRestOfMethCall = '(' OpcActPars ')'.");
                     // el "("
                    if (
                    if (la == Token.MINUS || la == Token.IDENT ||
                        la == Token.NUMBER || la == Token.CHARCONST ||
                        la == Token.NEW || la == Token.LPAR)
                        ActPars();
                    Check(Token.RPAR);
                }
                else
                {
                    Code.cargaProgDeLaGram("OpcRestOfMethCall = .");
                     // el "("
                    if (
                }
            }
            else
                switch (la)
                {
                    case Token.NUMBER:
                        {
                            Check(Token.NUMBER);
                            Code.cargaProgDeLaGram("Factor = number.");
                                                       item = new Item(token.val);//Nuevo
                            Code.Load(item);
                            break;
                        }
                    case Token.CHARCONST:
                        {
                            Check(Token.CHARCONST);
                            item = new Item(token.val); item.type = Tab.charType;
                            break;
                        }
                    case Token.NEW:
                        {
                            Check(Token.NEW);
                            Check(Token.IDENT);  //Deberia buscar en la Tab y verificar que sea un Tipo o una clase 
                            Symbol sym = Tab.Find(token.str);  //ident debe ser int, char, o una clase  (Table)
                            if (sym.kind != Symbol.Kinds.Type) Errors.Error("type expected");
                            Struct type = sym.type;
                            //si es clase, sym.type contiene un puntero a los campos de esa clase
                            if (ZZ.parser)
                                Console.WriteLine("Tab.Find(" + token.str + ") =>" + sym.ToString() + "...");
                            if (sym == null)
                            {
                                Errors.Error("--debe venir un tipo");
                                xType = Tab.noType;
                            }
                            else
                            {
                                xType = sym.type; //Devuelve int como tipo (Struct), no como nodo Symbol 
                                if (ZZ.parser) Console.WriteLine("Encontró " + token.str);
                            };
                            if (ZZ.parser) Console.WriteLine("Terminó new " + token.str);

                            if (la == Token.LBRACK)
                            {
                                Check(Token.LBRACK);
                                Expr(out item);
                                if (item.type != Tab.intType) Errors.Error("array size must be of type int");
                                Code.Load(item); //genera cod p/cargar el result de la expr	
                                Code.il.Emit(Code.NEWARR, type.sysType); //NEWARR de char
                                type = new Struct(Struct.Kinds.Arr, type);
                                //el nuevo type será array de char (pag 33 de T de simb)
                                Check(Token.RBRACK);
                            }
                            else
                            {
                                if (sym.ctor == null)
                                {
                                    Console.WriteLine("Error sym.ctor == null"); if (ZZ.readKey) Console.ReadKey();
                                };
                                if (type.kind == Struct.Kinds.Class) //new Table  pag 34 de T. De Simb	  
                                    Code.il.Emit(Code.NEWOBJ, sym.ctor); //emite cod p/new Table  qq1

                                else { Errors.Error("class type expected"); type = Tab.noType; }
                            }
                            item = new Item(type);
                            break;
                        }
                    case Token.LPAR:
                        {
                            Check(Token.LPAR);
                            Expr(out item);
                            Check(Token.RPAR);
                            break;
                        }
                    default:
                        {
                            Errors.Error(ErrorStrings.INVALID_FACT);
                            item = new Item(3);
                            break;
                        }
                }
        }//Fin Factor
        static void Term(out Item item)
        {
            OpCode op; Item itemSig; string opString = "";
            if (la == Token.IDENT || la == Token.NUMBER || la == Token.CHARCONST || la == Token.NEW || la == Token.LPAR)
            {
                Factor(out item);
                while ((la == Token.TIMES || la == Token.SLASH || la == Token.REM) && la != Token.EOF)
                {
                    Code.cargaProgDeLaGram("OpcMulopFactor = Mulop Factor.");
                    switch (la)
                    {
                        case Token.TIMES:
                            {
                                Check(Token.TIMES); op = Code.MUL; opString = "mul       ";
                                
                                Code.cargaProgDeLaGram("Mulop =	'*'.");
                                if (
                                break;
                            }
                        case Token.SLASH:
                            {
                                Check(Token.SLASH); op = Code.DIV; opString = "div       ";
                                
                                Code.cargaProgDeLaGram("Mulop =	'/'.");
                                if (
                                break;
                            }
                        case Token.REM:
                            {
                                Check(Token.REM); op = Code.REM;
                                System.Windows.Forms.MessageBox.Show("aun no implementado");
                                break;
                            }
                        default:
                            {
                                Errors.Error(ErrorStrings.MUL_OP);
                                op = Code.REM;
                                break;
                            }
                    } //Fin switch
                    Code.Load(item);
                    Factor(out itemSig);
                    Code.Load(itemSig);
                    //-------------------------------------------<test>-----------------------------------
                    if (item.type != Tab.intType || itemSig.type != Tab.intType)
                        if (item.type.kind.ToString() != "Arr" && itemSig.type.kind.ToString() != "Arr")
                            if (item.type.kind.ToString() != "Arr" && itemSig.type != Tab.intType)
                                if (item.type != Tab.intType && itemSig.type.kind.ToString() != "Arr")
                                    Errors.Error("Debe venir un Term");
                    //------------------------------------------</test>----------------------------------------
                    Code.il.Emit(op);
                    nroDeInstrCorriente++;
                    Code.cargaInstr(opString);
                    if (op == Code.MUL)
                        cil[nroDeInstrCorriente].accionInstr = AccionInstr.mul;
                    else if (op == Code.DIV)
                        cil[nroDeInstrCorriente].accionInstr = AccionInstr.div;
                    else
                        System.Windows.Forms.MessageBox.Show("aun no implementado 343323");
                }//Fin while
                Code.cargaProgDeLaGram("OpcMulopFactor = .");
                           }
            else
            {
                Errors.Error("ErrorStrings.MUL_OP");
                item = new Item(0);
            }
        }//Fin Term
        ; Item itemSig; string opString = "";
            if (la == Token.IDENT || la == Token.NUMBER || la == Token.CHARCONST || la == Token.NEW || la == Token.LPAR)
            {
                
                                
                Parser.Factor(out item, Factor);
                bool existe_OpcMulOpFactor = false;

                
                                while ((la == Token.TIMES || la == Token.SLASH || la == Token.REM) && la != Token.EOF)
                {
                    Code.cargaProgDeLaGram("OpcMulopFactor = Mulop Factor.");
                    
                                        
                    switch (la)
                    {
                        case Token.TIMES:
                            {
                                Check(Token.TIMES);
                                op = Code.MUL;
                                opString = "mul       ";
                                
                                Code.cargaProgDeLaGram("Mulop =	'*'.");
                                existe_OpcMulOpFactor = true;
                                                                xpandAll();
                                break;
                            }
                        case Token.SLASH:
                            {
                                Check(Token.SLASH);
                                op = Code.DIV;
                                opString = "div       ";
                                existe_OpcMulOpFactor = true;
                                
                                Code.cargaProgDeLaGram("Mulop =	'/'.");
                                                                xpandAll();
                                break;
                            }
                        case Token.REM:
                            Check(Token.REM);
                            op = Code.REM;
                            System.Windows.Forms.MessageBox.Show("aun no implementado");
                            break;
                        default:
                            Errors.Error(ErrorStrings.MUL_OP);
                            op = Code.REM;
                            break;
                    } //Fin switch
                    Code.Load(item);
                    
                                        
                    Parser.Factor(out itemSig, Factor_OpcMulop);
                    Code.Load(itemSig);
                    //----------------------------------------------<test-mult-slash>----------------------------
                    if (item.type != Tab.intType || itemSig.type != Tab.intType)
                        if (item.type.kind.ToString() != "Arr" && itemSig.type.kind.ToString() != "Arr")
                            if (item.type.kind.ToString() != "Arr" && itemSig.type != Tab.intType)
                                if (item.type != Tab.intType && itemSig.type.kind.ToString() != "Arr")
                                    Errors.Error("Debe venir un Term");
                    //-----------------------------------------------</test-mult-slash>-------------------------
                    Code.il.Emit(op);
                    nroDeInstrCorriente++;
                    Code.cargaInstr(opString);
                    if (op == Code.MUL)
                        cil[nroDeInstrCorriente].accionInstr = AccionInstr.mul;
                    else if (op == Code.DIV)
                        cil[nroDeInstrCorriente].accionInstr = AccionInstr.div;
                    else
                        System.Windows.Forms.MessageBox.Show("aun no implementado 343323");
                }//Fin while
                if (existe_OpcMulOpFactor == false)
                {
                    xpandAll();
                    Code.cargaProgDeLaGram("OpcMulopFactor = .");
                    
                
            }
            else
            {
                Errors.Error("ErrorStrings.MUL_OP");
                item = new Item(0);
            }
        }//Fin Term
        ;
            if (la == Token.IDENT)
            {
                
                                
                Parser.Designator(out item, Designator); //en el Factor
                if (la == Token.LPAR)
                {
                    Check(Token.LPAR);
                    Code.cargaProgDeLaGram("OpcRestOfMethCall = '(' OpcActPars ')'.");
                     // el 
                    if (la == Token.MINUS || la == Token.IDENT || la == Token.NUMBER || la == Token.CHARCONST || la == Token.NEW || la == Token.LPAR)
                    {
                        ActPars();  //Esta parte falta
                    }
                    Check(Token.RPAR);
                }
                else
                {
                    Code.cargaProgDeLaGram("OpcRestOfMethCall = .");
                     // el 
                }
            }
            else
                switch (la)
                {
                    case Token.NUMBER:
                        {
                            Check(Token.NUMBER);
                            Code.cargaProgDeLaGram("Factor = number.");
                            
    
                                                        
                            item = new Item(token.val);//Nuevo
                                                        //--------------------------------------------<test>---------------------------
                            if (la != Token.RBRACK)
                            {
                                Code.Load(item);
                            }
                            //--------------------------------------------</test>--------------------------
                            break;
                        }
                    case Token.CHARCONST:
                        {
                            Check(Token.CHARCONST);
                            item = new Item(token.val); item.type = Tab.charType;
                            break;
                        }
                    case Token.NEW:
                        {
                            Check(Token.NEW);
                            Check(Token.IDENT);  //Deberia buscar en la Tab y verificar que sea un Tipo o una clase 
                            Symbol sym = Tab.Find(token.str);  //ident debe ser int, char, o una clase  (Table)
                            if (sym.kind != Symbol.Kinds.Type)
                                Errors.Error("type expected");
                            Struct type = sym.type;
                            //si es clase, sym.type contiene un puntero a los campos de esa clase
                            if (ZZ.parser)
                                Console.WriteLine("Tab.Find(" + token.str + ") =>" + sym.ToString() + "...");
                            if (sym == null)
                            {
                                Errors.Error("--debe venir un tipo");
                                xType = Tab.noType;
                            }
                            else
                            {
                                xType = sym.type; //Devuelve int como tipo (Struct), no como nodo Symbol 
                                if (ZZ.parser)
                                    Console.WriteLine("Encontró " + token.str);
                            };
                            if (ZZ.parser)
                                Console.WriteLine("Terminó new " + token.str);
                            if (la == Token.LBRACK)
                            {
                                Check(Token.LBRACK);
                                Parser.Expr(out item);
                                if (item.type != Tab.intType) Errors.Error("array size must be of type int");
                                Code.Load(item); //genera cod p/cargar el result de la expr	
                                Code.il.Emit(Code.NEWARR, type.sysType); //NEWARR de char
                                type = new Struct(Struct.Kinds.Arr, type);
                                Check(Token.RBRACK);
                            }
                            else
                            {
                                if (sym.ctor == null)
                                {
                                    Console.WriteLine("Error sym.ctor == null"); if (ZZ.readKey) Console.ReadKey();
                                };
                                if (type.kind == Struct.Kinds.Class) //new Table  pag 34 de T. De Simb
                                {
                                    Code.il.Emit(Code.NEWOBJ, sym.ctor); //emite cod p/new Table  qq1
                                }
                                else
                                {
                                    Errors.Error("class type expected"); type = Tab.noType;
                                }
                            }
                            item = new Item(type);
                            //item.type = type;  lo hace en el constr Item(Struct type)
                            break;
                        }
                    case Token.LPAR:
                        {
                            Check(Token.LPAR);
                            xpandAll();
                            
                                                        Parser.Expr(out item, Expr);
                            Check(Token.RPAR);
                                                    }
                    default:
                        {
                            Errors.Error(ErrorStrings.INVALID_FACT);
                            item = new Item(3);
                            break;
                        }
                }
        }//Fin Factor
        buscar el designator en la tabla de simbolos
            Check(Token.IDENT); //ahora token.str="val"      y laToken= "="
                                //-------------------------------------------------Grupo 2 28/9/2015
            
            
            
            //-------------------------------------------------Grupo 2 28/9/2015-----------------------------------------------------------
            
                        
            //-------------------------------------------------Grupo 2 28/9/2015-----------------------------------------------------------
            Symbol sym = Tab.Find(token.str);
            if (ZZ.ParserStatem) Console.WriteLine("token.str:" + token.str);
            if (sym == null) Errors.Error(sym.name + "..no está en la Tab");

            item = new Item(sym);
            if ((la == Token.PERIOD || la == Token.LBRACK) && la != Token.EOF)
            {
                while ((la == Token.PERIOD || la == Token.LBRACK) && la != Token.EOF)//hacer do...while
                {
                    //debe seguir buscando en la Tab
                    if (ZZ.parser) Console.Write("field..." + token.str + " (val)"); //val
                    if (la == Token.PERIOD)
                    {
                        Check(Token.PERIOD); //caso del val . pos
                        Code.cargaProgDeLaGram("opcRestOfDesignator =  '.' ident.");
                        
                        .");
                                                
                        xpandAll();
                        Check(Token.IDENT); //pos
                        


                        if (ZZ.parser) Console.WriteLine(" . " + token.str + " (pos)"); //pos
                        if (item.type.kind == Struct.Kinds.Class)
                        {
                            Code.Load(item);  //lleva el Item al  Stack
                            Symbol symField = Tab.FindSymbol(token.str, sym.type.fields);
                            //sim = Tab.FindSymbol(token.str, sym.type.fields);//pierde sim orig pero sirve,
                            // para luego hacer item = new Item(sym);
                            Struct xTypeField;
                            if (symField == null)
                            {
                                Errors.Error("..--debe venir un tipo");//Fran
                                xTypeField = Tab.noType;
                            }
                            else
                            {
                                if (ZZ.parser) Console.WriteLine("encuentra " + symField.name);
                                xTypeField = symField.type; //Devuelve int como tipo (Struct), no como nodo Symbol 
                            };
                            item.sym = symField; // Tab.FindField(token.str, item.type);
                            item.type = item.sym.type; //int        f     clase
                        }
                        else Errors.Error(sym.name + " is not an object");
                        item.kind = Item.Kinds.Field; //Field
                    }
                    else
                        if (la == Token.LBRACK)
                    {
                        Check(Token.LBRACK);
                        Code.cargaProgDeLaGram("opcRestOfDesignator =  '[' Expr ']'.");
                        
                        if (
                        //--------------------------------------<test>---------------------------------------
                        // No se carga el subindice ya que se calcula en el la linea 2376 con el valor que tiene
                        //el subindice
                        //item.adr = item.adr + itemSig.val;
                        //Code.Load(item);
                        //mas abajo supuestamente carga el indice pero no lo hace, no se que es lo que hace realmente
                        //pero tambien lo comente ya que no tendria ninguna funcionalidad con respecto al indice del
                        //arreglo
                        //--------------------------------------<test>---------------------------------------
                        Item itemSig;
                        //
                        
                        
                        //                       //
                        Expr(out itemSig, nexpr);
                        //--------------------------------------<2test>-----------------------------------------
                        //Code.il.Emit(Code.POP);
                        //Parser.nroDeInstrCorriente++; Code.cargaInstr("pop      ");
                        //Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.pop;
                        item.adr = item.adr + itemSig.val;
                        Item index = new Item(item.adr);
                        Code.Load(index);

                        Code.il.Emit(Code.POP);
                        nroDeInstrCorriente++; Code.cargaInstr("pop      ");
                        cil[nroDeInstrCorriente].accionInstr = AccionInstr.pop;

                        Code.Load(item);

                        //--------------------------------------</2test>----------------------------------------
                        if (item.type.kind == Struct.Kinds.Arr)
                        {
                            if (itemSig.type != Tab.intType) Errors.Error("index must be of type int");
                            //--------------------------------------<test>---------------------------------------
                            //Code.Load(itemSig);  //carga el subindice en el Stack
                            //leer linea 2344 de Parser.cs


                            //item.kind = Item.Kinds.Local;
                            //Code.il.Emit(Code.POP);
                            //Parser.nroDeInstrCorriente++; Code.cargaInstr("pop      ");
                            //Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.pop;
                            //--------------------------------------<test>---------------------------------------

                            itemSig.type = item.type.elemType;//Si char[10] a; => x.type quedará con char
                        }
                        else Errors.Error(sym.name + " is not an array");

                        //--------------------------------------<test>---------------------------------------
                        //item.kind = Item.Kinds.Elem; linea original
                        item.kind = Item.Kinds.Stack;// linea de test

                        //--------------------------------------</test>---------------------------------------
                        //item.adr = item.adr + itemSig.val;
                        Check(Token.RBRACK);
                        //--------------------------------------<test>---------------------------------------
                        //if (laToken.kind == 4 || laToken.kind == 5 || 
                        //    laToken.kind == 6 || laToken.kind == 7 || laToken.kind == 8)
                        //{
                        //    item.kind = Item.Kinds.Local;
                        //    Code.il.Emit(Code.POP);
                        //    Parser.nroDeInstrCorriente++; Code.cargaInstr("pop      ");
                        //    Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.pop;
                        //}
                        //                      No sirve para a[0] + a[0]
                        //--------------------------------------</test>---------------------------------------
                    }
                }//Fin while
            }
            else
            {
                Code.cargaProgDeLaGram("opcRestOfDesignator =  .");
                //-------------------------------------------------Grupo 2 30/9/2015-----------------------------------------------------------
                xpandAll();
                Code.Load(item);
            }
                    } //Fin Designator
        static void Relop(out int op)
        {
            switch (la)
            {
                case Token.EQ:
                    Check(Token.EQ); op = Token.EQ;
                    break;
                case Token.NE:
                    Check(Token.NE); op = Token.NE;
                    break;
                case Token.GT:
                    Check(Token.GT); op = Token.GT;
                    break;
                case Token.GE:
                    Check(Token.GE); op = Token.GE;
                    break;
                case Token.LT:
                    Check(Token.LT); op = Token.LT;
                    break;
                case Token.LE:
                    Check(Token.LE); op = Token.LE;
                    break;
                default:
                    Errors.Error(ErrorStrings.REL_OP); op = Token.EQ; //Solo para q no de error
                    break;
            }
        }//Fin Relop
        
                case Token.EQ:
                    Check(Token.EQ);
                    break;
                case Token.NE:
                    Check(Token.NE);
                    break;
                case Token.GT:
                    Check(Token.GT);
                    break;
                case Token.GE:
                    Check(Token.GE);
                    break;
                case Token.LT:
                    Check(Token.LT);
                    break;
                case Token.LE:
                    Check(Token.LE);
                    break;
                default:
                    Errors.Error(ErrorStrings.REL_OP);
                    break;
            }
            String());
        }//Fin Relop
        static void Addop()
        {
            if (la == Token.PLUS)
                Check(Token.PLUS);
            else
                if (la == Token.MINUS)
                Check(Token.MINUS);
            else
                Errors.Error(ErrorStrings.ADD_OP);
        }//Fin Addop
        static void Mulop()
        {
            if (la == Token.TIMES)
                Check(Token.TIMES);
            else
                if (la == Token.SLASH)
                Check(Token.SLASH);
            else
                    if (la == Token.REM)
                Check(Token.REM);
            else
                Errors.Error(ErrorStrings.MUL_OP);
        }//Fin Mulop
        public static void Parse(string prog)
            {
                Scanner.Init(new StringReader(prog), null);  //deja en ch el 1° char de prog 
                Tab.Init();  //topScope queda apuntando al Scope p/el universe
                Errors.Init();
                curMethod = null;
                token = null;
                //Con 1° char de prog en la vble ch, ya puede comenzar el Scanner 
                laToken = new Token(1, 1);  // avoid crash when 1st symbol has scanner error
                                            //porque el Scan comienza con token = laToken
                Scan();                     // scan first symbol
                Program();                  // start analysis  
                Check(Token.EOF);
            }
    }
}
