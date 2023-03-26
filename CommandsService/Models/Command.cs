namespace CommandsService.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string  HowTo { get; set; }
        public string CommandLine { get; set; }
        public int PlatFromsId { get; set; }
        public PlatFroms platFroms{get;set;}
    }
}