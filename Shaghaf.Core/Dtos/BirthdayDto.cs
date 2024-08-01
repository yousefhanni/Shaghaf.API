using System.ComponentModel.DataAnnotations;

namespace Shaghaf.Core.Dtos
{
    public class BirthdayDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<CakeDto> Cakes { get; set; }
        [Required]
        public List<DecorationDto> Decorations { get; set; }
    }
}