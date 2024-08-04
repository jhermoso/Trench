using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Trench.Fwk.Domain.Contracts;

namespace MV.Kernel.Domain.Contracts
{
    [Serializable]
    public class UserVision : IEquatable<UserVision>, IEntity<UserVisionID>, IUserBase, IUserVision, ISwitchable
    {
        #region Fields
        private string _userName;
        private string _email;
        private string _password;
        private bool _active;
        private readonly UserVisionID _id;
        private readonly object _lockObject = new object();
        #endregion

        #region Constructors
        public UserVision(string userName, string email, string password)
        {
            // Preconditions
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (userName == null) throw new ArgumentNullException(nameof(userName));

            _userName = userName;
            _email = email;
            _password = password;
            _id = new UserVisionID();

            // Raise event user created
            OnUserCreated();
        }
        #endregion

        #region Properties
        public virtual UserVisionID Id => _id;

        [Required]
        public virtual string UserName => _userName;

        [Required, EmailAddress]
        public virtual string Email => _email;

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 100 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "La contraseña debe contener al menos una letra minúscula, una mayúscula, un número y un carácter especial.")]
        [DataType(DataType.Password)]
        public virtual string Password => _password;

        public bool IsActive => _active;
        #endregion

        #region Change Status Methods
        public void Activate()
        {
            lock (_lockObject)
            {
                if (_active) return;
                _active = true;
                OnUserActivated();
            }
        }

        public void Deactivate()
        {
            lock (_lockObject)
            {
                if (!_active) return;
                _active = false;
                OnUserDeactivated();
            }
        }

        public void ChangeUserName(string newName)
        {
            if (newName == null) throw new ArgumentNullException(nameof(newName));
            if (newName == _userName) return;
            _userName = newName;
            OnPropertyChanged(nameof(UserName));
        }

        public void ChangeEmail(string newEmail)
        {
            if (newEmail == null) throw new ArgumentNullException(nameof(newEmail));
            if (newEmail == _email) return;
            _email = newEmail;
            OnPropertyChanged(nameof(Email));
        }

        public void ChangePassword(string newPassword)
        {
            if (newPassword == null) throw new ArgumentNullException(nameof(newPassword));
            if (newPassword == _password) return;
            _password = newPassword;
            OnPropertyChanged(nameof(Password));
        }
        #endregion

        #region Events
        public event EventHandler? UserCreated;
        public event EventHandler? UserActivated;
        public event EventHandler? UserDeactivated;
        public event EventHandler<string>? PropertyChanged;

        protected virtual void OnUserCreated()
        {
            UserCreated?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnUserActivated()
        {
            UserActivated?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnUserDeactivated()
        {
            UserDeactivated?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, propertyName);
        }
        #endregion

        #region Equality
        public bool Equals(IEntity<UserVisionID>? other)
        {
            if (other is null) return false;
            return Id.Equals(other.Id);
        }

        public bool Equals(UserVision? other)
        {
            if (other is null) return false;
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_userName, _email, _password, _active, _id, GetType());
        }
        #endregion
    }
}

