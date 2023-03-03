using AtmDAL.Enums;

namespace AtmDAL.Models
{
    public class Account : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string AccountNo { get; set; }
        public AccountType AccountType { get; set; }
        public string Pin { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}