using Application.Entities.Generics.Command;
using Application.Entities.Generics.Query;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Restaurant_Manager.Controllers
{
    public class TiposController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetTipos(string query=null)
        {
            Expression<Func<TiposPlato, bool>> filter = null;

            if (query != null)
            {
                filter = x => x.Nombre.ToLower().Contains(query.ToLower());
            }


            var tipos = await mediator.Send(new GetEntityQuery<TiposPlato>(filter));

            return new JsonResult(tipos);
        }


        [HttpPost]
        public async Task<IActionResult> Update(TiposPlato Entidad)
        {
            var platos = await mediator.Send(new UpdateEntityCommand<TiposPlato>(Entidad));

            return new JsonResult(platos);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var platos = await mediator.Send(new DeleteEntityCommand<TiposPlato>(Id));

            return new JsonResult(platos);
        }
    }
}
