namespace CachacaCanutoWebApi.Models.Dto;

public class ItemProdutoMaisCompradoDto
{
    public string Id { get; set; }
    public string NomeProduto { get; set; }
    public int Quantidade { get; set; }
    public double ValorTotal { get; set; }
}
