using Application.Entities.Generics.Command;
using Application.Entities.Generics.Query;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant_Manager.Pages.Platos
{
    public class IndexModel(IMediator mediator) : PageModel
    {
        [BindProperty]
        public Plato plato { get; set; }

        [BindProperty]
        public string ImagenRemplazo { get; set; }

        [BindProperty]
        public IFormFile FileUpload { get; set; }

        public async void OnGet()
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
                // Procesar la imagen subida o la URL de reemplazo
                if (FileUpload != null)
                {
                    plato.Imagen = "data:image/png;base64," + Convert.ToBase64String(ProcesarImagen(FileUpload));
                }
                else if (!string.IsNullOrEmpty(ImagenRemplazo))
                {
                    plato.Imagen = ImagenRemplazo;
                }
                else
                {
                    // Imagen por defecto si no se sube archivo ni se proporciona una URL
                    plato.Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSgczM0FADbnbJ6CBlipbaFUlBf1t1qJkvA_PSV9mYZsfGaU2nDjEqNkBtjpIYGomsrgk&usqp=CAU";
                }

                // Verifica que el ID del restaurante está en la sesión
                var restauranteIdString = HttpContext.Session.GetString("Id");
                if (string.IsNullOrEmpty(restauranteIdString))
                {
                    ModelState.AddModelError(string.Empty, "Error: No se encontró el ID del restaurante.");
                    return Page();
                }

                plato.RestauranteId = Guid.Parse(restauranteIdString);

                // Enviar el comando al mediador
                var respuesta = await mediator.Send(new CreateEntityCommand<Plato>(plato));

                // Verifica la respuesta del mediador
                if (respuesta != null)
                {
                    ViewData["Success"] = "Plato agregado correctamente.";
                    plato = null;
                }
                else
                {
                    ViewData["Error"] = "Hubo un error al agregar el plato.";
                }
            }
            catch (Exception ex)
            {
                // Registro de excepción para más detalles
                Console.WriteLine($"Error: {ex.Message}");
                ViewData["Error"] = "Hubo un error agregando el plato.";
            }

            return Page();
        }
    }
}
