namespace TekkenPortugal.WebApi.Models.DTO
{
    public class CreateGameRequestDto
    {
        public string Description { get; set; } = string.Empty;

        public string? StartggId { get; set; } = string.Empty;

        public string? ChallongeId { get; set; } = string.Empty;
    }
}
