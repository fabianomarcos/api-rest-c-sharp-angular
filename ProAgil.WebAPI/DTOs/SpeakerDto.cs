using System.Collections.Generic;

namespace ProAgil.WebAPI.DTOs
{
    public class SpeakerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiniCurriculum { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<SocialNetworkDto> SocialNetwork { get; set; }
        public List<EventDto> Events { get; set; }
    }
}