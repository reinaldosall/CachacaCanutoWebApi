namespace CachacaCanutoWebApi.Models.Dto;

public class VendaProdutoDto
{
    public string IdProduto { get; set; }
    public string NomeProduto { get; set; }
    public int QuantidadeVenda { get; set; }
    public int QuantidadeTotalVendida { get; set; }
}
