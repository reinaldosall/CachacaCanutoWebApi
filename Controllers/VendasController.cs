using CachacaCanutoWebApi.Controllers.Query;
using CachacaCanutoWebApi.Models;
using CachacaCanutoWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CachacaCanutoWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VendasController : ControllerBase
{
    private readonly IVendaService _vendaService;

    public VendasController(IVendaService vendaService)
    {
        _vendaService = vendaService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedList<Venda>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetVendas([FromQuery] PagingParametersQuery paginacao, [FromQuery] VendaQuery query)
    {
        var vendas = _vendaService.GetVendas(paginacao, query);

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(vendas.GetMetadata(), new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        }));

        if (!vendas.Any())
            return NoContent();

        return Ok(vendas);
    }
}
