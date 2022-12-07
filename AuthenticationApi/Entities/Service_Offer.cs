using System.ComponentModel.DataAnnotations;

namespace AuthenticationApi.Entities
{
    public class Service_Offer
    {
        public int offerid { get; set; } 
        public Offer? offer { get; set; }
        public int serviceid { get; set; }
        public Service? service { get; set; }
        [Required]
        public int quantity { get; set; }
        public float discount { get; set; }
    }
}
