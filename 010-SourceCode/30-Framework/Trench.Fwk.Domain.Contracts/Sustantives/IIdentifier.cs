
namespace Trench.Fwk.Domain.Contracts
{
    public interface IIdentifier<T> where T :  IEquatable<T>
    {
        T Value { get; }
    }
}