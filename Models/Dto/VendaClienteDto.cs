namespace CachacaCanutoWebApi.Models.Dto;

public class VendaClienteDto
{
    public string IdCliente { get; set; }
    public string NomeCliente { get; set; }
    public IEnumerable<Venda> Vendas { get; set; }
}
