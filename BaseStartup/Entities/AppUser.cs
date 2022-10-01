using Microsoft.AspNetCore.Identity;

namespace BaseStartup.Entities;

public class AppUser : IdentityUser
{
    public string Avatar { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
}
