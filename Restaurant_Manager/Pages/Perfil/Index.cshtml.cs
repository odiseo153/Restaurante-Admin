using Application.Entities.Generics.Command;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;



namespace Restaurant_Manager.Pages.Perfil
{
    public class IndexModel(IMediator mediator) : PageModel
    {
        [BindProperty]
        public Restaurants Restaurant { get; set; }
        
        [BindProperty]
        public IFormFile FileUpload { get; set; }


        public void OnGet()
        {
        }

        private byte[] ProcesarImagen(IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imagen.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }

            return null; // Devolvemos null si no hay imagen
        }

        public async Task<IActionResult> OnPostSubmit()
        {
            try
            {
                
                 if (FileUpload != null)
                 {
                     Restaurant.Imagen = "data:image/png;base64," + Convert.ToBase64String(ProcesarImagen(FileUpload));
                 }
                else
                {
                    Restaurant.Imagen = HttpContext.Session.GetString("Imagen");
                }

                 
                // Verifica que el ID del restaurante está en la sesión
                var restauranteIdString = HttpContext.Session.GetString("Id");
                
                if (string.IsNullOrEmpty(restauranteIdString))
                {
                    return Page();
                }

                Restaurant.Id = Guid.Parse(restauranteIdString);

                // Enviar el comando al mediador
                var respuesta = await mediator.Send(new UpdateEntityCommand<Restaurants>(Restaurant));

                // Verifica la respuesta del mediador
                if (respuesta != null)
                {
                    ViewData["Success"] = "Datos actualizados correctamente.";
                    HttpContext.Session.SetString("Email", respuesta.Correo);
                    HttpContext.Session.SetString("Nombre", respuesta.Nombre);
                    HttpContext.Session.SetString("Imagen", respuesta.Imagen);
                    HttpContext.Session.SetString("Telefono", respuesta.NumeroTelefono ?? "");
                }
                else
                {
                    ViewData["Error"] = "Hubo un error al actualizar ";
                }
            }
            catch (Exception ex)
            {
                // Registro de excepción para más detalles
                Console.WriteLine($"Error: {ex.Message}");
                ViewData["Error"] = "Hubo un error actualizando el plato.";
            }

            return Page();
        }
    }
}
