using System;
using System.Text.RegularExpressions;

namespace _2015_05
{
    class Program
    {
        static readonly string[] _badWords= {"ab", "cd", "pq", "xy"};
        static void Main()
        {
            Int64 vowels = 0;
            Int64 goodWords1 = 0;
            Int64 badWords1 = 0;
            Int64 goodWords2 = 0;
            Int64 badWords2 = 0;
            bool twoLetters = false;
            bool badStrings = false;
            string line = "";



            System.IO.StreamReader file = new System.IO.StreamReader("input");
            while ((line = file.ReadLine()) != null){
                vowels = CheckVowels(line);
                twoLetters = CheckTwoLetters(line);
                badStrings = CheckBadStrings(line);
                if (( vowels      > 2 ) &&
                    ( twoLetters ) &&
                    ( !badStrings ))
                {
                    goodWords1++;
                }
                else{
                    badWords1++;
                }
                bool tlno = TwoLettersNonOverlap(line);
                bool olrwg = OneLetterRepeatWithGap(line);
                if (tlno && olrwg){
                    goodWords2++;
                }
                else{
                    badWords2++;
                }
            }

            Console.WriteLine("##########");
            Console.WriteLine("#        #");
            Console.WriteLine("# PART 1 #");
            Console.WriteLine("#        #");
            Console.WriteLine("##########");
            Console.WriteLine($"There are {goodWords1} nice words and {badWords1} naughty words.");
            Console.WriteLine("##########");
            Console.WriteLine("#        #");
            Console.WriteLine("# PART 2 #");
            Console.WriteLine("#        #");
            Console.WriteLine("##########");
            Console.WriteLine($"There are {goodWords2} nice words and {badWords2} naughty words.");
        }

        static Int64 CheckVowels(string line){
            Int64 count;

            count = line.Length - line.Replace("a", "").Length;
            count += line.Length - line.Replace("e", "").Length;
            count += line.Length - line.Replace("i", "").Length;
            count += line.Length - line.Replace("o", "").Length;
            count += line.Length - line.Replace("u", "").Length;

            return count;
        }

        static bool CheckTwoLetters(string line){
            return Regex.IsMatch(line,"([a-zA-Z])\\1{1}");
        }

        static bool CheckBadStrings(string line){
            foreach(string word in _badWords){
                if (line.Contains(word)){
                    return true;
                }
            }
            return false;
        }

        static bool TwoLettersNonOverlap(string line){
            return Regex.IsMatch(line, @"(..).*\1");
        }

        static bool OneLetterRepeatWithGap(string line){
            return Regex.IsMatch(line, @"(.).\1");
        }
    }
}
