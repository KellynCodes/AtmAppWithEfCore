using AtmDAL.Enums;
using System.Collections.Generic;

namespace AtmDAL.Models
{
    public class Atm : BaseEntity
    {
        public string Name { get; set; }
        public decimal AvailableCash { get; set; }
        public string CurrentLanguage { get; set; }
    }

}