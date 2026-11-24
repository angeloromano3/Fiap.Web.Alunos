namespace Fiap.Web.Alunos.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }

        // produto pertence a um fornecedor
        public int FornecedorId { get; set; }
        public FornecedorModel? Fornecedor { get; set; }

        // ligação com os pedidos (muitos-para-muitos)
        public List<PedidoProdutoModel>? PedidoProdutos { get; set; }
    }
}