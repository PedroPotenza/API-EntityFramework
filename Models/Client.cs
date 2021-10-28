using System.ComponentModel.DataAnnotations;

namespace API_EntityFramework.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }  
        public int Idade { get; set; }

    }
}