using Application.Entities.Generics.Command;
using Application.Entities.Generics.Query;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Restaurant_Manager.Controllers
{
    public class RedesController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetRedes(string query = null)
        {
            Expression<Func<Social, bool>> filter = null;

            if (query != null)
            {
                filter = x => x.Nombre.ToLower().Contains(query.ToLower());
            }


            var tipos = await mediator.Send(new GetEntityQuery<Social>(filter));

            return new JsonResult(tipos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Social[] socialEntities)
        {
            if (socialEntities == null || socialEntities.Length == 0)
            {
                return BadRequest("No se han proporcionado entidades sociales.");
            }

            var updatedEntities = new List<Social>();

            try
            {
                foreach (var entity in socialEntities)
                {
                    // Cada entidad se actualiza secuencialmente
                    var updatedEntity = await mediator.Send(new CreateEntityCommand<Social>(entity));
                    updatedEntities.Add(updatedEntity);
                }

                // Devuelve las entidades actualizadas
                return new JsonResult(updatedEntities)
                {
                    StatusCode = 200 // Código HTTP 200 OK
                };
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error al procesar la solicitud: {ex.Message}");
            }
        }


    }
}







