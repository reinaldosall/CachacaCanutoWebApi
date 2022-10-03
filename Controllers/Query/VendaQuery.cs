namespace CachacaCanutoWebApi.Controllers.Query;

public class VendaQuery
{
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string? NomeCliente { get; set; }
    public string? NomeProduto { get; set; }
}
