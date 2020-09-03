using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MKVCNV
{
    class LanguageElement
    {
        char[] sentanceEnders = new char[] { '.', '?', '!' };

        bool _sentanceStart;
        bool _sentanceEnd;
        bool _hasPuctuationPrefix;
        bool _hasPuctuationSufix;
        char _puctuationPrefix;
        char _puctuationSufix;
        string _word;

        Guid guid;

        public LanguageElement(string element, bool sentanceStart = false, bool sentanceEnd = false)
        {
            _sentanceStart = sentanceStart;
            _sentanceEnd = sentanceEnd;


            guid = new Guid(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(element)).Take(16).ToArray());

            char[] charArray = element.ToCharArray();

            if (!char.IsLetterOrDigit(charArray[0]))
            {
                _hasPuctuationPrefix = true;
                _puctuationPrefix = charArray[0];
            }

            if (!char.IsLetterOrDigit(charArray[charArray.Length - 1]))
            {
                _hasPuctuationSufix = true;
                _puctuationSufix = charArray[charArray.Length - 1];
            }


            foreach(char sentanceEndChar in sentanceEnders)
            {
                if(_puctuationSufix == sentanceEndChar)
                {
                    _sentanceEnd = true;
                }
            }

            if (_hasPuctuationPrefix)
            {
                element = element.Substring(1);
            }

            if (_hasPuctuationSufix)
            {
                element = element.Substring(0, element.Length - 1);
            }

            _word = element;
        }

        public string ConstructElement()
        {
            return $"{ (_hasPuctuationPrefix ? _puctuationPrefix.ToString() : "")}{_word}{(_hasPuctuationSufix ? _puctuationSufix.ToString() : "")}";
        }

        public bool isSentanceEnd()
        {
            return _sentanceEnd;
        }

        public bool isSentanceStart()
        {
            return _sentanceStart;
        }

        //implement comparator
        public override bool Equals(object obj)
        {
            var item = obj as LanguageElement;

            if (item == null)
            {
                return false;
            }

            return guid.Equals(item.guid);
        }

        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }
    }
}
