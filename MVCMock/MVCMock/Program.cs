using MVCMock.Models;

namespace MVCMock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //register the services to the IOC Container
            //Add Scoped -> services are created each time they are requested
            //Add Transient -> once instance is created per HTTP request and same instance is re-used within that scope
            //Add Singleton -> create once throughout the single application

            builder.Services.AddScoped<IStudentRepository, StudentMockRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            //middlewares
            //routing structure -> request-from-middle-ware -> parse-routing -> routes-found ? forward-to-appropriate-route : forward-to-next-middleware

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                //conventional based routing -> without query string or any parameters in the URL
                //attribute based routing -> with params or any query string in the URL

            app.Run();
        }
    }
}