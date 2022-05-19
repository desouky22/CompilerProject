using System;
namespace CompilerProject
{
    public class DFA
    {
        private static Node root;
        public DFA()
        {
            root = new Node('\0');
        }

        public void Insert(string word)
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
        }

        public bool Search(string word)
        {
            Node node = GetNode(word);
            return node != null && node.isWord;
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
            public bool isWord;
            public Node[] children;

            public Node(char c)
            {
                this.c = c;
                isWord = false;
                children = new Node[char.MaxValue];
            }
        }
    }
}