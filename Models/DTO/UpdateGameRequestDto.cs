namespace TekkenPortugal.WebApi.Models.DTO
{
    public class UpdateGameRequestDto
    {
        public string Description { get; set; } = string.Empty;

        public string? StartggId { get; set; } = string.Empty;

        public string? ChallongeId { get; set; } = string.Empty;
    }
}
