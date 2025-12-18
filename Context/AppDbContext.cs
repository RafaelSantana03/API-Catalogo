using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

/// <summary>
/// Classe responsável pelo acesso ao banco de dados.
/// Representa a sessão de comunicação entre a aplicação e o banco.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Construtor que recebe as opções de configuração do DbContext
    /// (string de conexão, provider, etc.)
    /// </summary>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Representa a tabela "Categorias" no banco de dados.
    /// A classe Categoria é uma entidade mapeada pelo Entity Framework.
    /// </summary>
    public DbSet<Categoria>? Categorias { get; set; }

    /// <summary>
    /// Representa a tabela "Produtos" no banco de dados.
    /// A classe Produto é uma entidade mapeada pelo Entity Framework.
    /// </summary>
    public DbSet<Produto>? Produtos { get; set; }
}
