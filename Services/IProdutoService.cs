using CachacaCanutoWebApi.Controllers.Query;
using CachacaCanutoWebApi.Models;
using CachacaCanutoWebApi.Models.Dto;

namespace CachacaCanutoWebApi.Services;

public interface IProdutoService
{
    Produto? GetProduto(string id);
    IEnumerable<Produto> GetProdutos(ProdutoQuery query);
    IEnumerable<VendaProdutoDto> GetTotalVendas();
}
