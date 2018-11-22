using System;

namespace _2015_01
{
    class Program
    {
        static void Main()
        {
            Int64 floor = 0;
            bool basementFound = false;
            Int64 basementPos = 0;
            Int64 pos = 1;

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("input");
            line = file.ReadLine();

            foreach (char c in line){
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
