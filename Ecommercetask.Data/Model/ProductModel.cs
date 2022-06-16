
namespace Ecommercetask.Data.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public int Product_Subcategory_Id { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; } = string.Empty;
        public bool Is_Active { get; set; } = true;
        public int User_Id { get; set; }
    }
}
