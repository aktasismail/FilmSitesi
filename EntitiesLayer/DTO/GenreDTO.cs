namespace EntitiesLayer.DTO
{
    public record GenreDTO
    {
        public int GenreId { get; init; }
        public string? MovieGenre { get; init; }
    }
}
