namespace Ecommercetask.Data.Model
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string House { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Pincode { get; set; } = string.Empty;
        public string Address_Type { get; set; } = string.Empty;
        public int? User_Id { get; set; }
        public int? Order_Id { get; set; }
    }
}