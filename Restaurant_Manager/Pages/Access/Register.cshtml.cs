using Application.Entities.Restaurantes.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant_Manager.Pages.Access
{
    public class RegisterModel(IMediator _mediator) : PageModel
    {
        [BindProperty]
        public CreateRestaurantCommand Restaurant { get; set; }

        [BindProperty]
        public IFormFile FileUpload { get; set; }


        public void OnGet()
        {
        }

        private bool IsValidImage(IFormFile file)
        {
            var permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return !string.IsNullOrEmpty(extension) && permittedExtensions.Contains(extension);
        }

        private byte[] ProcesarImagen(IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imagen.CopyTo(memoryStream);
                    var imageBytes = memoryStream.ToArray();
                    return imageBytes;
                }
            }

            return new byte[] { };
        }

        public async Task<IActionResult> OnPostSubmit()
        {


            if (FileUpload != null)
            {
                if (!IsValidImage(FileUpload))
                {
                    ModelState.AddModelError("fileUpload", "Invalid file type. Only JPEG, PNG, and GIF files are allowed.");
                    return Page();
                }

                Restaurant.Imagen = "data:image/png;base64," + Convert.ToBase64String(ProcesarImagen(FileUpload));
            }

            var response = await _mediator.Send(Restaurant);



            HttpContext.Session.SetString("Id", response.Id.ToString());
            HttpContext.Session.SetString("Email", response.Correo);
            HttpContext.Session.SetString("Nombre", response.Nombre);
            HttpContext.Session.SetString("Imagen", response.Imagen ?? "https://www.iconpacks.net/icons/2/free-user-icon-3296-thumb.png");

            return Redirect("/");
        } 
    }
}
