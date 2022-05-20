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
            foreach (string line in RunScanner.RUN(@"Program
	<* Category x { 
		W decrease ( ) { 
			int reg3 = 5 ; 
			Continuewhen *> ( counter < num ) { 
				reg3 = reg3 - 1 ; 
			} 
		} 
	} -- Hello World
-- I AM A COMMENT 
End
<* klam kalm *> None x  "))
            {
                Console.WriteLine(line);
            }
        }
    }
}