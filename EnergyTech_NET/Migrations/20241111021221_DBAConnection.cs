using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyTech_NET.Migrations
{
    /// <inheritdoc />
    public partial class DBAConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM99085");

            migrationBuilder.CreateSequence(
                name: "TB_APP_CLIENTES_SEQ",
                schema: "RM99085");

            migrationBuilder.CreateSequence(
                name: "TB_APP_ENERGIA_SEQ",
                schema: "RM99085");

            migrationBuilder.CreateSequence(
                name: "TB_APP_ESTOQUEENERGIA_SEQ",
                schema: "RM99085");

            migrationBuilder.CreateSequence(
                name: "TB_APP_FORNECEDORES_SEQ",
                schema: "RM99085");

            migrationBuilder.CreateSequence(
                name: "TB_APP_TRANSACAO_SEQ",
                schema: "RM99085");

            migrationBuilder.CreateSequence(
                name: "TB_AUDIT_LOG_SEQ",
                schema: "RM99085");

            migrationBuilder.CreateTable(
                name: "TB_APP_CLIENTES",
                schema: "RM99085",
                columns: table => new
                {
                    CLIENTE_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false),
                    SENHA_HASH = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    TELEFONE = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: true),
                    ENDERECO = table.Column<string>(type: "VARCHAR2(200)", unicode: false, maxLength: 200, nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "SYSDATE\n")
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C004025186", x => x.CLIENTE_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_APP_FORNECEDORES",
                schema: "RM99085",
                columns: table => new
                {
                    FORNECEDOR_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false),
                    SENHA_HASH = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    TELEFONE = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: true),
                    ENDERECO = table.Column<string>(type: "VARCHAR2(200)", unicode: false, maxLength: 200, nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "SYSDATE\n")
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C004025181", x => x.FORNECEDOR_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_AUDIT_LOG",
                schema: "RM99085",
                columns: table => new
                {
                    AUDIT_ID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    TABLE_NAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    ACTION_TYPE = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: false),
                    RECORD_ID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    ACTION_DATE = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "SYSDATE"),
                    USER_NAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "USER -- Nome do usuÃ¡rio que realizou a aÃ§Ã£o\n")
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C004025205", x => x.AUDIT_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_APP_ENERGIA",
                schema: "RM99085",
                columns: table => new
                {
                    ENERGIA_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TIPO_ENERGIA = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    QUANTIDADE_DISPONIVEL = table.Column<decimal>(type: "NUMBER", nullable: false),
                    PRECO_UNITARIO = table.Column<decimal>(type: "NUMBER(10,2)", nullable: true),
                    DATA_GERACAO = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "SYSDATE"),
                    FORNECEDOR_ID = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C004025190", x => x.ENERGIA_ID);
                    table.ForeignKey(
                        name: "SYS_C004025191",
                        column: x => x.FORNECEDOR_ID,
                        principalSchema: "RM99085",
                        principalTable: "TB_APP_FORNECEDORES",
                        principalColumn: "FORNECEDOR_ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_APP_ESTOQUEENERGIA",
                schema: "RM99085",
                columns: table => new
                {
                    ESTOQUE_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ENERGIA_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    DISPOSITIVO_ID = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false),
                    QUANTIDADE_ARMAZENADA = table.Column<decimal>(type: "NUMBER", nullable: false),
                    DATA_ATUALIZACAO = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "SYSDATE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C004025194", x => x.ESTOQUE_ID);
                    table.ForeignKey(
                        name: "SYS_C004025196",
                        column: x => x.ENERGIA_ID,
                        principalSchema: "RM99085",
                        principalTable: "TB_APP_ENERGIA",
                        principalColumn: "ENERGIA_ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_APP_TRANSACAO",
                schema: "RM99085",
                columns: table => new
                {
                    TRANSACAO_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TIPO_TRANSACAO = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: false),
                    QUANTIDADE = table.Column<decimal>(type: "NUMBER", nullable: false),
                    VALOR_TOTAL = table.Column<decimal>(type: "NUMBER(10,2)", nullable: true),
                    DATA_TRANSACAO = table.Column<DateTime>(type: "DATE", nullable: true, defaultValueSql: "SYSDATE"),
                    CLIENTE_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    ENERGIA_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    BLOCKCHAIN_HASH = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true),
                    STATUS_BLOCKCHAIN = table.Column<string>(type: "VARCHAR2(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "'Pendente'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C004025199", x => x.TRANSACAO_ID);
                    table.ForeignKey(
                        name: "SYS_C004025200",
                        column: x => x.CLIENTE_ID,
                        principalSchema: "RM99085",
                        principalTable: "TB_APP_CLIENTES",
                        principalColumn: "CLIENTE_ID");
                    table.ForeignKey(
                        name: "SYS_C004025201",
                        column: x => x.ENERGIA_ID,
                        principalSchema: "RM99085",
                        principalTable: "TB_APP_ENERGIA",
                        principalColumn: "ENERGIA_ID");
                });

            migrationBuilder.CreateIndex(
                name: "SYS_C004025187",
                schema: "RM99085",
                table: "TB_APP_CLIENTES",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_APP_ENERGIA_FORNECEDOR_ID",
                schema: "RM99085",
                table: "TB_APP_ENERGIA",
                column: "FORNECEDOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_APP_ESTOQUEENERGIA_ENERGIA_ID",
                schema: "RM99085",
                table: "TB_APP_ESTOQUEENERGIA",
                column: "ENERGIA_ID");

            migrationBuilder.CreateIndex(
                name: "SYS_C004025195",
                schema: "RM99085",
                table: "TB_APP_ESTOQUEENERGIA",
                column: "DISPOSITIVO_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SYS_C004025182",
                schema: "RM99085",
                table: "TB_APP_FORNECEDORES",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_APP_TRANSACAO_CLIENTE_ID",
                schema: "RM99085",
                table: "TB_APP_TRANSACAO",
                column: "CLIENTE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_APP_TRANSACAO_ENERGIA_ID",
                schema: "RM99085",
                table: "TB_APP_TRANSACAO",
                column: "ENERGIA_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_APP_ESTOQUEENERGIA",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_APP_TRANSACAO",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_AUDIT_LOG",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_APP_CLIENTES",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_APP_ENERGIA",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_APP_FORNECEDORES",
                schema: "RM99085");

            migrationBuilder.DropSequence(
                name: "TB_APP_CLIENTES_SEQ",
                schema: "RM99085");

            migrationBuilder.DropSequence(
                name: "TB_APP_ENERGIA_SEQ",
                schema: "RM99085");

            migrationBuilder.DropSequence(
                name: "TB_APP_ESTOQUEENERGIA_SEQ",
                schema: "RM99085");

            migrationBuilder.DropSequence(
                name: "TB_APP_FORNECEDORES_SEQ",
                schema: "RM99085");

            migrationBuilder.DropSequence(
                name: "TB_APP_TRANSACAO_SEQ",
                schema: "RM99085");

            migrationBuilder.DropSequence(
                name: "TB_AUDIT_LOG_SEQ",
                schema: "RM99085");
        }
    }
}
