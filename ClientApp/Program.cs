using Contracts;
using System;
using System.ServiceModel;

namespace ClientApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8080/CalcService");
            BasicHttpBinding binding = new BasicHttpBinding();

            ChannelFactory<ICalculator> factory = new ChannelFactory<ICalculator>(binding, endpointAddress);
            ICalculator channel = factory.CreateChannel();

            Console.WriteLine("2 + 3 = " + channel.Add(2, 3));
            Console.WriteLine("10 + 20 = " + channel.Add(10, 20));
            Console.WriteLine("10 * 20 = " + channel.Multiply(10, 20));

            ((IClientChannel)channel).Close();
            factory.Close();

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine(); 
        }
    }
}
