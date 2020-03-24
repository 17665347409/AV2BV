using System;
using System.Collections.Generic;

namespace AV2BV
{
    static class Program
    {
        static void Main(string[] args)
        {
            AV2BVClass a = new AV2BVClass();
            while (true)
            {
                Console.WriteLine("请选择功能 1.AV号转BV号 2.BV号转AV号 3.退出：");
                dynamic functionchoose = Console.ReadLine();
                if (functionchoose == "1")
                {
                    Console.WriteLine("请输入AV号（不要带AV）：");
                    dynamic result = a.enc(Console.ReadLine());
                    Console.WriteLine("==============生成BV号====================");
                    Console.WriteLine(result);
                    Console.WriteLine("========================================");
                }
                else if (functionchoose == "2")
                {
                    Console.WriteLine("请输入BV号（带BV）：");
                    dynamic result = a.dec(Console.ReadLine());
                    Console.WriteLine("==============生成AV号====================");
                    Console.WriteLine(result);
                    Console.WriteLine("========================================");
                }
                else if (functionchoose == "3")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("输入有误，请重新选择");
                }
            }
        }
    }

    public class AV2BVClass
    {
        string table = "fZodR9XQDSUm21yCkr6zBqiveYah8bt4xsWpHnJE7jL5VG3guMTKNPAwcF";
        Dictionary<dynamic, dynamic> tr = new Dictionary<dynamic, dynamic>();
        int[] s = { 11, 10, 3, 8, 4, 6 };
        long xor = 177451812;
        long add = 8728348608;
        public AV2BVClass()
        {
            for (int i = 0; i < 58; i++)
            {
                tr[table[i]] = i;
            }
        }

        public string dec(string bid)
        {
            long r = 0;
            for (int i = 0; i < 6; i++)
            {
                r += tr[bid[s[i]]] * Math.Pow(58, i);
            }

            return "AV" + ((r - add) ^ xor).ToString();
        }

        public string enc(dynamic aid)
        {
            aid = long.Parse(aid);
            aid = (aid ^ xor) + add;
            dynamic[] r = { "B", "V", "1", " ", " ", "4", " ", "1", " ", "7", " ", " " };
            for (int i = 0; i < 6; i++)
            {
                r[s[i]] = table[(int)(aid / Math.Pow(58, i) % 58)];
            }
            string rstring = "";
            for (int j = 0; j < r.Length; j++)
            {
                rstring += r[j];
            }
            return rstring;
        }
    }
}