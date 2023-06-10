using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipToAddress_FirstName { get; set; }
        public string ShipToAddress_LastName { get; set; }
        public string ShipToAddress_Street { get; set; }
        public string ShipToAddress_City { get; set; }
        public string ShipToAddress_State { get; set; }
        public string ShipToAddress_ZipCode { get; set; }
		public string ShipToAddress_PhoneNumber { get; set; }
		public double TotalPrice { get; set; }

        public virtual List<OrderItems> OrderItems { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

    }
}
