using System.ComponentModel.DataAnnotations;

namespace projectMVC.ViewModels
{
	public class ShippingAddressViewModel
	{
        public string ShipToAddress_FirstName { get; set; }
        public string ShipToAddress_LastName { get; set; }
        public string BuyerEmail { get; set; }
        public string ShipToAddress_Street { get; set; }
        public string ShipToAddress_City { get; set; }
        public string ShipToAddress_State { get; set; }
        public string ShipToAddress_ZipCode { get; set; }
        [Phone]
        public string ShipToAddress_PhoneNumber { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
