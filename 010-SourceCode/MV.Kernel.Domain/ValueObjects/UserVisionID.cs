

using Trench.Fwk.Domain.Contracts;

namespace MV.Kernel.Domain.Contracts
{


    [Serializable]
    public record struct UserVisionID : IIdentifier<Guid>
    {
        private Identifier<Guid> id;

        public Guid Value => id.Value;

        public bool Equals(Identifier<Guid> other)
        {
            return id.Equals(other);
        }

    }
}
