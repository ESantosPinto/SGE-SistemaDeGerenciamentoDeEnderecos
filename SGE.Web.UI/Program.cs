using Microsoft.AspNetCore.Authentication.Cookies;
using SGE.Infra.IoC.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfraIoCWeb(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",  pattern: "{controller=Login}/{action=Index}");
//pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
