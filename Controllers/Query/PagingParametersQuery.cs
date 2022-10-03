namespace CachacaCanutoWebApi.Controllers.Query;

public class PagingParametersQuery
{
    private const int TamanhoMaximoPagina = 30;
    public int NumeroPagina { get; set; } = 1;

    private int _itensPorPagina = 10;
    public int ItensPorPagina {
        get => _itensPorPagina;
        set => _itensPorPagina = value > TamanhoMaximoPagina ? TamanhoMaximoPagina : value;
    }
}
