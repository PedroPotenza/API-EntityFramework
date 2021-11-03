using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_EntityFramework.Models
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
        public int ContractId { get; set; } //obs: one to one relationship with Contract
        public Contract Contract { get; set; } //obs: one to one relationship with Contract
        
    }
}