using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Restaurant_Manager.Pages
{
    public class IndexModel : PageModel
    {

        public IActionResult OnGet()
        {
            var existe = HttpContext.Session.GetString("Nombre");

            if(existe == null)
            {
              return Redirect("/Access");
            }

            return Page();

        }

    

    }
}




