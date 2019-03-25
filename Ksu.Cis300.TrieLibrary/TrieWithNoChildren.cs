using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// If the trie is an empty string
        /// </summary>
        private bool _hasEmptyString = false;

        /// <summary>
        /// Adds string to the trie
        /// </summary>
        /// <param name="s">sring</param>
        /// <returns>Resulting trie</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmptyString);
            }

            return this;
        }

        /// <summary>
        /// Checks if a string is contained in the trie
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>false becase it can contain no string</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            } else
            {
                return false;
            }
        }
    }
}
