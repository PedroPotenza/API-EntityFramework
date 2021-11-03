using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace API_EntityFramework.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //[ForeignKey("Plan")]
        //public Plan PlanSelected { get; set; }
        //public int FKPlan { get; set; }
    }
}