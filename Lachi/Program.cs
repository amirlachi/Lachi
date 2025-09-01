using Lachi;
using Lachi.Areas.Admin.Mappings;
using Lachi.Data.Contexts;
using Lachi.Data.Entities.UserStuff;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(option=> {
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<DataBaseContext>()
    .AddDefaultTokenProviders()
    //.AddRoles<Role>()
    .AddErrorDescriber<CustomIdentityError>();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, UserClaimsPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(option =>
{
    // cookie setting
    option.ExpireTimeSpan = TimeSpan.FromHours(12);

    option.LoginPath = "/Auth/Login";
    option.AccessDeniedPath = "/Auth/AccessDenied";
    option.SlidingExpiration = true;
});


builder.Services.AddAutoMapper(options =>
{
    options.AddMaps(typeof(UserMappingProfile).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
