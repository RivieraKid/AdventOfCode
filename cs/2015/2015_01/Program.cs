using System;
using CommandLine;

namespace _2015_01
{
    class Program
    {

        public class Options {
            [Option('i', "input", Required = true, HelpText = "Input ot the program")]
            public String Input { get; set; }
        }

        static void Main(string[] args)
        {
            String input = "";
            Int64 floor = 0;
            bool basementFound = false;
            Int64 basementPos = 0;
            Int64 pos = 1;

            Parser.Default.ParseArguments<Options>(args)
                  .WithParsed<Options>(o =>
            {
                if (o.Input != null)
                {
                    input = o.Input;
                }
                else
                {
                    Console.WriteLine($"Current Arguments: -v {o.Input}");
                    Console.WriteLine("Quick Start Example!");
                }
            });

            foreach (char c in input.ToCharArray()){
                switch (c){
                    case '(':
                        floor++;
                        break;
                    case ')':
                        floor--;
                        break;
                }
                if (!basementFound && floor == -1){
                    basementFound = true;
                    basementPos = pos;
                }
                pos++;
            }

            Console.WriteLine($"Final floor number: {floor}");
            Console.WriteLine($"Position of first time in basement: {basementPos}");

        }
    }
}
