using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;

namespace APICatalogo.Models;
public class Categoria
{

    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    public int CategoriaId { get; set; } // O entity framework vai indentificar essa chave como primaria
    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }

    public ICollection<Produto>? Produtos { get; set; }

}


