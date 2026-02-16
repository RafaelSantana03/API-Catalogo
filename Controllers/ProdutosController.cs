using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace APICatalogo.Controllers
{
    [Route("[controller]")] // / Produtos
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        // /api/produtos/primeiro
        [HttpGet("Primeiro")]
        [HttpGet("/primeiro")]
        [HttpGet("teste")]
        public ActionResult<Produto>GetPrimeiro()
        {

            var produtos = _context.Produtos.AsNoTracking().FirstOrDefault();
            if (produtos is null)
            {
                return NotFound();
            }
            return Ok(produtos);
        }
        // /api/produtos/
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.AsNoTracking().ToList();
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados...");
            }
            return Ok(produtos);
        }
        // /api/produtos/id
        [HttpGet("{id:int}/{nome = caderno}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id, string nome)
        {
            var parametro = nome;
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return produto;
        }
        // /api/produtos/
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
