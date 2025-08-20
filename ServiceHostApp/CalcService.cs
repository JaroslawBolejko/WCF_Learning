using Contracts;

namespace ServiceHostApp
{
    public class CalcService : ICalculator
    {
        public int Add(int a, int b)
            => a + b;

        public int Multiply(int a, int b)
            => a * b;
    }
}
