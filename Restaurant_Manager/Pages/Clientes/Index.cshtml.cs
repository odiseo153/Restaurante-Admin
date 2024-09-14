using Application.Entities.Generics.Command;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant_Manager.Pages.Clientes
{
    public class IndexModel(IMediator mediator) : PageModel
    {
        [BindProperty]
        public Cliente cliente { get; set; }

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostSubmit()
        {
            try
            {
                // Enviar el comando al mediador
                var respuesta = await mediator.Send(new CreateEntityCommand<Cliente>(cliente));

                // Verifica la respuesta del mediador
                if (respuesta != null)
                {
                    ViewData["Success"] = "Cliente agregado correctamente.";
                }
                else
                {
                    ViewData["Error"] = "Hubo un error al agregar el cliente.";
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
