using Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_Manager.Pages.Access
{
    public class Index1Model(ApplicationContext context) : PageModel
    {
        public string Imagen = "https://www.iconpacks.net/icons/2/free-user-icon-3296-thumb.png";
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Clave { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSubmit()
        {
           
            var usuario = await context.Restaurantes.FirstOrDefaultAsync(x => x.Correo == Email && x.clave == Clave);
            //var usuario = null;
            if (usuario == null)
            {
                HttpContext.Session.SetString("Error", "Ese Usuario No existe");

                return Page();
            }

            HttpContext.Session.SetString("Id", usuario.Id.ToString());
            HttpContext.Session.SetString("Email", usuario.Correo);
            HttpContext.Session.SetString("Nombre", usuario.Nombre);
            HttpContext.Session.SetString("Imagen", usuario.Imagen ?? Imagen);
            HttpContext.Session.SetString("Telefono", usuario.NumeroTelefono ?? "");          


            return Redirect("/");

        }

    }
}
