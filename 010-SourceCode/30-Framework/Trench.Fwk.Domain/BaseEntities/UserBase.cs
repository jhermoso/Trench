

using System.Globalization;
using Trench.Fwk.Domain.Contracts;

namespace Trench.Fwk.Domain
{

    [Serializable]
    public sealed class UserBase<T> : EntityBase<T> , IUserBase, IEntity<T>
         where T :  IEquatable<T>
    {
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        public UserBase( string userName, string email, string password)
        {

            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}

