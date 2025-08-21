using Contracts;
using System;
using System.ServiceModel;

namespace ClientApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<ICalculator> basicFactory = new ChannelFactory<ICalculator>("BasicHttp_Calc");
            ICalculator basicChannel = basicFactory.CreateChannel();

            Console.WriteLine("BasicHttp_calc");
            Console.WriteLine("10 + 20 = " + basicChannel.Add(10, 20));
            Console.WriteLine("10 * 20 = " + basicChannel.Multiply(10, 20));

            ((IClientChannel)basicChannel).Close();
            basicFactory.Close();

            ChannelFactory<ICalculator> wsFactory = new ChannelFactory<ICalculator>("WsHttp_Calc");
            ICalculator wsChannel = wsFactory.CreateChannel();

            Console.WriteLine("30 + 20 = " + wsChannel.Add(30, 20));
            Console.WriteLine("30 * 20 = " + wsChannel.Multiply(30, 20));

            ((IClientChannel)wsChannel).Close();
            wsFactory.Close();

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
