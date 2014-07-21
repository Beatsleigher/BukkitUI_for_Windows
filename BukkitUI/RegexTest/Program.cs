using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexTest {
    class Program {
        static void Main(string[] args) {
            String line = "update=>[name=\"Test\", desc=\"A test update package\", priority=\"Low\"] >>";
            Console.WriteLine("Testing RegEx on " + line);

            String[] details = Regex.Split((Regex.Split(Regex.Split(line, @"\[")[1], @"\]")[0]), "[,]");
            Console.WriteLine(@"Found following matches for patterns >> \[ & \] & [,]: ");
            foreach (String match in details)
                Console.WriteLine(match);

            Console.WriteLine("Matching previous matches with new pattern: [\"]");
            for (int i = 0; i < details.Length; i++) {
                Console.WriteLine("Matching pattern with " + details[i] + "...");
                Console.WriteLine(Regex.Split(details[i], "[\"]")[1]);
                Console.WriteLine("");
            }

                Console.ReadKey();
        }
    }
}
