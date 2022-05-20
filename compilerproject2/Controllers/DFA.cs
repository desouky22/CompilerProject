using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compilerproject2.Controllers
{
    public class DFA
    {
        private static Node root;
        public DFA()
        {
            root = new Node('\0');
        }

        bool IsLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        private bool IsError(string word)
        {
            if (IsDigit(word[0])) return true;
            bool foundError = false;
            foreach (var c in word)
            {
                foundError = foundError || (!IsLetter(c) && !IsDigit(c) && c != '_');
            }
            return foundError;
        }

        private bool IsConstant(string digits)
        {
            bool isDigit = true;
            foreach (var c in digits)
                isDigit &= (c >= '0' && c <= '9');
            return isDigit;
        }

        public void AddTransition(string word, string type)
        {
            Node curr = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (curr.children[c] == null)
                {
                    curr.children[c] = new Node(c);
                }
                curr = curr.children[c];
            }
            curr.isWord = true;
            curr.tokenDefinition = type;
        }

        public string Search(string word)
        {
            Node node = GetNode(word);
            if (node != null && node.isWord)
            {
                return node.tokenDefinition;
            }

            if (IsConstant(word))
                return "Constant";
            else if (IsError(word) && word[word.Length - 1] != ';')
                return "-1";
            return "identifier";

        }

        private static Node GetNode(string word)
        {
            Node curr = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (curr.children[c] == null) return null;
                curr = curr.children[c];
            }
            return curr;
        }

        class Node
        {
            public char c;
            public string tokenDefinition;
            public bool isWord;
            public Node[] children;

            public Node(char c)
            {
                this.c = c;
                isWord = false;
                tokenDefinition = "";
                children = new Node[char.MaxValue];
            }
        }
    }
}