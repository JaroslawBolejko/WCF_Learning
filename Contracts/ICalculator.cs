using System.ServiceModel;

namespace Contracts
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int a, int b);

        [OperationContract]
        int Multiply(int a, int b);
    }
}
