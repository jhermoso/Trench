

namespace Trench.Fwk.Domain.Contracts
{
    public record struct Identifier<T> : IEquatable<T>, IEquatable<Identifier<T>>, IIdentifier<T> where T : IEquatable<T>
    {
        private readonly T? value;

        public T? Value => value;
        public Identifier(){
            if (typeof(T) == typeof(Guid)) value = (T?)(object)Guid.NewGuid;
            else value = default;
        }

        public Identifier(T? newValue){
            value = newValue;
        }

        // Conversión explícita al tipo base
        public static explicit operator T?(Identifier<T> id) => id.value;

        public bool Equals(T? other)
        {
            if (other == null) return false;
            return value.Equals(other);
        }
    }
}
