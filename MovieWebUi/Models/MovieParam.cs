
namespace MovieWebUi.Models
{
    public class MovieParam
    {
        public uint MinRate { get; set; } = 8;
        public uint MaxRate { get; set; } = 10;
        public string? SearchParameter { get; set; }
        public string? Fields { get; set; }
    }
}
