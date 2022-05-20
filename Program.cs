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
            RunScanner scanner = new RunScanner();
            int LineNumber = 1;
            string path = @"C:\Users\3m\Desktop\one.txt";
            foreach (string line in File.ReadLines(path))
            {
                scanner.CheckLine(line, 0 , LineNumber);
                ++LineNumber;
            }
            foreach (var line in RunScanner.output)
                Console.WriteLine(line);
            Console.WriteLine("===========================================================================");
            Console.WriteLine("Total NO of errors: " + scanner.numberOfErrors);
        }
    }
}