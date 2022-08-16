namespace UnitOfShop.Models
{
    public class Pedido : BaseModel
    {
        public string Nome { get; set; }
        public int PedidoId { get; set; }
        public Produto Produto { get; set; }
    }
}