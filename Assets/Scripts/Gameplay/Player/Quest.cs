using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Others
{
    class Quest
    {
        private string  name;
        private int     objectif;
        private int     progress;
        private bool    complete;
        IList<string>   key_words;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Objectif
        {
            get
            {
                return objectif;
            }

            set
            {
                objectif = value;
            }
        }

        public int Progress
        {
            get
            {
                return progress;
            }

            set
            {
                progress = value;
            }
        }

        public bool Complete
        {
            get
            {
                return complete;
            }

            set
            {
                complete = value;
            }
        }

        public IList<string> Key_words
        {
            get
            {
                return key_words;
            }

            set
            {
                key_words = value;
            }
        }
        public void AddKeyWords(IList<string> new_key_words)
        {
            for(int i = 0; i < new_key_words.Count; i++)
            {
                key_words.Add(new_key_words[i]);
            }
        }
    }
}
