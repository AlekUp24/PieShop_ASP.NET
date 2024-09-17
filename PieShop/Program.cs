using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PieShop.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // make it MVC app
        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<ICategoryRepository, CategoryReporsitory>();
        builder.Services.AddScoped<IPieRepository, PieRepository>();

        builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp=> ShoppingCart.GetCart(sp));
        builder.Services.AddSession();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddDbContext<PieShopDbContext>(options =>
        {  
            options.UseSqlServer(builder.Configuration["ConnectionStrings:PieShopDbContextConnection"]);
        });

        var app = builder.Build();

        // to see static files
        app.UseStaticFiles();
        app.UseSession();

        // to see errors
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // to connect controllers with views
        // default pattern is "{controler}/{action}"
        app.MapDefaultControllerRoute(); 


        // add db iniitalize if no data in db is present
        DbInitializer.Seed(app);

        app.Run();
    }
}