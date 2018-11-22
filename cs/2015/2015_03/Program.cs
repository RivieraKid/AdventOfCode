using System;
using System.Collections.Generic;

namespace _2015_03
{
    class Program
    {
        static Dictionary<string, int> visitedHouses = new Dictionary<string, int>();

        static void Main()
        {
            int sX = 0;
            int sY = 0;
            int rSX = 0;
            int rSY = 0;
            bool roboSanta = false;
            string line;

            visitedHouses.Add("0,0", 2);

            System.IO.StreamReader file = new System.IO.StreamReader("input");
            while ((line = file.ReadLine()) != null)
            {
                foreach (char direction in line)
                {
                    if (!roboSanta){
                        switch (direction)
                        {
                            case '^':
                                sY++;
                                break;
                            case '>':
                                sX++;
                                break;
                            case 'v':
                                sY--;
                                break;
                            case '<':
                                sX--;
                                break;
                        }

                        IncrementValue(visitedHouses, GetCoord(sX, sY));
                    }
                    else
                    {
                        switch (direction)
                        {
                            case '^':
                                rSY++;
                                break;
                            case '>':
                                rSX++;
                                break;
                            case 'v':
                                rSY--;
                                break;
                            case '<':
                                rSX--;
                                break;
                        }

                        if (!((rSX == 0) && (rSY == 0)))
                        {
                            IncrementValue(visitedHouses, GetCoord(rSX, rSY));
                        }
                    }
                    roboSanta = !roboSanta;
                }
            }

            Console.WriteLine($"{visitedHouses.Count} houses have at least one present");
        }

        static string GetCoord(int x, int y){
            return x.ToString() + ',' + y.ToString();
        }

        static void IncrementValue(Dictionary<string,int> dic, string key){
            int val = 1;
            if (dic.ContainsKey(key)){
                dic.TryGetValue(key, out val);
                dic.Remove(key);
                val++;
            }
            dic.Add(key, val);
        }
    }
}
