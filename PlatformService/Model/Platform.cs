using System.ComponentModel.DataAnnotations;

namespace PlatformService.Model
{
    public class platform
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string  Cost { get; set; }
    }
}