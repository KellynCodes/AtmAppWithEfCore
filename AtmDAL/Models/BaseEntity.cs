using System.ComponentModel.DataAnnotations;

namespace AtmDAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        [Timestamp]
        public byte[] Concurrency { get; set; }
    }
}
