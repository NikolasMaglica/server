using System.ComponentModel.DataAnnotations;

namespace AuthenticationApi.Entities
{
    public class Service
    {
        [Required]

        public int id { get; set; }
        [Required]

        public string name { get; set; }=String.Empty;
        [Required]

        public float price { get; set; }
        public string description { get; set; }= String.Empty;
        public ICollection<Service_Offer>? service_offer { get; set; }

    }
}
