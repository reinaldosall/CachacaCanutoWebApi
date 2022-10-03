using CachacaCanutoWebApi.Context;
using CachacaCanutoWebApi.Controllers.Query;
using CachacaCanutoWebApi.Models;

namespace CachacaCanutoWebApi.Services;

public class VendaService : IVendaService
{
    private readonly ApplicationContext _context;

    public VendaService(ApplicationContext context)
    {
        _context = context;
    }

    public PagedList<Venda> GetVendas(PagingParametersQuery paginacao, VendaQuery query)
    {
        return PagedList<Venda>.ToPagedList(_context.Vendas
            .Where(venda => (!query.DataInicio.HasValue || venda.Data.Date >= query.DataInicio.Value.Date)
                && (!query.DataFim.HasValue || venda.Data.Date <= query.DataFim.Value.Date)
                && (query.NomeCliente == null || _context.Clientes
                                                            .Where(cliente => cliente.Nome.Trim().ToLower()
                                                            .Contains(query.NomeCliente))
                                                            .Select(cliente => cliente.Id).Contains(venda.IdCliente))
                && (query.NomeProduto == null || venda.Itens.Any(item => _context.Produtos
                                                                                    .Where(produto => produto.Nome.Trim().ToLower()
                                                                                    .Contains(query.NomeProduto.Trim().ToLower()))
                                                                                    .Select(produto => produto.Id)
                                                                                    .Contains(item.Id))))
            .OrderBy(v => v.Data)
            .AsQueryable(),
            paginacao.NumeroPagina,
            paginacao.ItensPorPagina);
    }
}
