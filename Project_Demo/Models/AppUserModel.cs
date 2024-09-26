using Microsoft.AspNetCore.Identity;

namespace Project_Demo.Models
{
    public class AppUserModel : IdentityUser
    {
        public string Occupation {  get; set; }
    }
}
