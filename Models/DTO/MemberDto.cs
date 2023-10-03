namespace TekkenPortugal.WebApi.Models.DTO
{
    public class MemberDto
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public SocialMediaDto? SocialMedia { get; set; }
    }
}
