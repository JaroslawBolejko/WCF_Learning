using Contracts;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServiceHostApp
{
    internal class Program
    {
        static void Main()
        {
            var baseAddress = new Uri("http://localhost:8080/CalcService");

            using (var host = new ServiceHost(typeof(CalcService), baseAddress))
            {
                // endpoint: Contract + Binding + Address
                host.AddServiceEndpoint(typeof(ICalculator), new BasicHttpBinding(), "");

                // metadata (WSDL)
                var smb = new ServiceMetadataBehavior { HttpGetEnabled = true };
                host.Description.Behaviors.Add(smb);
                host.AddServiceEndpoint(
                    typeof(IMetadataExchange),
                    MetadataExchangeBindings.CreateMexHttpBinding(),
                    "mex");

                host.Open();
                Console.WriteLine("WCF works on " + baseAddress);
                Console.WriteLine("WSDL: " + baseAddress + "?wsdl");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
        }
    }
}
