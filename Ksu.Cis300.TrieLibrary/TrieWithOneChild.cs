using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// If the trie is an empty string
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// Child element of the trie
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// character lable of trie
        /// </summary>
        private char _lable;

        /// <summary>
        /// Constructs a new TrieWithOneChild
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="hasEmptyString">if empty</param>
        public TrieWithOneChild(string s, bool hasEmptyString)
        {
            if (s == "" || (s[0] < 'a' || s[0] > 'z'))
            {
                throw new ArgumentException();
            }
            _hasEmptyString = hasEmptyString;
            _lable = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }

        /// <summary>
        /// Adds a string to the trie
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Resulting child</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else if (s[0] == _lable)
            {
                _child = _child.Add(s.Substring(1));
            } else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _lable, _child);
            }
            return this;
        }

        /// <summary>
        /// Check if trie contains a string
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>if it contains the string</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else if (s[0] == _lable)
            {
                return _child.Contains(s.Substring(1));
            } else
            {
                return false;
            }
            
        }
    }
}
