using AtmDAL.Enums;

namespace AtmDAL.Models
{
    public class Customer : User
    {
        public Customer(int id, string password) : base(id, password) { }
        public override string Role { get; set; }
        public Account Account { get; set; }
    }
}