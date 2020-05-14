using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiniCurriculum { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<SocialNetwork> SocialNetwork { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
    }
}