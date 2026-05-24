namespace aireline_system.Models
{
    internal struct Admin
    {
        public int AdminId;

        public string Username;

        public string FullName;

        public string Email;

        public string PasswordHash;

        public string Role;

        public bool IsActive;

        public int FailedAttempts;

        public DateTime LockedUntil;

        public DateTime LastLogin;

        public DateTime CreatedAt;
    }
}