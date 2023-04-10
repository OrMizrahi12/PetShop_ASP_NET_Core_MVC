using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetShopApiServise.Data;

public class AuthenticationContext : IdentityDbContext<IdentityUser>
{
    public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
    {
    }
}
