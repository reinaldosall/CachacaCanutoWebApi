namespace CachacaCanutoWebApi.Models.Dto;

public class ProdutoMaisCompradoClienteDto
{
    public string IdCliente { get; set; }
    public string NomeCliente { get; set; }
    public IEnumerable<ItemProdutoMaisCompradoDto> ProdutosMaisComprados { get; set; }
}
