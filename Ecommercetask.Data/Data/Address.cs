using Ecommercetask.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommercetask.Data.Data
{
    public class Address
    {
        [Key]
        [Column("id",TypeName = "int")]
        public int Id { get; set; }

        [Column("house", TypeName = "varchar(100)")]
        public string House { get; set; } = string.Empty;   

        [Column("street", TypeName = "varchar(100)")]
        public string Street { get; set; } = string.Empty ;

        [Column("city", TypeName = "varchar(100)")]
        public string City { get; set; } = string.Empty;

        [Column("country", TypeName = "varchar(100)")]
        public string Country { get; set; } = string.Empty;

        [Column("pincode", TypeName = "varchar(20)")]
        public string Pincode { get; set; } = string.Empty;

        [Column("address_type", TypeName = "varchar(20)")]
        public string Address_Type { get; set; } = string.Empty;

        [Display(Name = "UserModel")]
        [Column("user_id", TypeName = "int")]
        public virtual int? User_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual UserModel User { get; set; }

        [Display(Name = "Order_Details")]
        [Column("order_details_id", TypeName = "int")]
        public virtual int? Order_Details_Id { get; set; }

        [ForeignKey("Order_Details_Id")]
        public virtual Order_Details Order_Details { get; set; }
    }
}
