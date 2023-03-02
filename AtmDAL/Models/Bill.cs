namespace AtmDAL.Models
{
    public class Bill : BaseEntity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}