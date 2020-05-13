namespace ProAgil.Domain
{
    public class Event
    {
      public int Id { get; set; }
      public string Locale { get; set; }
      public DateTime DateEvent { get; set; }
      public string Theme { get; set; }
      public int AmountPeoples { get; set; }
      public string ImageUrl { get; set;}
      public string Phone { get; set; }
      public string Email { get; set; }
      public string Lot { get; set; }
      
      public List<Lot> Lot { get; set; }
      public list<SocialNetwork> SocialNetwork { get; set; }
      public List<SpeakerEvent> SpeakerEvent { get; set; }
    }
}
