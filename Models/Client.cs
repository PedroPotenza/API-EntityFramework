using System.ComponentModel.DataAnnotations;

namespace API_EntityFramework.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Name { get; set; }
        public string DateBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //missing plan id
    }
}