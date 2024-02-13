using KoboldPainting.Areas.Identity.Data;
using KoboldPainting.Data;
using KoboldPainting.Data.SeedingUsers;
using KoboldPainting.Models;
using KoboldPainting.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<KoboldPaintingDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<KoboldPaintingIdentityDbContext>();
builder.Services.AddControllersWithViews();

var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection");
builder.Services.AddDbContext<KoboldPaintingIdentityDbContext>(options => options
    .UseLazyLoadingProxies()    // Will use lazy loading, but not in LINQPad as it doesn't run Program.cs
    .UseSqlServer(identityConnectionString));

var app = builder.Build();

// ! Seed users
// ! turn off for azure
using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   try
   {
       //This only works locally not on azure
       string testUserPW = builder.Configuration["KoboldPainting:SeededUserPW"];
       SeedUsers.Initialize(services, SeedData.UserSeedData, testUserPW).Wait();
   }
   catch (Exception e)
   {
       Console.WriteLine(e);
       throw new Exception("Couldn't seed users.");
   }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
