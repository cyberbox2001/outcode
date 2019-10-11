using System;
using System.Collections.Generic;
using System.IO;
namespace OutCode
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string path  = Environment.CurrentDirectory;
            string leftfile = Path.Combine(path, "left.txt");
            string rightfile = Path.Combine(path, "right.txt");;
            string outfile = Path.Combine(path, string.Format("{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss")));
            List<string> lleft = new List<string>(File.ReadAllLines(leftfile));
            List<string> lright = new List<string>(File.ReadAllLines(rightfile));
            List<string> lin = new List<string>();
            List<string> lout = new List<string>();
            int inc=0, ouc=0;
            foreach (var s in lleft)
            {
                List<string> tlist= lright.FindAll(o => o.Contains(s));
                if (tlist.Count>0)
                {
                    int index = 1;
                    foreach(var t in tlist)
                    {
                        Console.WriteLine($"查到的数据列表{index}：{t}" );
                        lin.Add(t);
                        index++;
                        inc++;
                    }
                }
                else
                {
                    Console.WriteLine($"----------------查不到的数据：{s}----------------");
                    lout.Add(string.Format("FARENAME like '%{0}%' or ", s));
                    ouc++;
                }
            }
            Console.WriteLine("查到的数据, 共" + inc);
            Console.WriteLine("查不到的数据, 共：" + ouc);
            Console.WriteLine("*********一共：" + (ouc + inc));
            File.WriteAllLines(outfile, lout.ToArray());

            Console.ReadKey();
        }
    }
}
