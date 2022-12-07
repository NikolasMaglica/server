namespace AuthenticationApi.Entities
{
    public class Client
    {
        public int id { get; set; }
        public string firstlastname { get; set; } = String.Empty;
        public string email { get; set; } = String.Empty;
        public string Adress { get; set; } = String.Empty;
        public int phonenumber { get; set; }
        public virtual ICollection<Vehicle>? Vehicles { get; set; }
        public virtual ICollection<Offer>? Offers { get; set; }


    }
}
