using System;
using System.Collections.Generic;
using System.Text;

namespace MKVCNV
{
    class MarkovLanguage
    {
        MarkovChain<LanguageElement> mc = new MarkovChain<LanguageElement>();
        List<LanguageElement> beginings = new List<LanguageElement>();

        Random rnd = new Random();
        public void AddSentance(string sentance)
        {
            string[] words = sentance.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            LanguageElement prevWord = null;

            for(int i =0; i<words.Length; i++)
            {
                string word = words[i];
                LanguageElement element;
                if (i == 0)
                {
                    element = new LanguageElement(word, true);
                    beginings.Add(element);
                }
                else if(i == words.Length-1)
                {
                    element = new LanguageElement(word, false, true);
                    mc.Add(prevWord, element);
                }
                else
                {
                    element = new LanguageElement(word);
                    mc.Add(prevWord, element);
                }

                prevWord = element;
            }

        }

        public string GenerateSentance()
        {
            string sentance = "";
            LanguageElement start = beginings[rnd.Next(0, beginings.Count-1)];

            LanguageElement pointer = start;
            bool building = true;
            while(building)
            {
                sentance += $"{pointer.ConstructElement()} ";
                pointer = mc.GetNext(pointer);
                if(pointer.isSentanceEnd())
                {
                    sentance += $"{pointer.ConstructElement()} ";
                    building = false;
                }
            }
            return sentance;
        }


    }
}
