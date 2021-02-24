using System.ComponentModel.DataAnnotations;

namespace DataModels.DTO_s
{
    public class CommandDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Building { get; set; }
        [Required]
        [MaxLength(250)]
        public string RestAPI { get; set; }
        [Required]
        [MaxLength(250)]
        public string Project { get; set; }
    }
}
