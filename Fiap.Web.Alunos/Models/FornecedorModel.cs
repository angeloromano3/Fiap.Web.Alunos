namespace Fiap.Web.Alunos.Models
{
    public class FornecedorModel
    {
        public int FornecedorId { get; set; }
        public string? Nome { get; set; }

        // um fornecedor tem vários produtos
        public List<ProdutoModel>? Produtos { get; set; }
    }
}