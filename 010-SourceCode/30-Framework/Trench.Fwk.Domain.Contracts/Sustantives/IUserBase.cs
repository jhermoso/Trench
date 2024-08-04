namespace Trench.Fwk.Domain.Contracts
{
    public interface IUserBase
    {
        public string UserName { get; }

        public string Email { get; }
        public string Password { get; }

        public void ChangeUserName(string newName);

        public void ChangeEmail(string newEmail);

        public void ChangePassword(string newPassword);
    }
}
