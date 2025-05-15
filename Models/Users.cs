
using Microsoft.AspNetCore.Identity;

namespace abronalPortal.Models
{
    public class Users : IdentityUser
    {
        public string Fullname { get; set;}
        public string? ProfilePicturePath { get; set;}
    }
}