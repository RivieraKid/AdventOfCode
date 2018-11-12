using System;
using System.Linq;

namespace _2015_02
{
    class Program
    {
        static void Main()
        {
            string inputFile = "input";

            Int64 totalArea = 0;
            Int64 totalRibbon = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(inputFile);
            while((line = file.ReadLine())!=null){
                totalArea += CalculateArea(line);
                totalRibbon += CalculateRibbon(line);
            }
            Console.WriteLine($"Total area is {totalArea} sq. ft.");
            Console.WriteLine($"Total ribbon length {totalRibbon}");
        }

        private static Int64 CalculateArea(string dims)
        {
            Int64[] areas = new Int64[3];

            string[] arr = dims.Split('x');

            Int64.TryParse(arr[0], out long length);
            Int64.TryParse(arr[1], out long width);
            Int64.TryParse(arr[2], out long height);

            areas[0] = length * width;
            areas[1] = width * height;
            areas[2] = height * length;

            Int64 area = (areas[0] * 2) + (areas[1] * 2) + (areas[2] * 2) +
                Math.Min(areas[0], Math.Min(areas[1], areas[2]));

            return area;
        }

        private static Int64 CalculateRibbon(string dims)
        {
            Int64[] lengths = new Int64[3];

            string[] arr = dims.Split('x');

            Int64.TryParse(arr[0], out lengths[0]);
            Int64.TryParse(arr[1], out lengths[1]);
            Int64.TryParse(arr[2], out lengths[2]);

            Int64[] sorted = lengths.OrderBy(i => i).ToArray();

            return (sorted[0] * 2) + (sorted[1] * 2) +
                (sorted[0] * sorted[1] * sorted[2]);
        }
    }
}
