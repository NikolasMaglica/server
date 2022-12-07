namespace AuthenticationApi.Entities
{
    public class Vehicle
    {
        public int id { get; set; }
        public string manufacturer { get; set; } = String.Empty;
        public string model { get; set; } = String.Empty;
        public int productionyear { get; set; }
        public float kilometerstraveled { get; set; }
        public int vehicle_typeid { get; set; }

        public virtual Vehicle_Type? vehicle_type { get; set; }
        public int clientid { get; set; }

        public virtual Client? client { get; set; }
        public virtual ICollection<Offer>? Offers { get; set; }
        public ICollection<User_Vehicle>? user_vehicle { get; set; }


    }
}
