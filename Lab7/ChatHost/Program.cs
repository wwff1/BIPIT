using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(wcf_chat.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Сервис запущен...");
                DisplayHostInfo(host);
                Console.WriteLine("Нажать Enter для остановки...");
                Console.ReadKey();
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
