using System.Collections;
using unsj.fcefn.compiladores.compi.basis.interfaces;

namespace unsj.fcefn.compiladores.compi.basis.language
{
    class BaseKeywords: IKeywords
    {
        private Hashtable keywordsList;

        public void Init()
        {           
            string[] keywords = {
                "break",
                "class",
                "const",
                "else",
                "if",
                "new",
                "read",
                "return",
                "void",
                "while",
                "write",
                "writeln"
            };
            keywordsList = new Hashtable();
            foreach (string word in keywords)
                keywordsList.Add(word.GetHashCode(), word);
        }

        public bool IsKeyword(string word)
        {
            return keywordsList.ContainsValue(word);
        }
    }
}