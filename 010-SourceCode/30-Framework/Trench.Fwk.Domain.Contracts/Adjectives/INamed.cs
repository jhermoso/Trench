

namespace Trench.Fwk.Domain.Contracts
{
    public interface INamed
    {
        string Name { get; }

        void Rename(string newName);
    }
}
