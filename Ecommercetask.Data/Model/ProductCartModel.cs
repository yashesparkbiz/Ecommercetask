
namespace Ecommercetask.Data.Model
{
    public class ProductCartModel
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int User_Id { get; set; }
        public bool Is_Active { get; set; }
    }
}
