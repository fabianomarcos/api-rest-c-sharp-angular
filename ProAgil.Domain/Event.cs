using System;
using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public DateTime DateEvent { get; set; }
        public string Theme { get; set; }
        public int AmountPeoples { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Lot { get; set; }

        public List<Lot> Lots { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
    }
}
