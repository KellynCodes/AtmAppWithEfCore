namespace AtmDAL.Models
{
    public class Transaction : BaseEntity
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDate { get; set; }
    }
}
