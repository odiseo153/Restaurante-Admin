using Application.Entities.Generics.Command;
using Application.Entities.Generics.Query;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Restaurant_Manager.Controllers
{
    public class ClienteController(IMediator mediator) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetClientes(string query = null)
        {
            Expression<Func<Cliente, bool>> filter = null;

            if (query != null)
            {
                query = query.ToLower();
                filter = x => x.Nombre.Contains(query) || x.Correo.Contains(query);
            }

            var clientes = await mediator.Send(new GetEntityQuery<Cliente>(filter));

            return new JsonResult(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Cliente Entidad)
        {
            var platos = await mediator.Send(new UpdateEntityCommand<Cliente>(Entidad));

            return new JsonResult(platos);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var platos = await mediator.Send(new DeleteEntityCommand<Cliente>(Id));

            return new JsonResult(platos);
        }

    }
}
