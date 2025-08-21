using Contracts;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServiceHostApp
{
    public class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(CalcService)))
            {
                host.Open();
                Console.WriteLine("Host is running. Press ENTER to finish...");
                Console.ReadLine();
            }
        }
    }
}
