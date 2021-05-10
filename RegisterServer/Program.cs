using SharpShell.ServerRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegisterServer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("请正确输入参数！提示：第一个参数为-register或-unregister，第二个参数为Dll的路径。");
                Console.ReadKey();
                return;
            }

            string dllPath = args[1];
            ServerEntry serverEntry = ServerManagerApi.LoadServer(dllPath);

            if (args[0] == "-register")
            {
                //安装Server, x64 mode.
                ServerRegistrationManager.InstallServer(serverEntry.Server, RegistrationType.OS64Bit, true);
                Console.WriteLine("安装Server x64成功！");

                //注册Server, x64 mode.
                ServerRegistrationManager.RegisterServer(serverEntry.Server, RegistrationType.OS64Bit);
                Console.WriteLine("注册Server x64成功！");
            }

            if (args[0] == "-unregister")
            {
                //卸载Server, x64 mode.
                ServerRegistrationManager.UninstallServer(serverEntry.Server, RegistrationType.OS64Bit);
                Console.WriteLine("卸载Server x64成功！");
                //注销Server, x64 mode.
                ServerRegistrationManager.UnregisterServer(serverEntry.Server, RegistrationType.OS64Bit);
                Console.WriteLine("注销Server x64成功！");
            }

            Console.ReadKey();
        }
    }
}
