using AuthedContoso.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder
    .Services
    .AddIdentityCore<ApplicationUser>()
    .AddUserManager<UserManager<ApplicationUser>>()
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    ;

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer("Server=localhost;Database=AuthedContosoShalvin;User Id=sa;Password=12qw!@QWAS;Encrypt=False"));

builder
    .Services
    .AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies(x =>
    { 
       
    })
    ;
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
