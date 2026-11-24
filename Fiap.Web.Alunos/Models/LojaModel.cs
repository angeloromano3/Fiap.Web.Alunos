namespace Fiap.Web.Alunos.Models
{
    public class LojaModel
    {
        public int LojaId { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }

        // uma loja tem vários pedidos
        public List<PedidoModel>? Pedidos { get; set; }
    }
}