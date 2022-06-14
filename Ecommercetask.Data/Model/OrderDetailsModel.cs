namespace Ecommercetask.Data.Model
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public int Order_Id { get; set; }
        public string Status { get; set; }
        public int Discount_Id { get; set; }
    }
}
