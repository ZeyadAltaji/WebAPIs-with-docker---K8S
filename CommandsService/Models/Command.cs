using System.ComponentModel.DataAnnotations;

namespace CommandsService.Models
{
    public class Command
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string  HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
        [Required]
        public int PlatFromsId { get; set; }
        public PlatFroms platFroms{get;set;}
        public object PlatFroms { get; internal set; }
    }
}