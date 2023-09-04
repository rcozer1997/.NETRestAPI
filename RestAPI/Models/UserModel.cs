using Microsoft.AspNetCore.Identity;

namespace RestAPI.Models
{
    public class UserModel : IdentityUser
    {    
        public string Name { get; set; }
    }
}
