using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommercetask.Data.Data
{
    public class Product_category
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(255)")]
        public string Name { get; set; } = string.Empty;

        [Column("is_active", TypeName = "bit")]
        public bool Is_Active { get; set; } = true;

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; } = DateTime.Now;

        public virtual ICollection<Product_subcategory> Product_subcategory { get; set; } 
    }
}