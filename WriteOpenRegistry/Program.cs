using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WriteOpenRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("参数传入不正确！！提示：第一个参数为扩展名，第二个参数为处理扩展名的项，第三个启动exe路径。");
                Console.ReadKey();
                return;
            }

            string ext = args[0];
            string process = args[1];
            string startapp = args[2];

            RegistryKey classroot = Registry.ClassesRoot;

            //创建后缀注册表 设置默认值
            RegistryKey extKey = classroot.CreateSubKey(ext);
            extKey.SetValue("", process, RegistryValueKind.String);
            extKey.Close();

            //创建打开文件注册表 设置默认值
            RegistryKey commandKey = classroot.CreateSubKey($"{process}\\Shell\\Open\\Command");
            commandKey.SetValue("", $"{startapp} %1", RegistryValueKind.String);
            commandKey.Close();

            classroot.Close();

            Console.WriteLine("创建成功！");
            Console.ReadKey();
        }
    }
}
