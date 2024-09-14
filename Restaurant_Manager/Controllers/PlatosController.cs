using Application.Entities.Generics.Query;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Application.Entities.Generics.Command;



namespace Restaurant_Manager.Controllers
{
    public class PlatosController(IMediator mediator) : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPlatos(string query = null)
        {
            try
            {
                // Inicializamos el filtro sin condiciones
                Expression<Func<Plato, bool>> filter = null;

                // Si se proporciona una consulta de texto o un tipo, establecemos el filtro
                if (!string.IsNullOrWhiteSpace(query))
                {
                    query = query?.ToLower();

                    // Verificamos si query puede ser un Guid válido para filtrar por Id (en caso de que query sea un Guid)
                    bool isGuidQuery = Guid.TryParse(query, out Guid parsedGuid);

                    // Filtramos según el valor de query (nombre, descripción o id) y/o tipo
                    filter = x =>
                        (string.IsNullOrWhiteSpace(query) ||
                            x.Nombre.ToLower().Contains(query) ||
                            (isGuidQuery && x.Tipo.Id == parsedGuid));
                }

                // Enviamos la consulta con el filtro aplicado
                var platos = await mediator.Send(new GetEntityQuery<Plato>(filter));

                // Retornamos el resultado en formato JSON
                return new JsonResult(platos);
            }
            catch (Exception ex)
            {
                // En caso de error, retornamos un mensaje de error genérico
                return StatusCode(500, new { error = "Ocurrió un error al obtener los platos.", details = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromForm]Plato Entidad)
        {
            var platos = await mediator.Send(new UpdateEntityCommand<Plato>(Entidad));

            return new JsonResult(platos);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var platos = await mediator.Send(new DeleteEntityCommand<Plato>(Id));

            return new JsonResult(platos);
        }



    }
}
