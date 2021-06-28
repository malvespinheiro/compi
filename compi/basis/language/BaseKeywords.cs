using System.Collections;

namespace unsj.fcefn.compiladores.compi.basis.language
{
    abstract class BaseKeywords
    {
        protected Hashtable keywordsList = new Hashtable();

        public abstract void Init();

        public bool IsKeyword(string word)
        {
            return keywordsList.ContainsValue(word);
        }
    }
}