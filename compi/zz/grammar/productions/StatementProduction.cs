using compi.basis.symbolTable;
using unsj.fcefn.compiladores.compi.basis;
using unsj.fcefn.compiladores.compi.basis.exceptions;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.zz.grammar.productions
{
    class StatementProduction : CompoundProduction<StatementProduction>
    {

        private readonly TypeProduction typeProduction = new TypeProduction();

        public override StatementProduction Execute()
        {
            if (la == Token.IDENT)
            {
                // Item itemIzq, itemDer; // = new Item();  // 
                Designator(out itemIzq, designator); //val   en statement
                switch (la)
                {
                    case Token.ASSIGN:
                        {
                            Check(Token.ASSIGN);
                            Expr(out itemDer, nexpr);
                            // Code.Load(itemDer);
                            // Code.Assign(itemIzq, itemDer, nexpr);
                            break;
                        }
                    case Token.LPAR: 
                        {
                            Check(Token.LPAR);
                            if (la == Token.MINUS || la == Token.IDENT ||
                                la == Token.NUMBER || la == Token.CHARCONST ||
                                la == Token.NEW || la == Token.LPAR)
                                ActPars();
                            Check(Token.RPAR);
                            break;
                        }
                    case Token.PPLUS:
                        {
                            Check(Token.PPLUS);
                            break;
                        }
                    case Token.MMINUS:
                        {
                            Check(Token.MMINUS);
                            break;
                        }
                }
                Check(Token.SEMICOLON);
            }
            else
            {
                // Item item, itemAncho;
                switch (la)
                {
                    case Token.IF:
                        int nroInstrParaRectificarElIf;
                        Item x; Label end;
                        Check(Token.IF);
                        System.Windows.Forms.TreeNode If = new System.Windows.Forms.TreeNode("'if'");
                        statement.Nodes.Add(If);
                        MessageBoxCon3Preg(statement);
                        Check(Token.LPAR);
                        If.Nodes.Add("(");
                        MessageBoxCon3Preg(If);
                        Condition(out x);
                        System.Windows.Forms.TreeNode condition = new System.Windows.Forms.TreeNode("Condition");
                        If.Nodes.Add(condition);
                        MessageBoxCon3Preg(If);
                        if (ZZ.parser) Console.WriteLine("reconoció la cond del if");
                        Check(Token.RPAR);
                        If.Nodes.Add(")");
                        MessageBoxCon3Preg(If);
                        Code.FJump(x);  //dentro del if (i<10) 
                        //Code.FJump(x) => bge x.fLabel, i.e. si >= debe ir a x.fLabel (debe saltar el then)
                        //x.fLabel está indefinido, luego habrá un  //luego habrà un Code.il.MarkLabel(x.fLabel);

                        //Code.FJump(x)=> Parser.cil[Parser.nroDeInstrCorriente]...=> bge -1 (por ej) 
                        nroInstrParaRectificarElIf = Parser.nroDeInstrCorriente;
                        //luego habrà un Parser.cil[nroInstrParaRectificarElIf].nroLinea = label...
                        //reemplazando "bge -1" con "bge label..."
                        //////////
                        System.Windows.Forms.TreeNode nstatement = new System.Windows.Forms.TreeNode("Statement");
                        If.Nodes.Add(nstatement);
                        MessageBoxCon3Preg(If);
                        /////////
                        Statement(nstatement); //en el if de una statement
                        if (ZZ.parser) Console.WriteLine("reconoció la Statem del if");
                        if (la == Token.ELSE)
                        {
                            Check(Token.ELSE);
                            ///////////
                            System.Windows.Forms.TreeNode nelse = new System.Windows.Forms.TreeNode("Else");
                            If.Nodes.Add(nelse);
                            MessageBoxCon3Preg(If);
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
                        System.Windows.Forms.TreeNode nwhile = new System.Windows.Forms.TreeNode("'While'");
                        statement.Nodes.Add(nwhile);
                        MessageBoxCon3Preg(statement);
                        Label top = Code.il.DefineLabel();
                        int topMio = -1;
                        Code.il.MarkLabel(top);
                        topMio = Parser.nroDeInstrCorriente + 1; //(instr sig a la actual)
                        //para luego..Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.branchInc;
                        //Parser.cil[Parser.nroDeInstrCorriente].nroLinea = topMio;  //Br Incond está definido
                        Check(Token.LPAR);
                        Condition(out x);
                        nwhile.Nodes.Add("'('");
                        MessageBoxCon3Preg(nwhile);
                        nwhile.Nodes.Add("Condition");
                        MessageBoxCon3Preg(nwhile);
                        if (ZZ.parser) { Console.WriteLine("Termina con la cond del while"); };
                        Check(Token.RPAR);
                        MessageBoxCon3Preg(nwhile);
                        Code.FJump(x); //dentro del while (i<10) 
                        //Code.FJump(x) => bge x.fLabel, i.e. si >= debe ir a x.fLabel (debe salir del loop)
                        //x.fLabel está indefinido, luego habrá un  //luego habrà un Code.il.MarkLabel(x.fLabel);
                        //Code.FJump(x)=> Parser.cil[Parser.nroDeInstrCorriente]...=> bge -1 (por ej) 
                        nroInstrParaRectificarElWhile = Parser.nroDeInstrCorriente;
                        //luego habrà un Parser.cil[nroInstrParaRectificarElWhile].nroLinea = label...
                        //reemplazando "bge -1" con "bge label..."
                        Check(Token.LBRACE);
                        nwhile.Nodes.Add("'{'");
                        MessageBoxCon3Preg(nwhile);
                        //cuerpo del while  
                        while (la != Token.RBRACE && la != Token.EOF)
                        {
                            System.Windows.Forms.TreeNode nstatement2 = new System.Windows.Forms.TreeNode("Statement");
                            nwhile.Nodes.Add(nstatement2);
                            MessageBoxCon3Preg(nwhile);
                            Statement(nstatement2);
                        } //dentro del while
                        Check(Token.RBRACE);
                        nwhile.Nodes.Add("'}'");
                        MessageBoxCon3Preg(nwhile);
                        if (ZZ.parser) { Console.WriteLine("Termina statement while"); if (ZZ.readKey) Console.ReadKey(); };
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
                        System.Windows.Forms.TreeNode writeln = new System.Windows.Forms.TreeNode("'writeln'");
                        statement.Nodes.Add(writeln);
                        statement.ExpandAll();
                        MessageBoxCon3Preg(statement);
                        Code.Colorear("token");

                        ////////////////////////// 

                        //token queda con WRITELN y laToken =  "(" y ch con Comm Doble
                        //equivalente a Check(Token.LPAR);
                        //debe quedar token = "("  y laToken = "texto posiblem vacio"               
                        if (la == Token.LPAR) //ch = Comm Doble
                        {
                            //Scan(); //token = "("
                            ////////////////////////// Agrega '(' al arbol y lo muestra
                            writeln.Nodes.Add("'('");
                            writeln.ExpandAll(); // G3 2015
                            MessageBoxCon3Preg(writeln);
                            //////////////////////////
                            Code.Colorear("latoken"); //pinta el "("
                            Code.Colorear("token"); //solo para que deje yaPintado en false

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
                                writeln.Nodes.Add("argstring"); // G3 2015
                                MessageBoxCon3Preg(writeln);
                                Code.Colorear("token");

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

                                writeln.Nodes.Add("')'");
                                MessageBoxCon3Preg(writeln);

                                Check(Token.RPAR);
                                Code.Colorear("token");
                                /////////////////////////////  Agrega ';' al arbol y lo muestra

                                writeln.Nodes.Add("';'"); // G3 2015
                                MessageBoxCon3Preg(writeln);
                                Check(Token.SEMICOLON);
                                Code.Colorear("token");

                            }
                        }

                        break;
                    case Token.WRITE: ///  En Statement

                        // G3 - PERUWRITE
                        //////////////// Agrega 'write' al arbol y lo muestra y colorea
                        Check(Token.WRITE);
                        System.Windows.Forms.TreeNode write = new System.Windows.Forms.TreeNode("'write'");
                        statement.Nodes.Add(write);
                        statement.ExpandAll();
                        MessageBoxCon3Preg(statement);

                        Code.Colorear("token");
                        MessageBoxCon3Preg();
                        /////////////////
                        ///////////////// Agrega '(' al arbol y lo muestra y colorea
                        Check(Token.LPAR);
                        statement.Nodes.Add("'('");
                        MessageBoxCon3Preg(statement);

                        Code.Colorear("token");
                        ////////////////
                        //////////////// Agrega 'Expr' al arbol y lo muestra y colorea y selecciona la regla de Expr
                        System.Windows.Forms.TreeNode expr1 = new System.Windows.Forms.TreeNode("Expr");
                        statement.Nodes.Add(expr1);
                        MessageBoxCon3Preg(statement);
                        Code.seleccLaProdEnLaGram(23);
                        Code.Colorear("latoken");
                        ////////////////

                        // First(Expr)
                        if (la == Token.MINUS || la == Token.IDENT || la == Token.NUMBER ||
                            la == Token.CHARCONST || la == Token.NEW || la == Token.LPAR)
                            //Code.il.EmitWriteLine("dentro del WRITE, antes del Expr(out item)");

                            AA(out item); ///?????

                        Expr(out item, expr1); // Crea la Expr
                        System.Windows.Forms.TreeNode expr2 = new System.Windows.Forms.TreeNode("Expr");
                        if (la == Token.RBRACE) // Le provee 10 espacios de escritura sino manda ningun numero
                        // Por ej. write(x);
                        {
                            statement.Nodes.Add("')'");
                            MessageBoxCon3Preg(statement);
                            Code.Colorear("latoken");
                        }
                        else
                        {
                            /////////////// Agrega ',' al arbol y lo muestra
                            Check(Token.COMMA);
                            Code.seleccLaProdEnLaGram(18);
                            write.Nodes.Add("','");
                            MessageBoxCon3Preg(write);
                            ///////////////


                            /////////////// Agrega 'Expr' al arbol y lo muestra y seecciona la regla de Expr

                            write.Nodes.Add(expr2);
                            MessageBoxCon3Preg(write);
                            Code.seleccLaProdEnLaGram(23);
                            //////////////

                            Expr(out itemAncho, expr2);
                            Code.il.EmitCall(Code.CALL, Code.writeInt, null); //Probar   provisorio

                            Parser.nroDeInstrCorriente++;
                            Parser.cil[Parser.nroDeInstrCorriente].accionInstr = Parser.AccionInstr.write;
                            Parser.cil[Parser.nroDeInstrCorriente].nro = item.val; // item.val;           //item.val;  aaaaaaa 

                            Code.cargaInstr("call write#(int32,int32)");
                            /////////////// Agrega ')' al arbol y lo muestra
                            Code.seleccLaProdEnLaGram(18);
                            Check(Token.RPAR);
                            write.Nodes.Add("')'");
                            MessageBoxCon3Preg(write);
                            Code.Colorear("token");
                            ///////////////
                        }
                        MessageBoxCon3Preg();
                        ////////////// Agrega ';' al arbol y lo muestra
                        Check(Token.SEMICOLON);
                        write.Nodes.Add("';'");
                        MessageBoxCon3Preg(write);
                        Code.Colorear("token");
                        ///////////////
                        break;
                    case Token.LBRACE:
                        System.Windows.Forms.TreeNode blockint = new System.Windows.Forms.TreeNode("Block");
                        statement.Nodes.Add(blockint);
                        MessageBoxCon3Preg(statement);
                        Block(blockint);  //bloque(blockint = bloque interior)dentro de una sentencia
                        break;
                    case Token.SEMICOLON:
                        Check(Token.SEMICOLON);
                        statement.Nodes.Add("';'");
                        MessageBoxCon3Preg(statement);
                        break;
                    default:
                        Errors.Error("Espero una sentencia");
                        break;
                }
            }
            return this;
        }

        private bool IsValidStatementBegining(TokenEnum tokenKind)
        {
            if(tokenKind == TokenEnum.EOF)
                return false;
            if(tokenKind == TokenEnum.IDENT)
                return true;
            if(tokenKind == TokenEnum.IF)
                return true;
            if(tokenKind == TokenEnum.WHILE)
                return true;
            if(tokenKind == TokenEnum.BREAK)
                return true;
            if(tokenKind == TokenEnum.RETURN)
                return true;
            if(tokenKind == TokenEnum.READ)
                return true;
            if(tokenKind == TokenEnum.WRITE)
                return true;
            if(tokenKind == TokenEnum.WRITELN)
                return true;
            if(tokenKind == TokenEnum.LBRACE)
                return true;
            if(tokenKind == TokenEnum.SEMICOLON)
                return true;

            return false;
        }

        public override void InitProductions()
        {
            typeProduction.Init(ref scanner, ref symbolTable, ref currentToken, ref lookingAheadToken, ref errorHandler);
        }
    }
}