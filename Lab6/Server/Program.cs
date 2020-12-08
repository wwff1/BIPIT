using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------WCF хост----------------------");
            using (var s = new ServiceHost(typeof(Service1)))
            {
                s.Open();                
                Console.WriteLine("Сервис запущен...");
               // DisplayHostInfo(s);
                Console.WriteLine("Нажать Enter для остановки...");
                Console.ReadKey();
                s.Close();
            }
        }

        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine();
            Console.WriteLine("***** Host Info *****");
            Console.WriteLine($"Name: {host.Description.ConfigurationName}");
            Console.WriteLine($"Port: {host.BaseAddresses[0].Port}");
            Console.WriteLine($"LocalPath: {host.BaseAddresses[0].LocalPath}");
            Console.WriteLine($"Uri: {host.BaseAddresses[0].AbsoluteUri}");
            Console.WriteLine($"Scheme: {host.BaseAddresses[0].Scheme}");
            Console.WriteLine("***********************************");
            Console.WriteLine();
        }
    }
}
