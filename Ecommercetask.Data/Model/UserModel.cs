using Ecommercetask.Data.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommercetask.Data.Model
{
    public class UserModel : IdentityUser<int>
    {
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;

        public virtual ICollection<Product> Product { get; set; }
    }
}