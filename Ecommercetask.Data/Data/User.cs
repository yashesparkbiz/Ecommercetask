

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommercetask.Data.Data
{
    public class User 
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("user_name", TypeName = "varchar(255)")]
        public string User_Name { get; set; } = string.Empty;

        [Column("email_id", TypeName = "varchar(255)")]
        public string Email_Id { get; set; } = string.Empty;

        [Column("phoneno", TypeName = "varchar(10)")]
        public string Phoneno { get; set; } = string.Empty ;

        [Column("age", TypeName = "int")]
        public int Age { get; set; }

        [Column("gender", TypeName = "varchar(10)")]
        public string Gender { get; set; } = string.Empty ;

        [Column("role", TypeName = "varchar(100)")]
        public string Role { get; set; } = string.Empty ;

        [Column("created_at", TypeName = "datetime")]
        public DateTime Created_At { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime Updated_At { get; set; } = DateTime.Now;

        //public virtual ICollection<Address>? Address { get; set; }
    }
}
