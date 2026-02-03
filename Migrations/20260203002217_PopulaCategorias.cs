using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) values ('Bebidas', 'bebidas.png')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) values ('Lanches', 'lanches.png')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) values ('Sobremesas', 'sobremesas.png')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
        }
    }
}
