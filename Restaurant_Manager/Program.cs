using Infraestructure.Context;
using Restaurant_Manager;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var startup = new Startup(builder.Configuration);


        builder.Services.AddRazorPages();

        startup.ConfigureServices(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
           
            
            app.UseHsts();
        }

        using (var service = app.Services.CreateScope())
        {
            var servicio = service.ServiceProvider;
            var db = servicio.GetRequiredService<ApplicationContext>();

            // Opcional: Crear o eliminar la base de datos
          //  db.Database.EnsureDeleted();
           // db.Database.EnsureCreated();
        }



        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSession();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

       
        app.MapRazorPages();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages(); // Esto es para Razor Pages
        });

        // app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
        app.Run();



  
    }
}