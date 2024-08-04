
namespace Trench.Fwk.Domain.Contracts
{
    public class SwitchStateChangedEventArgs<T> : EventArgs
        where T :  System.IEquatable<T>, IIdentifier<T>
    {
        public bool NewState { get; }
        public IIdentifier<T> identity { get; }
        public Type Type { get; }


        public SwitchStateChangedEventArgs(bool newState, IIdentifier<T> identity, Type type)
        {
            NewState = newState;
            this.identity = identity;
            Type = type;
        }
    }
}