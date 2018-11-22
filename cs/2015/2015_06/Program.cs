using System;
using System.Linq;

namespace _2015_06
{
    class Program
    {
        static readonly bool[,] lights = new bool[1000, 1000];
        static readonly int[,] brightness = new int[1000, 1000];

        static void Main()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("input");
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("turn on", StringComparison.CurrentCulture))
                {
                    TurnOnLights(line);
                }
                else if (line.StartsWith("turn off", StringComparison.CurrentCulture))
                {
                    TurnOffLights(line);
                }
                else
                {
                    ToggleLights(line);
                }
            }

            int litLights = CountLights();

            Console.WriteLine($"{litLights} lights are illuminated.");
            Console.WriteLine($"Total brightness is {GetBrightness()}");
        }

        static void TurnOnLights(string line)
        {
            string newLine = line.Replace("turn on ", "");
            newLine = newLine.Replace(" through ", ",");
            int[] coords = GetCoords(newLine);

            for (int x = coords[0]; x <= coords[2];x++){
                for (int y = coords[1]; y <= coords[3];y++){
                    lights[x, y] = true;
                    brightness[x, y]++;
                }
            }

        }

        static int[] GetCoords(string coords){
            string[] rawCoords = coords.Split(",");
            int[] intCoords = new int[4];
            int.TryParse(rawCoords[0], out intCoords[0]);
            int.TryParse(rawCoords[1], out intCoords[1]);
            int.TryParse(rawCoords[2], out intCoords[2]);
            int.TryParse(rawCoords[3], out intCoords[3]);
            return intCoords;
        }

        static void TurnOffLights(string line)
        {
            string newLine = line.Replace("turn off ", "");
            newLine = newLine.Replace(" through ", ",");
            int[] coords = GetCoords(newLine);

            for (int x = coords[0]; x <= coords[2]; x++)
            {
                for (int y = coords[1]; y <= coords[3]; y++)
                {
                    lights[x, y] = false;
                    brightness[x, y]--;
                    if (brightness[x,y]<0){
                        brightness[x, y] = 0;
                    }
                }
            }
        }

        static void ToggleLights(string line)
        {
            string newLine = line.Replace("toggle ", "");
            newLine = newLine.Replace(" through ", ",");
            int[] coords = GetCoords(newLine);

            for (int x = coords[0]; x <= coords[2]; x++)
            {
                for (int y = coords[1]; y <= coords[3]; y++)
                {
                    lights[x, y] = !lights[x, y];
                    brightness[x, y] += 2;
                }
            }
        }

        static int CountLights(){
            int litLights = 0;
            for (int y = 0; y < 1000;y++){
                for (int x = 0; x < 1000;x++){
                    if (lights[x,y]){
                        litLights++;
                    }
                }
            }
            return litLights;
        }

        static int GetBrightness(){
            return brightness.Cast<int>().Sum();
        }
    }
}
