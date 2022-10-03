using CachacaCanutoWebApi.Controllers.Query;
using CachacaCanutoWebApi.Models;
using CachacaCanutoWebApi.Models.Dto;

namespace CachacaCanutoWebApi.Services;

public interface IClienteService
{
    IEnumerable<Cliente> GetClientes(ClienteQuery query);
    Cliente? GetCliente(string id);
    IEnumerable<TotalVendaClienteDto> GetTotalVendas();
    IEnumerable<ProdutoMaisCompradoClienteDto> GetProdutosMaisComprados(int quantidadeProdutos);
    IEnumerable<VendaClienteDto> GetVendasPorPeriodo(DateTime dataInicio, DateTime dataFim);
}
