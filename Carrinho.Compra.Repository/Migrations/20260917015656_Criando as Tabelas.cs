using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Carrinho.Compra.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CriandoasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CupomEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoCupom = table.Column<Guid>(type: "uuid", nullable: false),
                    PercentualDesconto = table.Column<decimal>(type: "numeric", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CupomEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DescricaoProduto = table.Column<string>(type: "text", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "integer", nullable: false),
                    PrecoLiquido = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    CupomId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrinhos_CupomEntity_CupomId",
                        column: x => x.CupomId,
                        principalTable: "CupomEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItensCarrinho",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CarrinhoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCarrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensCarrinho_Carrinhos_Id",
                        column: x => x.Id,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensCarrinho_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CupomEntity",
                columns: new[] { "Id", "Ativo", "CodigoCupom", "PercentualDesconto" },
                values: new object[,]
                {
                    { new Guid("43a2a5bd-f379-4558-8ac9-f637973fc154"), true, new Guid("816b7d3b-c767-4451-af22-9deed1d6d846"), 15m },
                    { new Guid("4525535d-d7cb-4c69-9c2c-3c82d760171d"), true, new Guid("4838c500-9136-4a9c-bc68-f9e0f0f87e10"), 10m }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DescricaoProduto", "ImageUrl", "PrecoLiquido", "QuantidadeEstoque" },
                values: new object[,]
                {
                    { new Guid("14ab4cf0-21c9-454e-acd1-6ca20bae3bc3"), "Câmera Digital", "https://images.unsplash.com/photo-1516035069371-29a1b244cc32", 2199.90m, 30 },
                    { new Guid("3fc3aac5-9eff-4642-9bbb-75ff3e166efd"), "Smart TV 50 Polegadas", "https://images.unsplash.com/photo-1593359677879-a4bb92f829d1", 2499.90m, 255 },
                    { new Guid("62caf4bd-82e9-4a1a-9878-563fd52093a2"), "Notebook Dell Inspiron", "https://images.unsplash.com/photo-1496181133206-80ce9b88a853", 3500.00m, 100 },
                    { new Guid("68fd356c-dc8d-4ab0-a936-d329a16af941"), "Smartphone Samsung Galaxy", "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9", 1899.90m, 50 },
                    { new Guid("876993eb-7f0d-4928-95b1-e0803b88707a"), "Headset Gamer", "https://images.unsplash.com/photo-1599669454699-248893623440", 349.90m, 60 },
                    { new Guid("a0fd9874-2096-46d0-9ba4-23a386c21577"), "Console Gamer", "https://images.unsplash.com/photo-1606813907291-d86efa9b94db", 3999.90m, 50 },
                    { new Guid("a426a272-8ec4-4fbf-8a5a-91e1b9664ff8"), "Apple AirPods", "https://images.unsplash.com/photo-1600294037681-c80b4cb5b434", 999.90m, 150 },
                    { new Guid("c58b1bad-25f8-4a81-a62a-21887dec7228"), "Mouse Gamer", "https://images.unsplash.com/photo-1527814050087-3793815479db", 159.90m, 200 },
                    { new Guid("caaaa9ea-d3d6-4b4e-bc9b-6f8e212af08d"), "Monitor 24 Polegadas", "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf", 899.90m, 30 },
                    { new Guid("ddb6ea84-fc8f-4ad3-be2a-06578cb6758e"), "Teclado Mecânico", "https://images.unsplash.com/photo-1587829741301-dc798b83add3", 299.90m, 60 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_CupomId",
                table: "Carrinhos",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinho_ProdutoId",
                table: "ItensCarrinho",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensCarrinho");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "CupomEntity");
        }
    }
}
