using CachacaCanutoWebApi.Controllers.Query;
using CachacaCanutoWebApi.Models;

namespace CachacaCanutoWebApi.Services;

public interface IVendaService
{
    PagedList<Venda> GetVendas(PagingParametersQuery paginacao, VendaQuery query);
}
