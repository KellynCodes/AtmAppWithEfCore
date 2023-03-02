﻿namespace AtmDAL.Models
{
    public class User : BaseEntity
    {
        public User() { }

        protected User(int id, string password)
        {
            Password = password;
            Id = id;
        }

        public int UserId { get; set; }
        public int BankId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public virtual string Role { get; set; }
        public ICollection<Bank> Bank { get; set; }

    }
}