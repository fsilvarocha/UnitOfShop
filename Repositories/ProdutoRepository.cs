using UnitOfShop.Data;
using UnitOfShop.Models;

namespace UnitOfShop.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public void Save(Produto produto)
        {
            _context.Add(produto);
            //implementado o savechanges no UnitOfWork
            // _context.SaveChanges();
        }
    }
}