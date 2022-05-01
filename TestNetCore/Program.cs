using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using TestNetCore.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string conn = builder.Configuration.GetConnectionString("DevConection");
builder.Services.AddDbContext<cUserContext>(
    op => op.UseSqlServer(conn)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
var provider = new FileExtensionContentTypeProvider();
provider.Mappings.Add(".glb", "text/xml");
app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.MapControllerRoute(
    name: "default",
//pattern: "{controller=cUsers}/{action=Index}/{id?}");
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
