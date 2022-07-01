using Ecommercetask.Data.Data;
using Microsoft.AspNetCore.Identity;

namespace Ecommercetask.Data.Model
{
    public class UserModel : IdentityUser<int>
    {
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Product_cart> Product_cart { get; set; }
        public virtual ICollection<Product_wishlist> Product_wishlist { get; set; }
    }
}               