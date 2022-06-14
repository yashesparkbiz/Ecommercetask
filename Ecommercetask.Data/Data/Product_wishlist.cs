
using Ecommercetask.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommercetask.Data.Data
{
    public class Product_wishlist
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Display(Name = "Product")]
        [Column("product_id", TypeName = "int")]
        public virtual int Product_Id { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }

        [Display(Name = "UserModel")]
        [Column("user_id", TypeName = "int")]
        public virtual int User_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual UserModel User { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; }
        
        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; }
    }
}
