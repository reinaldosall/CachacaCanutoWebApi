using CachacaCanutoWebApi.Controllers.Query;
using CachacaCanutoWebApi.Models;
using CachacaCanutoWebApi.Models.Dto;
using CachacaCanutoWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CachacaCanutoWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Cliente>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetClientes([FromQuery] ClienteQuery query)
    {
        var clientes = _clienteService.GetClientes(query);

        if (!clientes.Any())
            return NoContent();

        return Ok(clientes);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCliente([FromRoute] string id)
    {
        var cliente = _clienteService.GetCliente(id);

        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }    
    
    [HttpGet("totalVendas")]
    [ProducesResponseType(typeof(IEnumerable<TotalVendaClienteDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetTotalVendas()
    {
        var vendasCliente = _clienteService.GetTotalVendas();

        if (!vendasCliente.Any())
            return NoContent();

        return Ok(vendasCliente);
    }

    //[HttpGet("produtosMaisComprados")]
    //[ProducesResponseType(typeof(IEnumerable<ProdutoMaisCompradoClienteDto>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //public IActionResult GetProdutosMaisComprados([FromQuery] int quantidadeProdutos)
    //{
    //    var produtosMaisComprados = _clienteService.GetProdutosMaisComprados(quantidadeProdutos);

    //    if (!produtosMaisComprados.Any())
    //        return NoContent();

    //    return Ok(produtosMaisComprados);
    //}

    [HttpGet("vendas")]
    [ProducesResponseType(typeof(IEnumerable<Venda>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetVendasPorPeriodo([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
    {
        var vendasCliente = _clienteService.GetVendasPorPeriodo(dataInicio, dataFim);

        if (!vendasCliente.Any())
            return NoContent();

        return Ok(vendasCliente);
    }
}
