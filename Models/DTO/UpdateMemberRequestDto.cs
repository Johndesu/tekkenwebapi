namespace TekkenPortugal.WebApi.Models.DTO
{
    public class UpdateMemberRequestDto
    {
        public string Nickname { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public SocialMediaDto? SocialMedia { get; set; }
    }
}
