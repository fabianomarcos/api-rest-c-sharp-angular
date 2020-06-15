using System.Collections.Generic;

namespace ProAgil.WebAPI.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string DateEvent { get; set; }
        public string Theme { get; set; }
        public int amountPeople { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<LotDto> Lots { get; set; }
        public List<SocialNetworkDto> SocialNetworks { get; set; }
        public List<SpeakerDto> Speakers { get; set; }
    }
}