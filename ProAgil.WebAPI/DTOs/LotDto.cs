namespace ProAgil.WebAPI.DTOs
{
    public class LotDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal price { get; set; }
        public string InitialDate { get; set; }
        public string FinalDate { get; set; }
        public int amount { get; set; }
    }
}