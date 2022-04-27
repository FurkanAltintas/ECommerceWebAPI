using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;
using WebAPIWithCoreMvc.ApiServices;
using WebAPIWithCoreMvc.ApiServices.Interfaces;
using WebAPIWithCoreMvc.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddScoped<AuthTokenHandler>();

#region DI
builder.Services.AddScoped<IAuthApiService, AuthApiService>();
builder.Services.AddScoped<IUserApiService, UserApiService>();
#endregion

#region HttpClient
builder.Services.AddHttpClient<IAuthApiService, AuthApiService>(options =>
{
    options.BaseAddress = new Uri("https://localhost:7066/api/");
});

builder.Services.AddHttpClient<IUserApiService, UserApiService>(options =>
{
    options.BaseAddress = new Uri("https://localhost:7066/api/");
}).AddHttpMessageHandler<AuthTokenHandler>();
#endregion

#region Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/Admin/Auth/Login";
    options.ExpireTimeSpan = TimeSpan.FromDays(60); // 60 gün hayatta sürecek
    options.SlidingExpiration = true;
    options.Cookie.Name = "MvcCookie";
});
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseSession();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/assets"
});

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    // Admin/Home/Index
    endpoint.MapAreaControllerRoute(
        areaName: "Admin",
        name: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

    // Home/Index
    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=User}/{action=Index}/{id?}");
});

app.Run();
