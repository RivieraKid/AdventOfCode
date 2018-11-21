using System;
using System.Collections.Generic;

namespace _2015_07
{
    class Program
    {
        static Dictionary<String, string> wires = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("input");
            while ((line = file.ReadLine()) != null){
                if (line.Contains("AND"))
                {
                    ProcessAND(line);
                }
                else if (line.Contains("LSHIFT"))
                {
                    ProcessLSHIFT(line);
                }
                else if (line.Contains("NOT"))
                {
                    ProcessNOT(line);
                }
                else if (line.Contains("RSHIFT"))
                {
                    ProcessRSHIFT(line);
                }
                else if (line.Contains("OR"))
                {
                    ProcessOR(line);
                }
                else
                {
                    string signal;
                    string wire;

                    string[] items = line.Split(" -> ");
                    signal = items[0];
                    wire = items[1];

                    AddSignalToWire(signal, wire);
                }
            }

            Console.WriteLine($"The value of wire 'a' is \"{GetWireValue("a")}\"");

            Console.WriteLine($"d: {GetWireValue("d")}");
            Console.WriteLine($"e: {GetWireValue("e")}");
            Console.WriteLine($"f: {GetWireValue("f")}");
            Console.WriteLine($"g: {GetWireValue("g")}");
            Console.WriteLine($"h: {GetWireValue("h")}");
            Console.WriteLine($"i: {GetWireValue("i")}");
            Console.WriteLine($"x: {GetWireValue("x")}");
            Console.WriteLine($"y: {GetWireValue("y")}");
        }

        static void ProcessNOT(string line)
        {
            string s = "";
            //string s2 = "";
            string d = "";
            string tmp = line;
            string[] parse = line.Split(" -> ");
            UInt16 val1 = 0;
            //Int16 val2 = 0;

            d = parse[1];
            tmp = parse[0];
            parse = tmp.Split(" ");
            //s1 = parse[0];
            s = parse[1];

            UInt16.TryParse(GetWireValue(s), out val1);

            val1 = NOTHack(val1);

            //val1 = ~((val1 & 0xFF00) >> 8) + ~(val1 & 0xFF);

            //val1 = ~(UInt16)val1;

            AddSignalToWire(val1.ToString(), d);
        }

        static void ProcessRSHIFT(string line)
        {
            string s1 = "";
            string s2 = "";
            string d = "";
            string tmp = line;
            string[] parse = line.Split(" -> ");
            Int16 val1 = 0;
            Int16 val2 = 0;

            d = parse[1];
            tmp = parse[0];
            parse = tmp.Split(" RSHIFT ");
            s1 = parse[0];
            s2 = parse[1];

            Int16.TryParse(GetWireValue(s1), out val1);
            Int16.TryParse(s2, out val2);

            for (Int16 i = val2; i > 0; i--)
            {
                val1 /= 2;
            }

            AddSignalToWire(val1.ToString(), d);
        }

        static void ProcessLSHIFT(string line)
        {
            string s1 = "";
            string s2 = "";
            string d = "";
            string tmp = line;
            string[] parse = line.Split(" -> ");
            Int16 val1 = 0;
            Int16 val2 = 0;

            d = parse[1];
            tmp = parse[0];
            parse = tmp.Split(" LSHIFT ");
            s1 = parse[0];
            s2 = parse[1];

            Int16.TryParse(GetWireValue(s1), out val1);
            Int16.TryParse(s2, out val2);

            for (Int16 i = val2; i > 0;i--){
                val1 *= 2;
            }

            AddSignalToWire(val1.ToString(), d);
        }

        static void ProcessOR(string line)
        {
            string s1 = "";
            string s2 = "";
            string d = "";
            string tmp = line;
            string[] parse = line.Split(" -> ");
            Int16 val1 = 0;
            Int16 val2 = 0;

            d = parse[1];
            tmp = parse[0];
            parse = tmp.Split(" OR ");
            s1 = parse[0];
            s2 = parse[1];

            Int16.TryParse(GetWireValue(s1), out val1);
            Int16.TryParse(GetWireValue(s2), out val2);

            AddSignalToWire((val1 | val2).ToString(), d);
        }

        static void ProcessAND(string line)
        {
            string s1 = "";
            string s2 = "";
            string d = "";
            string tmp = line;
            string[] parse = line.Split(" -> ");
            Int16 val1 = 0;
            Int16 val2 = 0;

            d = parse[1];
            tmp = parse[0];
            parse = tmp.Split(" AND ");
            s1 = parse[0];
            s2 = parse[1];

            Int16.TryParse(GetWireValue(s1), out val1);
            Int16.TryParse(GetWireValue(s2), out val2);

            AddSignalToWire((val1 & val2).ToString(), d);
        }

        static string GetWireValue (string wire) {
            string value = "";
            if ( wires.ContainsKey(wire)){
                wires.TryGetValue(wire, out value);
            }

            return value;
        }

        static void AddSignalToWire(string signal, string wire){
            if (wires.ContainsKey(wire)){
                wires.Remove(wire);
            }
            wires.Add(wire, signal);
        }

        static UInt16 NOTHack(UInt16 val){
            UInt16 res = 0;
            UInt16 bitPosVal = 0;
            UInt16 bitVal = 0;
            for (UInt16 i = 0; i<16;i++){
                bitPosVal = (UInt16)Math.Pow(2, i);
                bitVal = (UInt16)((val & bitPosVal) >> i);
                if (bitVal==0){
                    res += bitPosVal;
                }
            }
            return res;
        }
    }
}
