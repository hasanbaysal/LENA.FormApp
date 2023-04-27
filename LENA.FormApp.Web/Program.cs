using LENA.FormApp.Business.DependencyResolver.BuiltInIocContiner;
using LENA.FormApp.Business.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//.AddFluentValidation(); 


builder.Services.AddBusinessDependencies(opt =>
{
    opt.ConnectionString = builder.Configuration.GetConnectionString("SqlCon")!;
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "LenaAppCookie";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        opt.ExpireTimeSpan = TimeSpan.FromDays(20);
        opt.LoginPath = new PathString("/Home/SignIn");
        opt.LogoutPath = new PathString("/Home/LogOut");
        opt.AccessDeniedPath = new PathString("/Home/AccesDenied");

    });



var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
