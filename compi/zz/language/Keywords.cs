using System.Collections;
using unsj.fcefn.compiladores.compi.basis.interfaces;
using unsj.fcefn.compiladores.compi.basis.language.token;

namespace unsj.fcefn.compiladores.compi.basis.language
{
    class Keywords: BaseKeywords
    {
        public override void Init()
        {
            keywordsList = new Hashtable(11);

            keywordsList.Add(("break").GetHashCode(), TokenEnum.BREAK);
            keywordsList.Add(("program").GetHashCode(), TokenEnum.PROGRAM);
            keywordsList.Add(("const").GetHashCode(), TokenEnum.CONST);
            keywordsList.Add(("else").GetHashCode(), TokenEnum.ELSE);
            keywordsList.Add(("if").GetHashCode(), TokenEnum.IF);
            keywordsList.Add(("read").GetHashCode(), TokenEnum.READ);
            keywordsList.Add(("return").GetHashCode(), TokenEnum.RETURN);
            keywordsList.Add(("void").GetHashCode(), TokenEnum.VOID);
            keywordsList.Add(("while").GetHashCode(), TokenEnum.WHILE);
            keywordsList.Add(("write").GetHashCode(), TokenEnum.WRITE);
            keywordsList.Add(("writeln").GetHashCode(), TokenEnum.WRITELN);
                
        }
    }
}