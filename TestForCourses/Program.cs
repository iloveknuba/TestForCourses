using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestForCourses.Data;
using TestForCourses.Data.Interfaces;
using TestForCourses.Data.Mocks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CatalogDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<ICatalogs, MockCatalogs>();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Catalogs}/{action=CatalogsList}/{name?}",
        defaults: new {Controller = "Catalogs", action = "CatalogsList"}
    );
});


app.UseAuthorization();

app.MapRazorPages();

app.Run();
