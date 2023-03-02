namespace AtmDAL.Models
{
    public class Transaction : BaseEntity
    {
        public int TransactionId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDate { get; set; }
        public ICollection<Account> Account { get; set; }
    }
}
