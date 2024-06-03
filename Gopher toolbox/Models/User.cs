using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GopherToolboxNew.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
