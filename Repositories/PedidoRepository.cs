using UnitOfShop.Data;
using UnitOfShop.Models;

namespace UnitOfShop.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DataContext _context;

        public PedidoRepository(DataContext context)
        {
            _context = context;
        }

        public void Save(Pedido pedido)
        {
            _context.Add(pedido);
            //implementado o savechanges no UnitOfWork
            // _context.SaveChanges();
        }
    }
}