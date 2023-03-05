namespace AtmDAL.Models
{
    public class User : BaseEntity
    {
        public User() { }

        protected User(int id, string password)
        {
            Password = password;
            Id = id;
        }

        public int BankId { get; set; }
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public virtual string Role { get; set; }
        public ICollection<Bank> Bank { get; set; }
        public ICollection<Account> Account { get; set; }
    }
}
