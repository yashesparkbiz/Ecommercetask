using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommercetask.Data.Data
{
    public class Discount
    {
        [Key]
        [Column("id",TypeName = "int")]
        public int Id { get; set; }

        [Display(Name = "Product")]
        [Column("product_id",TypeName = "int")]
        public virtual int Product_Id { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; } 

        [Column("type", TypeName = "varchar(100)")]
        public string Type { get; set; } = String.Empty;

        [Column("value", TypeName = "varchar(100)")]
        public string Value { get; set; } = String.Empty;

        [Column("is_active", TypeName = "bit")]
        public bool Is_Active { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; } = DateTime.Now;
    }
}
