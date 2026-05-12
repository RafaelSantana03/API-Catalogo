using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APICatalogo.Repositories;

public class Repository<T> : IRepository<T> where T : class // garantindo que T seja uma classe, ou seja, um tipo de referência, para que o Entity Framework possa trabalhar com ela
{
    protected readonly AppDbContext _context; // o contexto é protegido para que as classes derivadas possam acessá-lo, mas não seja exposto publicamente, garantindo o encapsulamento e a segurança dos dados

    public Repository(AppDbContext context) // o construtor recebe o contexto do banco de dados como parâmetro, permitindo a injeção de dependência e facilitando os testes unitários, além de promover a reutilização do código
    {
        _context = context;
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().AsNoTracking().ToList(); // usando metodo set para retornar uma tabela no banco de dados correspondente ao tipo T, e o AsNoTracking para melhorar a performance. 
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().FirstOrDefault(predicate); // usando predicate para aceitar como argumento uma expressão lambda que define a condição de busca, permitindo maior flexibilidade na consulta
    }

    public T Create(T entity) // o método Create recebe uma entidade do tipo T como parametro (pode ser a entidade de Produtos ou Categorias)
    {
        _context.Set<T>().Add(entity); 
        //_context.SaveChanges();
        return entity;
    }

    public T Update(T entity) 
    {
        _context.Set<T>().Update(entity); // usando o método Update para atualizar a entidade no banco de dados, e o SaveChanges para salvar as alterações no banco de dados, garantindo que a operação seja persistida
        //_context.SaveChanges();
        return entity;
    }

    public T Delete(T entity)
    {
        _context.Set<T>().Remove(entity);  // usando o método Remove para remover a entidade do banco de dados, e o SaveChanges para salvar as alterações no banco de dados, garantindo que a operação seja persistida
        //_context.SaveChanges();
        return entity;
    }
}