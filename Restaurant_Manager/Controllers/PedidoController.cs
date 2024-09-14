using Application.Entities.Generics.Command;
using Application.Entities.Generics.Query;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Restaurant_Manager.Controllers
{
    public class PedidoController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetPedido(string query = null)
        {
            Expression<Func<Pedido, bool>> filter = null;

            if (query != null)
            {
              //  query = query.ToLower();
             //   filter = x => x. .Contains(query) || x.Correo.Contains(query);
            }

            var clientes = await mediator.Send(new GetEntityQuery<Pedido>(filter));

            return new JsonResult(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Pedido pedido)
        {
            var response = await mediator.Send(new CreateEntityCommand<Pedido>(pedido));

            return new JsonResult(response);
        }

    }
}







