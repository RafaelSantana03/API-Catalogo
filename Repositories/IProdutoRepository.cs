using APICatalogo.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APICatalogo.Repositories;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutosPorCategoria(int id);
}
