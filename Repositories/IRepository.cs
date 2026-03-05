using System.Linq.Expressions;

namespace APICatalogo.Repositories;

public interface IRepository<T> //Interface genérica para ser implementada por outras interfaces de repositórios específicos 
{
    // cuidado para não violar o princiopio ISP (Interface Segregation Principle) da SOLID, ou seja, não colocar métodos que não serão usados por todas as implementações
    IEnumerable<T> GetAll();
    T Get(Expression<Func<T, bool>> predicate);
    T Create (T entity);
    T Update (T entity);
    T Delete(T entity);
}
