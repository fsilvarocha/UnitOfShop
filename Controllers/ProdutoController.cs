using Microsoft.AspNetCore.Mvc;
using UnitOfShop.Models;

namespace UnitOfShop.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public Pedido Post([FromServices] IProdutoRepository produtoRepository,
                           [FromServices] IPedidoRepository pedidoRepository,
                           [FromServices] IUnitOfWork unitOfWork)
        {
            try
            {
                var produto = new Produto { Nome = "Fabricio Silva" };
                var pedido = new Pedido { Nome = "Pedido", Produto = produto };

                //caso dê erro ao salvar o pedido, o produto será salvo, mas sem pedido vinculado a um pedido!
                produtoRepository.Save(produto);
                pedidoRepository.Save(pedido);
                // com o UnitOfWork, irá salvar os 2 ao mesmo tempo, caso de erro em algum deles, é feito o rollback.
                unitOfWork.Commit();

                return pedido;
            }
            catch
            {
                unitOfWork.Rollback();
                return null;
            }
        }
    }
}