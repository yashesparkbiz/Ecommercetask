namespace Ecommercetask.Data.Model
{
    public class OrdersModel
    {
        public int Id { get; set; }
        public decimal Total_Amount { get; set; }
        public decimal Total_Discount { get; set; }
        public virtual int User_Id { get; set; }
    }
}