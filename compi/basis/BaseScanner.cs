using System;
using System.IO;
using unsj.fcefn.compiladores.compi.basis.interfaces;
using unsj.fcefn.compiladores.compi.basis.language;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis
{
    abstract class BaseScanner:IScanner
    {
        protected const char EOF = '\u0080';
        protected const char CR = '\r';
        protected const char LF = '\n';

        protected TextReader input;
        protected TextWriter output;

        protected char currentCharacter;
        protected int lineNumber, columnNumber;

        protected  BaseKeywords keywords;

        public void Init(string input)
        {
            this.input = new StringReader(input);
            this.output = Console.Out;
            this.lineNumber = 1;
            this.columnNumber = 0;
            this.keywords.Init();
            this.NextCharacter();
        }

        public void NextCharacter()
        {
            try
            {
                currentCharacter = (char)input.Read();
                columnNumber++;
                switch (currentCharacter)
                {
                    case LF:
                        lineNumber++;
                        columnNumber = 0;
                        break;
                    case CR:
                        columnNumber = 0;
                        break;
                    case '\uffff': 
                        currentCharacter = EOF;
                        break;
                }
            }
            catch (IOException) { currentCharacter = EOF; }
        }

        public abstract Token Next();
    }
}