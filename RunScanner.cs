using System;
using System.Collections.Generic;
using System.IO;

namespace CompilerProject
{
    public class RunScanner
    {
        public static DFA dfa = new DFA();
        private static Dictionary<string, string> tokensReturn = new Dictionary<string, string>();
        private static Dictionary<Tuple<int, char>, int> transTable = new Dictionary<Tuple<int, char>, int>();

        public static void BuildingTransTable()
        {
            transTable[new Tuple<int, char>(1, 'C')] = 26;
            transTable[new Tuple<int, char>(1, 'D')] = 2;
            transTable[new Tuple<int, char>(1, 'E')] = 90;
            transTable[new Tuple<int, char>(1, 'I')] = 54;
            transTable[new Tuple<int, char>(1, 'L')] = 8;
            transTable[new Tuple<int, char>(1, 'P')] = 83;
            transTable[new Tuple<int, char>(1, 'R')] = 60;
            transTable[new Tuple<int, char>(1, 'S')] = 41;
            transTable[new Tuple<int, char>(1, 's')] = 109;
            transTable[new Tuple<int, char>(1, 't')] = 96;
            transTable[new Tuple<int, char>(1, 'U')] = 78;
            transTable[new Tuple<int, char>(1, '-')] = 0;
            transTable[new Tuple<int, char>(1, '+')] = 0;
            transTable[new Tuple<int, char>(1, '*')] = 0;
            transTable[new Tuple<int, char>(1, '/')] = 0;
            transTable[new Tuple<int, char>(1, '&')] = 133;
            transTable[new Tuple<int, char>(1, '|')] = 135;
            transTable[new Tuple<int, char>(1, '~')] = 0;
            transTable[new Tuple<int, char>(1, '<')] = 0;
            transTable[new Tuple<int, char>(1, '>')] = 0;
            transTable[new Tuple<int, char>(1, '!')] = 130;
            transTable[new Tuple<int, char>(1, '=')] = 0;
            transTable[new Tuple<int, char>(1, '.')] = 0;
            transTable[new Tuple<int, char>(1, '[')] = 0;
            transTable[new Tuple<int, char>(1, ']')] = 0;
            transTable[new Tuple<int, char>(1, '{')] = 0;
            transTable[new Tuple<int, char>(1, '}')] = 0;
            transTable[new Tuple<int, char>(1, '\"')] = 0;
            transTable[new Tuple<int, char>(1, '\'')] = 0;
            transTable[new Tuple<int, char>(2, 'e')] = 3;
            transTable[new Tuple<int, char>(3, 'r')] = 4;
            transTable[new Tuple<int, char>(4, 'i')] = 5;
            transTable[new Tuple<int, char>(5, 'R')] = 6;
            transTable[new Tuple<int, char>(6, 'e')] = 0;
            transTable[new Tuple<int, char>(8, 'l')] = 9;
            transTable[new Tuple<int, char>(9, 'g')] = 10;
            transTable[new Tuple<int, char>(10, 'i')] = 11;
            transTable[new Tuple<int, char>(11, 'c')] = 12;
            transTable[new Tuple<int, char>(12, 'a')] = 13;
            transTable[new Tuple<int, char>(13, 'l')] = 0;
            transTable[new Tuple<int, char>(15, 'n')] = 16;
            transTable[new Tuple<int, char>(16, 't')] = 17;
            transTable[new Tuple<int, char>(17, 'i')] = 18;
            transTable[new Tuple<int, char>(18, 'n')] = 19;
            transTable[new Tuple<int, char>(19, 'u')] = 20;
            transTable[new Tuple<int, char>(20, 'e')] = 21;
            transTable[new Tuple<int, char>(21, 'w')] = 22;
            transTable[new Tuple<int, char>(22, 'h')] = 23;
            transTable[new Tuple<int, char>(23, 'e')] = 24;
            transTable[new Tuple<int, char>(24, 'n')] = 0;
            transTable[new Tuple<int, char>(26, 'a')] = 27;
            transTable[new Tuple<int, char>(26, 'h')] = 37;
            transTable[new Tuple<int, char>(26, 'l')] = 34;
            transTable[new Tuple<int, char>(27, 't')] = 28;
            transTable[new Tuple<int, char>(28, 'e')] = 29;
            transTable[new Tuple<int, char>(29, 'g')] = 30;
            transTable[new Tuple<int, char>(30, 'o')] = 31;
            transTable[new Tuple<int, char>(31, 'r')] = 32;
            transTable[new Tuple<int, char>(32, 'y')] = 0;
            transTable[new Tuple<int, char>(34, 'o')] = 35;
            transTable[new Tuple<int, char>(35, 'p')] = 0;
            transTable[new Tuple<int, char>(37, 'e')] = 38;
            transTable[new Tuple<int, char>(38, 'c')] = 39;
            transTable[new Tuple<int, char>(39, 'k')] = 0;
            transTable[new Tuple<int, char>(41, 'e')] = 47;
            transTable[new Tuple<int, char>(41, 'i')] = 42;
            transTable[new Tuple<int, char>(42, 'l')] = 43;
            transTable[new Tuple<int, char>(43, 'a')] = 44;
            transTable[new Tuple<int, char>(44, 'p')] = 0;
            transTable[new Tuple<int, char>(45, 'f')] = 0;
            transTable[new Tuple<int, char>(47, 'P')] = 52;
            transTable[new Tuple<int, char>(47, 'r')] = 48;
            transTable[new Tuple<int, char>(48, 'i')] = 49;
            transTable[new Tuple<int, char>(49, 'e')] = 50;
            transTable[new Tuple<int, char>(50, 's')] = 0;
            transTable[new Tuple<int, char>(52, 'p')] = 0;
            transTable[new Tuple<int, char>(54, 'f')] = 0;
            transTable[new Tuple<int, char>(54, 'l')] = 55;
            transTable[new Tuple<int, char>(55, 'a')] = 56;
            transTable[new Tuple<int, char>(56, 'p')] = 0;
            transTable[new Tuple<int, char>(57, 'f')] = 0;
            transTable[new Tuple<int, char>(60, 'o')] = 61;
            transTable[new Tuple<int, char>(61, 't')] = 62;
            transTable[new Tuple<int, char>(62, 'a')] = 63;
            transTable[new Tuple<int, char>(63, 't')] = 64;
            transTable[new Tuple<int, char>(64, 'e')] = 65;
            transTable[new Tuple<int, char>(65, 'w')] = 66;
            transTable[new Tuple<int, char>(66, 'h')] = 67;
            transTable[new Tuple<int, char>(67, 'e')] = 68;
            transTable[new Tuple<int, char>(68, 'n')] = 0;
            transTable[new Tuple<int, char>(70, 'p')] = 71;
            transTable[new Tuple<int, char>(71, 'l')] = 72;
            transTable[new Tuple<int, char>(72, 'y')] = 73;
            transTable[new Tuple<int, char>(73, 'w')] = 74;
            transTable[new Tuple<int, char>(74, 'i')] = 75;
            transTable[new Tuple<int, char>(75, 't')] = 76;
            transTable[new Tuple<int, char>(76, 'h')] = 0;
            transTable[new Tuple<int, char>(78, 's')] = 79;
            transTable[new Tuple<int, char>(79, 'i')] = 80;
            transTable[new Tuple<int, char>(80, 'n')] = 81;
            transTable[new Tuple<int, char>(81, 'g')] = 0;
            transTable[new Tuple<int, char>(83, 'r')] = 84;
            transTable[new Tuple<int, char>(84, 'o')] = 85;
            transTable[new Tuple<int, char>(85, 'g')] = 86;
            transTable[new Tuple<int, char>(86, 'r')] = 87;
            transTable[new Tuple<int, char>(87, 'a')] = 88;
            transTable[new Tuple<int, char>(88, 'm')] = 0;
            transTable[new Tuple<int, char>(90, 'l')] = 93;
            transTable[new Tuple<int, char>(90, 'n')] = 91;
            transTable[new Tuple<int, char>(91, 'd')] = 0;
            transTable[new Tuple<int, char>(93, 's')] = 94;
            transTable[new Tuple<int, char>(94, 'e')] = 0;
            transTable[new Tuple<int, char>(96, 'e')] = 97;
            transTable[new Tuple<int, char>(97, 'r')] = 98;
            transTable[new Tuple<int, char>(98, 'm')] = 99;
            transTable[new Tuple<int, char>(99, 'i')] = 100;
            transTable[new Tuple<int, char>(100, 'n')] = 101;
            transTable[new Tuple<int, char>(101, 'a')] = 102;
            transTable[new Tuple<int, char>(102, 't')] = 103;
            transTable[new Tuple<int, char>(103, 'e')] = 104;
            transTable[new Tuple<int, char>(104, 't')] = 105;
            transTable[new Tuple<int, char>(105, 'h')] = 106;
            transTable[new Tuple<int, char>(106, 'i')] = 107;
            transTable[new Tuple<int, char>(107, 's')] = 0;
            transTable[new Tuple<int, char>(109, 'i')] = 110;
            transTable[new Tuple<int, char>(110, 't')] = 111;
            transTable[new Tuple<int, char>(111, 'u')] = 112;
            transTable[new Tuple<int, char>(112, 'a')] = 113;
            transTable[new Tuple<int, char>(113, 't')] = 114;
            transTable[new Tuple<int, char>(114, 'i')] = 115;
            transTable[new Tuple<int, char>(115, 'o')] = 116;
            transTable[new Tuple<int, char>(116, 'n')] = 117;
            transTable[new Tuple<int, char>(117, 'o')] = 118;
            transTable[new Tuple<int, char>(118, 'f')] = 0;
            transTable[new Tuple<int, char>(120, '=')] = 0;
            transTable[new Tuple<int, char>(126, '=')] = 0;
            transTable[new Tuple<int, char>(128, '=')] = 0;
            transTable[new Tuple<int, char>(130, '=')] = 0;
            transTable[new Tuple<int, char>(133, '&')] = 0;
            transTable[new Tuple<int, char>(135, '|')] = 0;

        }



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
                dfa.Insert(keyword.Key);
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

            int size = 0;
            var words = SplitWithSpaces(line, ref size);



            for (int x = 0; x < size; x++)
            {
                var word = words[x];
                if (word == "")
                {
                    continue;
                }
                else if (AllDigits(word))
                {
                    Console.WriteLine($"{word} -> Constant Number");
                }
                else if (dfa.Search(word))
                {
                    Console.WriteLine($"{word} -> {tokensReturn[word]}");
                }
                else
                {
                    if (IsId(word))
                    {
                        Console.WriteLine($"{word} -> Identifier");
                    }
                    else
                    {
                        Console.WriteLine($"{word} -> Invalid Token");
                    }
                }
            }
        }
        public static void Run()
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
