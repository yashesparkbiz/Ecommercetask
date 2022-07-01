using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommercetask.Data.Data
{
    public class Order_Details
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Display(Name = "Product")]
        [Column("product_id", TypeName = "int")]
        public virtual int Product_Id { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; } 

        [Column("quantity", TypeName = "int")]
        public int Quantity { get; set; }

        [Display(Name = "Order")]
        [Column("order_id", TypeName = "int")]
        public virtual int Order_Id { get; set; }

        [ForeignKey("Order_Id")]
        public virtual Order Order { get; set; } 

        [Column("status", TypeName = "varchar(50)")]
        public string Status { get; set; } = string.Empty;

        [Display(Name = "Discount")]
        [Column("discount_id", TypeName = "int")]
        public virtual int Discount_Id { get; set; } 

        [ForeignKey("Discount_Id")]
        public virtual Discount Discount { get; set; } 

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; } = DateTime.Now;

    }
}