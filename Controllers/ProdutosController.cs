using CachacaCanutoWebApi.Controllers.Query;
using CachacaCanutoWebApi.Models;
using CachacaCanutoWebApi.Models.Dto;
using CachacaCanutoWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CachacaCanutoWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetProdutos([FromQuery] ProdutoQuery query)
    {
        var produtos = _produtoService.GetProdutos(query);
        if (!produtos.Any())
            return NoContent();

        return Ok(produtos);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetProduto([FromRoute] string id)
    {
        var produto = _produtoService.GetProduto(id);
        if (produto == null)
            return NotFound();

        return Ok(produto);
    }

    [HttpGet("totalVendas")]
    [ProducesResponseType(typeof(IEnumerable<VendaProdutoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetTotalVendas()
    {
        var produtos = _produtoService.GetTotalVendas();
        if (!produtos.Any())
            return NoContent();

        return Ok(produtos);
    }
}
