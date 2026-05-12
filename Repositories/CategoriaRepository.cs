using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;
namespace APICatalogo.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext context) : base(context) // instacia a classe base Repository, passando o contexto do banco de dados como parâmetro, permitindo que a classe CategoriaRepository tenha acesso ao contexto e possa realizar operações de banco de dados usando os métodos definidos na classe base
    {
    }

}
