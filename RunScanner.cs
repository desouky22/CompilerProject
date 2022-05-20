namespace CompilerWithTrie
{
    public class RunScanner
    {
        private static int multiComment = 0;
        private const int MAX = 55;
        private static string[] KeyWords = new string[MAX];
        private static string[] ReturnToken = new string[MAX];
        public static int numberOfErrors = 0;
        public static DFA dfa = new DFA();

        private static void DefineKeywords()
        {
            KeyWords[0] = "Category"; ReturnToken[0] = "Class";
            KeyWords[1] = "Derive"; ReturnToken[1] = "Inheritance";
            KeyWords[2] = "If"; ReturnToken[2] = "Condition";
            KeyWords[3] = "Else"; ReturnToken[3] = "Condition";
            KeyWords[4] = "Ilap"; ReturnToken[4] = "Integer";
            KeyWords[5] = "Silap"; ReturnToken[5] = "SInteger";
            KeyWords[6] = "Clop"; ReturnToken[6] = "Character";
            KeyWords[7] = "Series"; ReturnToken[7] = "String";
            KeyWords[8] = "Ilapf"; ReturnToken[8] = "Float";
            KeyWords[9] = "Silapf"; ReturnToken[9] = "SFloat";
            KeyWords[10] = "None"; ReturnToken[10] = "Void";
            KeyWords[11] = "Rotatewhen"; ReturnToken[11] = "Loop";
            KeyWords[12] = "Continuewhen"; ReturnToken[12] = "Loop";
            KeyWords[13] = "Replywith"; ReturnToken[13] = "Return";
            KeyWords[14] = "Seop"; ReturnToken[14] = "Struct";
            KeyWords[15] = "Check"; ReturnToken[15] = "Switch";
            KeyWords[16] = "situationof"; ReturnToken[16] = "Switch";
            KeyWords[17] = "Program"; ReturnToken[17] = "Start Statement";
            KeyWords[18] = "End"; ReturnToken[18] = "End Statement";
            KeyWords[19] = "+"; ReturnToken[19] = "Arithmetic Operation";
            KeyWords[20] = "-"; ReturnToken[20] = "Arithmetic Operation";
            KeyWords[21] = "*"; ReturnToken[21] = "Arithmetic Operation";
            KeyWords[22] = "/"; ReturnToken[22] = "Arithmetic Operation";
            KeyWords[23] = "&&"; ReturnToken[23] = "Logic operator";
            KeyWords[24] = "||"; ReturnToken[24] = "Logic operator";
            KeyWords[25] = "~"; ReturnToken[25] = "Logic operator";
            KeyWords[26] = "=="; ReturnToken[26] = "relational operator";
            KeyWords[27] = "<"; ReturnToken[27] = "relational operator";
            KeyWords[28] = ">"; ReturnToken[28] = "relational operator";
            KeyWords[29] = "!="; ReturnToken[29] = "relational operator";
            KeyWords[30] = "<="; ReturnToken[30] = "relational operator";
            KeyWords[31] = ">="; ReturnToken[31] = "relational operator";
            KeyWords[32] = "="; ReturnToken[32] = "Assignment operator";
            KeyWords[33] = "."; ReturnToken[33] = "Access operator";
            KeyWords[34] = "{"; ReturnToken[34] = "Braces";
            KeyWords[35] = "}"; ReturnToken[35] = "Braces";
            KeyWords[36] = "["; ReturnToken[36] = "Braces";
            KeyWords[37] = "]"; ReturnToken[37] = "Braces";
            KeyWords[38] = "0"; ReturnToken[38] = "Constant";
            KeyWords[39] = "1"; ReturnToken[39] = "Constant";
            KeyWords[40] = "2"; ReturnToken[40] = "Constant";
            KeyWords[41] = "3"; ReturnToken[41] = "Constant";
            KeyWords[42] = "4"; ReturnToken[42] = "Constant";
            KeyWords[43] = "5"; ReturnToken[43] = "Constant";
            KeyWords[44] = "6"; ReturnToken[44] = "Constant";
            KeyWords[45] = "7"; ReturnToken[45] = "Constant";
            KeyWords[46] = "8"; ReturnToken[46] = "Constant";
            KeyWords[47] = "9"; ReturnToken[47] = "Constant";
            KeyWords[48] = "\""; ReturnToken[48] = "Quotation Mark";
            KeyWords[49] = "\'"; ReturnToken[49] = "Quotation Mark";
            KeyWords[50] = "Using"; ReturnToken[50] = "Inclusion";
            KeyWords[51] = "("; ReturnToken[51] = "Braces";
            KeyWords[52] = ")"; ReturnToken[52] = "Braces";
            KeyWords[53] = "--"; ReturnToken[53] = "Comment";
            KeyWords[54] = ";"; ReturnToken[54] = "SemiColon";
        }

        private static void BuildingDFA()
        {
            for (int i = 0; i < MAX; i++)
            {
                dfa.AddTransition(KeyWords[i], ReturnToken[i]);
            }
        }

        private static string[] SplitLine(string data, ref int size)
        {
            string[] tokens = new string[20];
            size = 0;
            string currentData = "";
            foreach (var c in data)
            {
                if (Char.IsWhiteSpace(c))
                {
                    if (String.IsNullOrEmpty(currentData)) continue;
                    tokens[size++] = currentData;
                    currentData = "";
                }
                else
                {
                    currentData += c;
                }
            }
            if (!string.IsNullOrEmpty(currentData))
            {
                tokens[size++] = currentData;
            }
            return tokens;
        }

        public static List<string> output = new List<string>();

        public static void GoMultiComment(string[] tokens, int startIndex, int endIndex, int numberOfLine)
        {
            for (int x = startIndex; x < endIndex; x++)
            {
                if (tokens[x] == "*>")
                {
                    multiComment--;
                    CorrectTokens(numberOfLine, tokens[x], "Comment");
                    GoCheckLine(tokens, x + 1, endIndex, numberOfLine);
                    return;
                }
                CorrectTokens(numberOfLine, tokens[x], "Comment");
            }
        }

        public static void GoCheckLine(string[] tokens, int startIndex, int endIndex, int numberOfLine)
        {
            if (multiComment > 0)
            {
                GoMultiComment(tokens, startIndex, endIndex, numberOfLine);
                return;
            }
            bool isComment = false;
            for (int index = startIndex; index < endIndex; index++)
            {
                string Token = dfa.Search(tokens[index]);
                if (tokens[index] == "<*")
                {
                    multiComment++;
                    GoMultiComment(tokens, index, endIndex, numberOfLine);
                    return;
                }
                if (tokens[index] == "--" || isComment)
                {
                    isComment = true;
                    CorrectTokens(numberOfLine, tokens[index], "Comment");
                }
                else if (Token == "-1")
                {
                    ++numberOfErrors;
                    WrongTokens(numberOfLine, tokens[index]);
                }
                else
                {
                    CorrectTokens(numberOfLine, tokens[index], Token);
                }
            }
        }

        public static void CheckLine(string line, int startIndex, int numberOfLine)
        {
            int size = 0;
            var tokens = SplitLine(line, ref size);
            GoCheckLine(tokens, 0, size, numberOfLine);
        }

        private static void CorrectTokens(int numberOfLine, string TokenText, string TokenType)
        {
            string lineOfOutput = $"Line: {numberOfLine}   Token Text: {TokenText}   Token Type: {TokenType}";
            output.Add(lineOfOutput);
        }

        private static void WrongTokens(int numberOfLine, string TokenText)
        {
            string lineOfOutput = $"Line: {numberOfLine}   Error in Token Text: {TokenText}";
            output.Add(lineOfOutput);
        }
        public static List<string> RUN(string input)
        {
            DefineKeywords();
            BuildingDFA();

            int LineNumber = 1;
            List<string> lines = new List<string>();
            string s = "";
            for (int x = 0; x < input.Length; x++)
            {
                if (input[x] == '\n')
                {
                    lines.Add(s);
                    s = "";
                    continue;
                }
                s += input[x];
            }
            if (s.Length != 0) lines.Add(s);
            foreach (string line in lines)
            {
                CheckLine(line, 0, LineNumber);
                ++LineNumber;
            }
            string errors = "Total Number of ERORRS: " + numberOfErrors;
            output.Add(errors);

            return output;
        }
    }
}