using CachacaCanutoWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CachacaCanutoWebApi.Context;

public class ApplicationContext : DbContext
{
    private static readonly string _baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");

    public IEnumerable<Venda> Vendas { get; set; }
    public IEnumerable<Cliente> Clientes { get; set; }
    public IEnumerable<Produto> Produtos { get; set; }

    public ApplicationContext()
    {
        Vendas = DeserializarArquivoJson<Venda>("Vendas.json");
        Clientes = DeserializarArquivoJson<Cliente>("Clientes.json");
        Produtos = DeserializarArquivoJson<Produto>("Catalogo.json");
    }

    private static IEnumerable<T> DeserializarArquivoJson<T>(string nomeArquivo)
    {
        var filePath = Path.Combine(_baseDir, nomeArquivo);
        using StreamReader reader = new(filePath);
        var json = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
    }
}
