using System;
using System.Security.Cryptography;
using System.Text;

namespace _2015_04
{
    class Program
    {
        static string input = "iwrupvqb";
        static Int64 count = 0;

        static void Main(string[] args)
        {
            byte[] md5;
            string cksum = "";

            // For part two, just change the string below to "000000"
            while (!(cksum.StartsWith("00000"))){
                count++;
                md5 = ComputeMD5(input + count.ToString());
                cksum = ByteArrayToString(md5);
            }
            Console.WriteLine($"Count is {count}, MD5 is {cksum}");
        }

        static byte[] ComputeMD5(string str){
            using (var md5 = MD5.Create()){
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                return result;
            }
        }

        static string ByteArrayToString(byte[] val){
            var ret = BitConverter.ToString(val).Replace("-", "");
            return ret;
        }
    }
}
