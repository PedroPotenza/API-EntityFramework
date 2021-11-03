using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_EntityFramework.Models
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        public Plan Plan { get; set; } //obs: many Contracts are associated with one Plan
        public DateTime CreateTime { get; set; }
        public bool Active { get; set; } 
        public History History { get; set; } //obs: one to one relationship
    }
}