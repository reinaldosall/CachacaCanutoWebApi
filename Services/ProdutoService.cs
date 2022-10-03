using CachacaCanutoWebApi.Context;
using CachacaCanutoWebApi.Controllers.Query;
using CachacaCanutoWebApi.Models;
using CachacaCanutoWebApi.Models.Dto;

namespace CachacaCanutoWebApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly ApplicationContext _context;

    public ProdutoService(ApplicationContext context)
    {
        _context = context;
    }

    public Produto? GetProduto(string id)
    {
        return _context.Produtos.SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Produto> GetProdutos(ProdutoQuery query)
    {
        return _context.Produtos
            .Where(p => (query.Nome == null || p.Nome.Trim().ToLower().Contains(query.Nome.Trim().ToLower()))
            && (!query.TeorAlcoolicoInicio.HasValue || double.Parse(p.TeorAlcoolico) >= query.TeorAlcoolicoInicio.Value)
            && (!query.TeorAlcoolicoFim.HasValue || double.Parse(p.TeorAlcoolico) <= query.TeorAlcoolicoFim.Value));
    }

    public IEnumerable<VendaProdutoDto> GetTotalVendas()
    {
        return _context.Produtos
            .Select(produto => new VendaProdutoDto()
            {
                IdProduto = produto.Id,
                NomeProduto = produto.Nome,
                QuantidadeVenda = _context.Vendas.Where(venda => venda.Itens.Any(item => item.Id == produto.Id)).Count(),
                QuantidadeTotalVendida = _context.Vendas.Where(venda => venda.Itens.Any(item => item.Id == produto.Id))
                    .SelectMany(venda => venda.Itens)
                    .Where(item => item.Id == produto.Id)
                    .Sum(item => item.Quantidade)
            });
    }
}
