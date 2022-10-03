using CachacaCanutoWebApi.Context;
using CachacaCanutoWebApi.Controllers.Query;
using CachacaCanutoWebApi.Models;
using CachacaCanutoWebApi.Models.Dto;

namespace CachacaCanutoWebApi.Services;

public class ClienteService : IClienteService
{
    private readonly ApplicationContext _context;

    public ClienteService(ApplicationContext context)
    {
        _context = context;
    }

    public Cliente? GetCliente(string id)
    {
        return _context.Clientes
            .SingleOrDefault(c => c.Id == id);
    }

    public IEnumerable<Cliente> GetClientes(ClienteQuery query)
    {
        return _context.Clientes
            .Where(c => (query.Nome == null || c.Nome.Trim().ToLower().Contains(query.Nome.Trim().ToLower()))
                && (!query.DataNascimentoInicio.HasValue || c.DataNascimento.Date >= query.DataNascimentoInicio.Value.Date)
                && (!query.DataNascimentoFim.HasValue || c.DataNascimento.Date <= query.DataNascimentoFim.Value.Date))
            .ToList();
    }

    public IEnumerable<ProdutoMaisCompradoClienteDto> GetProdutosMaisComprados(int quantidadeProdutos)
    {
        return _context.Clientes
            .Select(cliente => new ProdutoMaisCompradoClienteDto()
            {
                IdCliente = cliente.Id,
                NomeCliente = cliente.Nome,
                ProdutosMaisComprados = _context.Vendas
                                            .Where(venda => venda.IdCliente == cliente.Id)
                                            .SelectMany(venda => venda.Itens)
                                            .Select(item => new ItemProdutoMaisCompradoDto()
                                            {
                                                Id = item.Id,
                                                NomeProduto = _context.Produtos
                                                                .SingleOrDefault(produto => produto.Id == item.Id)
                                                                .Nome,
                                                
                                            })
                                            .Take(quantidadeProdutos)
            });
    }

    public IEnumerable<TotalVendaClienteDto> GetTotalVendas()
    {
        return _context.Clientes
            .Select(c => new TotalVendaClienteDto()
            {
                IdCliente = c.Id,
                NomeCliente = c.Nome,
                TotalVendas = _context.Vendas.Count(v => v.IdCliente == c.Id)
            });
    }

    public IEnumerable<VendaClienteDto> GetVendasPorPeriodo(DateTime dataInicio, DateTime dataFim)
    {
        return _context.Clientes
            .Select(cliente => new VendaClienteDto()
            {
                IdCliente = cliente.Id,
                NomeCliente = cliente.Nome,
                Vendas = _context.Vendas
                    .Where(venda => venda.IdCliente == cliente.Id 
                        && venda.Data.Date  >= dataInicio.Date  && venda.Data.Date <= dataFim)
            });
    }
}
