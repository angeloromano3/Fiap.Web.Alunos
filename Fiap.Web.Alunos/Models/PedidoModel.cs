namespace Fiap.Web.Alunos.Models
{
    public class PedidoModel
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }

        // pedido pertence a um cliente
        public int ClienteId { get; set; }
        public ClienteModel? Cliente { get; set; }

        // pedido pertence a uma loja
        public int LojaId { get; set; }
        public LojaModel? Loja { get; set; }

        // ligação com os produtos (muitos-para-muitos)
        public List<PedidoProdutoModel>? PedidoProdutos { get; set; }
    }
}