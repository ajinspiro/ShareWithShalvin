using Microsoft.AspNetCore.Identity;

namespace AuthedContoso.Data;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}
