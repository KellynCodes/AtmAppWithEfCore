namespace AtmDAL.Models
{
    public class Bank : BaseEntity
    {
        public int BankId { get; set; }
        public string Name { get; set; }
        public string SwiftCode { get; set; }
        public ICollection<User> User { get; set; }
    }
}