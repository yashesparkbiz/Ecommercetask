using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommercetask.Data.Data
{
    public class Product
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("product_name", TypeName = "varchar(255)")]
        public string Product_Name { get; set; } = string.Empty;    

        [Column("description", TypeName = "varchar(255)")]
        public string Description { get; set; } = string.Empty;

        [Column("brand", TypeName = "varchar(100)")]
        public string Brand { get; set; } = string.Empty;

        [Column("price", TypeName = "decimal(10,3)")]
        public decimal Price { get; set; }

        [Display(Name = "Product_subcategory")]
        [Column("product_subcategory_id", TypeName = "int")]
        public virtual int Product_Subcategory_Id { get; set; }

        [ForeignKey("Product_Subcategory_Id")]
        public virtual Product_subcategory Product_subcategory { get; set; }

        [Column("quantity", TypeName = "int")]
        public int Quantity { get; set; }

        [Column("image", TypeName = "varchar(100)")]
        public string Image { get; set; } = string.Empty;

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; } = DateTime.Now;

        [Column("is_active", TypeName = "bit")]
        public bool Is_Active { get; set; } =true;

        public virtual ICollection<Discount> Discount { get; set; } 
    }
}
