
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationApi.Entities
{
    public class Offer
    {
        public int id { get; set; }
        public string price { get; set; } = String.Empty;

        public string userid { get; set; } = String.Empty;

        public virtual User? User { get; set; }
        public int clientid { get; set; } 

        public virtual Client? client { get; set; }
        public int vehicleid { get; set; }

        public virtual Vehicle? vehicle { get; set; }
        public ICollection<Service_Offer>? service_offer { get; set; }


    }
}