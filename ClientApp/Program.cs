using Contracts;
using System;
using System.ServiceModel;

namespace ClientApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<ICalculator> factory = new ChannelFactory<ICalculator>("BasicHttp_Calc");
            ICalculator channel = factory.CreateChannel();

            Console.WriteLine("10 + 20 = " + channel.Add(10, 20));
            Console.WriteLine("10 * 20 = " + channel.Multiply(10, 20));

            ((IClientChannel)channel).Close();
            factory.Close();

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
