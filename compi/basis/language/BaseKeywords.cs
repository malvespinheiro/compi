using System.Collections;
using unsj.fcefn.compiladores.compi.basis.language.token;

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

        public TokenEnum GetKeyWordToken(string keyword)
        {
            return IsKeyword(keyword) ? (TokenEnum)keywordsList[keyword] : TokenEnum.NONE;
        }
    }
}