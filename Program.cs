using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompilerWithTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in RunScanner.RUN("heloo -- comment"))
            {
                Console.WriteLine(line);
            }
        }
    }
}