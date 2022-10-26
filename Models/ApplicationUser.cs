using Microsoft.AspNetCore.Identity;

namespace DocumentProject.Models;

public class ApplicationUser : IdentityUser
{
    public string Avatar { get; set; }
}