using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StartApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                FileInfo fi = new FileInfo(args[0]);
                if (fi.Length == 0)
                    Console.Write("打开了一个空文件！");
                else if (fi.Length < 4096)
                    Console.Write("打开了一个中型文件！");
                else
                    Console.Write("打开了一个大型文件！");

                Console.WriteLine($" 文件路径为：{fi.FullName}");

            }
            else
                Console.WriteLine($"打开文件没有传递参数！");

            Console.ReadKey();
        }
    }
}
