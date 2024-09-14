using System.Reflection;
using Infraestructure;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Restaurant_Manager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            }); ;

            //services.AddTransient<GlobalHandlerException>();
            
            services.AddApplicationContext(Configuration);
            services.AddApplicationServices();
           
            

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(120); // El tiempo que desees para que la sesión expire
                options.Cookie.HttpOnly = true; // Seguridad adicional para que las cookies solo sean accesibles a través de HTTP
                options.Cookie.IsEssential = true; // Necesario para GDPR
            });

            services.AddEndpointsApiExplorer();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Usar Secure en producción
                options.LoginPath = "/Account/Login"; // Ruta de inicio de sesión
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthorization();
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); });
        }

        
    }

}
