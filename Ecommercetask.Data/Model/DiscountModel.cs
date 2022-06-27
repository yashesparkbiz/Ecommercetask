namespace Ecommercetask.Data.Model
{
    public class DiscountModel
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public string Type { get; set; } = String.Empty;
        public string Value { get; set; } = String.Empty;
        public bool Is_Active { get; set; } = true;
    }
}
