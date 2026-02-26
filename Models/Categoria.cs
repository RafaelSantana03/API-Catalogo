using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
namespace APICatalogo.Models;

[Table("categorias")]
public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    [Key]
    public int CategoriaId { get; set; } // O entity framework vai indentificar essa chave como primaria

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    [JsonIgnore]
    public ICollection<Produto>? Produtos { get; set; }

}


