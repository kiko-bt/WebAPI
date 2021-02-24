using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Building { get; set; }

        [Required]
        [MaxLength(250)]
        public string RestAPI { get; set; }

        [Required]
        public string Project { get; set; }
    }
}
