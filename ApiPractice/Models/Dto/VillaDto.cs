using System.ComponentModel.DataAnnotations;

namespace ApiPractice.Models.Dto
{
    public class VillaDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
