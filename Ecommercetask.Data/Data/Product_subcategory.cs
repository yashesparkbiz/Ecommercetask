using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommercetask.Data.Data
{
    public class Product_subcategory
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Product_category")]
        [Column("category_id", TypeName = "int")]
        public virtual int Category_Id { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Product_category Product_category { get; set; } 

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; } = DateTime.Now;

        public virtual ICollection<Product> Product { get; set; }
    }
}