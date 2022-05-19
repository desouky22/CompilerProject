using System;
using System.Collections.Generic;
using System.IO;

namespace CodeForCompiler
{
    class Program
    {
        public static Trie t = new Trie();
        static Dictionary<string, string> tokensReturn = new Dictionary<string, string>();
        static void Init()
        {
            tokensReturn["Category"] = "Class";
            tokensReturn["Derive"] = "Inheritance";
            tokensReturn["If"] = "Condition";
            tokensReturn["Else"] = "Condition";
            tokensReturn["Ilap"] = "Integer";
            tokensReturn["Silap"] = "SInteger";
            tokensReturn["Clop"] = "Character";
            tokensReturn["Series"] = "String";
            tokensReturn["Ilapf"] = "Float";
            tokensReturn["Silapf"] = "SFloat";
            tokensReturn["None"] = "Void";
            tokensReturn["Logical"] = "Boolean";
            tokensReturn["terminatethis"] = "Termination keyword";
            tokensReturn["Rotatewhen"] = "Loop";
            tokensReturn["Continuewhen"] = "Loop";
            tokensReturn["Replywith"] = "Return";
            tokensReturn["Seop"] = "Struct";
            tokensReturn["Check"] = "Switch";
            tokensReturn["Program"] = "Start Statement";
            tokensReturn["End"] = "End Statement";
            tokensReturn["+"] = "Plus operator";
            tokensReturn["-"] = "Minus operator";
            tokensReturn["*"] = "Multiplication";
            tokensReturn["/"] = "Division";
            tokensReturn["&&"] = "Logical AND";
            tokensReturn["||"] = "Logical OR";
            tokensReturn["~"] = "Logical NOT";
            tokensReturn["=="] = "Equality Operator";
            tokensReturn["="] = "Assignment Operator";
            tokensReturn[">"] = "Greater Than";
            tokensReturn["<"] = "Lower Than";
            tokensReturn[">="] = "Greater Than or Equal";
            tokensReturn["<="] = "Lower Than Or Equal";
            tokensReturn["!="] = "Not Equal";
            tokensReturn["."] = "Dot Operator";
            tokensReturn["["] = "Open square bracket";
            tokensReturn["]"] = "close square bracket";
            tokensReturn["{"] = "open curly bracket";
            tokensReturn["}"] = "close curly bracket";
            tokensReturn["Using"] = "Inclusion";
            tokensReturn["\""] = "Double Quote";
            tokensReturn["\'"] = "Single Quote";
            tokensReturn[";"] = "Line Delimeter";
            tokensReturn["("] = "Open Parenthesis";
            tokensReturn[")"] = "Close Parenthesis";
            foreach (var keyword in tokensReturn)
            {
                t.Insert(keyword.Key);
            }
        }
        static bool startsWith_ORAlpha(string word)
        {
            return (word[0] == '_' || (word[0] >= 'a' && word[0] <= 'z') || (word[0] >= 'A' && word[0] <= 'Z'));
        }
        static bool IsId(string word)
        {
            if (!startsWith_ORAlpha(word)) return false;
            for (int i = 0; i < word.Length; i++)
            {
                if ((!(word[i] >= '0' && word[i] <= '9')) && (!(word[i] >= 'a' && word[i] <= 'z')) && (!(word[i] >= 'A' && word[i] <= 'Z')))
                {
                    if (word[i] != '_') return false;
                }
            }
            return true;
        }

        static bool AllDigits(string word)
        {
            foreach (var ch in word)
            {
                if (ch >= '0' && ch <= '9') continue;
                else return false;
            }
            return true;
        }

        static string[] SplitWithSpaces(string line, ref int size)
        {
            string[] tokens = new string[10];
            string temp = "";
            int numberOfTokens = 0;
            int idx = 0;
            while (idx < line.Length)
            {
                if (line[idx] == ' ' || line[idx] == '\t')
                {
                    if (temp != "")
                    {
                        tokens[numberOfTokens++] = temp; temp = "";
                    }
                }
                else
                {
                    temp += line[idx];
                }
                idx++;
            }
            if (temp != "")
            {
                tokens[numberOfTokens++] = temp; temp = "";
            }
            size = numberOfTokens;
            return tokens;
        }

        public static void CheckLine(string line)
        {
            if (line.Length >= 2)
            {
                if (line[0] == line[1] && line[0] == '-')
                {
                    Console.WriteLine($"{line} -> Comment");
                    return;
                }
            }

            // int size = 0;
            // var words = SplitWithSpaces(line, ref size);
            string temp = "";
            foreach (char ch in line)
            {
                if (ch == ' ' || ch == '\t')
                {
                    if (temp.Length != 0)
                    {
                        if (t.Search(temp))
                        {

                        }
                    }
                    temp = "";
                    continue;
                }
                temp += ch;
            }




            //     for (int x = 0; x < size; x++)
            //     {
            //         var word = words[x];
            //         if (word == "")
            //         {
            //             continue;
            //         }
            //         else if (AllDigits(word))
            //         {
            //             Console.WriteLine($"{word} -> Constant Number");
            //         }
            //         else if (t.Search(word))
            //         {
            //             Console.WriteLine($"{word} -> {tokensReturn[word]}");
            //         }
            //         else
            //         {
            //             if (IsId(word))
            //             {
            //                 Console.WriteLine($"{word} -> Identifier");
            //             }
            //             else
            //             {
            //                 Console.WriteLine($"{word} -> Invalid Token");
            //             }
            //         }
            //     }
            // }




            static void Main(string[] args)
            {
                Init();
                string textFile = @"C:\Users\3m\Desktop\one.txt";
                if (File.Exists(textFile))
                {
                    string[] lines = File.ReadAllLines(textFile);
                    foreach (var line in lines)
                    {
                        CheckLine(line);
                    }
                }
            }
        }
    }
}