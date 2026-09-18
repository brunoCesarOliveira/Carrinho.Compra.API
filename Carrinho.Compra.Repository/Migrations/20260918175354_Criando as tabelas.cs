using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Carrinho.Compra.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Criandoastabelas : Migration
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
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
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
                    CupomId = table.Column<Guid>(type: "uuid", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrinhos_CupomEntity_CupomId",
                        column: x => x.CupomId,
                        principalTable: "CupomEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItensCarrinho",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CarrinhoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCarrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensCarrinho_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
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
                    { new Guid("49e16d11-29ef-4dc2-8252-70e1603fd2b6"), true, new Guid("1aeb24f1-5f02-41db-adfc-fb8e948ac9e3"), 10m },
                    { new Guid("d37f362c-f1f6-4c84-92f6-2ff84cc62b63"), true, new Guid("c7846571-6120-4543-9623-70c749b6f997"), 15m }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ativo", "DescricaoProduto", "ImageUrl", "PrecoLiquido", "QuantidadeEstoque" },
                values: new object[,]
                {
                    { new Guid("05fd5c1e-507c-4843-8956-369eb91e37e1"), false, "Monitor 24 Polegadas", "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf", 899.90m, 30 },
                    { new Guid("23d7000e-32a7-44d0-b58f-5aa021eff66d"), false, "Console Gamer", "https://images.unsplash.com/photo-1606813907291-d86efa9b94db", 3999.90m, 50 },
                    { new Guid("34d40ed5-a264-45c0-a8ec-825a2a08d9c7"), false, "Notebook Dell Inspiron", "https://images.unsplash.com/photo-1496181133206-80ce9b88a853", 3500.00m, 100 },
                    { new Guid("3d240408-514f-4801-a32e-05454b2edc85"), false, "Apple AirPods", "https://images.unsplash.com/photo-1600294037681-c80b4cb5b434", 999.90m, 150 },
                    { new Guid("497bc209-f13d-4488-b2ff-2e216a84def9"), false, "Smart TV 50 Polegadas", "https://images.unsplash.com/photo-1593359677879-a4bb92f829d1", 2499.90m, 255 },
                    { new Guid("52942dc7-cccf-4769-bc19-a3816909f7f1"), false, "Smartphone Samsung Galaxy", "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9", 1899.90m, 50 },
                    { new Guid("9d84926c-4fae-4b07-bb4f-27a5423dfaad"), false, "Teclado Mecânico", "https://images.unsplash.com/photo-1587829741301-dc798b83add3", 299.90m, 60 },
                    { new Guid("a50d352e-88bd-4ad3-9cb0-c6dbfbd1d981"), false, "Mouse Gamer", "https://images.unsplash.com/photo-1527814050087-3793815479db", 159.90m, 200 },
                    { new Guid("c5c5aefc-8a3e-450c-b7b4-028f20cbd1a9"), false, "Câmera Digital", "https://images.unsplash.com/photo-1516035069371-29a1b244cc32", 2199.90m, 30 },
                    { new Guid("fd9a47a1-882c-47d7-b181-c02252b30d0a"), false, "Headset Gamer", "https://images.unsplash.com/photo-1599669454699-248893623440", 349.90m, 60 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_CupomId",
                table: "Carrinhos",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinho_CarrinhoId",
                table: "ItensCarrinho",
                column: "CarrinhoId");

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
