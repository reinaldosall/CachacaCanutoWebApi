namespace CachacaCanutoWebApi.Models;

public class Venda
{
    public string Id { get; set; }
    public string IdCliente { get; set; }
    public DateTime Data { get; set; }
    public ICollection<ItemVenda> Itens { get; set; }
}
