﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using EnergyTech_NET.Data;

#nullable disable

namespace EnergyTech_NET.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241111021221_DBAConnection")]
    partial class DBAConnection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("RM99085")
                .UseCollation("USING_NLS_COMP")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("TB_APP_CLIENTES_SEQ");

            modelBuilder.HasSequence("TB_APP_ENERGIA_SEQ");

            modelBuilder.HasSequence("TB_APP_ESTOQUEENERGIA_SEQ");

            modelBuilder.HasSequence("TB_APP_FORNECEDORES_SEQ");

            modelBuilder.HasSequence("TB_APP_TRANSACAO_SEQ");

            modelBuilder.HasSequence("TB_AUDIT_LOG_SEQ");

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppCliente", b =>
                {
                    b.Property<decimal>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER")
                        .HasColumnName("CLIENTE_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("ClienteId"));

                    b.Property<DateTime?>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasColumnName("DATA_CADASTRO")
                        .HasDefaultValueSql("SYSDATE\n");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(100)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Endereco")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(200)")
                        .HasColumnName("ENDERECO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(100)")
                        .HasColumnName("NOME");

                    b.Property<string>("SenhaHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(255)")
                        .HasColumnName("SENHA_HASH");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(20)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("ClienteId")
                        .HasName("SYS_C004025186");

                    b.HasIndex(new[] { "Email" }, "SYS_C004025187")
                        .IsUnique();

                    b.ToTable("TB_APP_CLIENTES", "RM99085");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppEnergia", b =>
                {
                    b.Property<decimal>("EnergiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER")
                        .HasColumnName("ENERGIA_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("EnergiaId"));

                    b.Property<DateTime?>("DataGeracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasColumnName("DATA_GERACAO")
                        .HasDefaultValueSql("SYSDATE");

                    b.Property<decimal?>("FornecedorId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("FORNECEDOR_ID");

                    b.Property<decimal?>("PrecoUnitario")
                        .HasColumnType("NUMBER(10,2)")
                        .HasColumnName("PRECO_UNITARIO");

                    b.Property<decimal>("QuantidadeDisponivel")
                        .HasColumnType("NUMBER")
                        .HasColumnName("QUANTIDADE_DISPONIVEL");

                    b.Property<string>("TipoEnergia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(50)")
                        .HasColumnName("TIPO_ENERGIA");

                    b.HasKey("EnergiaId")
                        .HasName("SYS_C004025190");

                    b.HasIndex("FornecedorId");

                    b.ToTable("TB_APP_ENERGIA", "RM99085");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppEstoqueEnergia", b =>
                {
                    b.Property<decimal>("EstoqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER")
                        .HasColumnName("ESTOQUE_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("EstoqueId"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasColumnName("DATA_ATUALIZACAO")
                        .HasDefaultValueSql("SYSDATE");

                    b.Property<string>("DispositivoId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(100)")
                        .HasColumnName("DISPOSITIVO_ID");

                    b.Property<decimal?>("EnergiaId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("ENERGIA_ID");

                    b.Property<decimal>("QuantidadeArmazenada")
                        .HasColumnType("NUMBER")
                        .HasColumnName("QUANTIDADE_ARMAZENADA");

                    b.HasKey("EstoqueId")
                        .HasName("SYS_C004025194");

                    b.HasIndex("EnergiaId");

                    b.HasIndex(new[] { "DispositivoId" }, "SYS_C004025195")
                        .IsUnique();

                    b.ToTable("TB_APP_ESTOQUEENERGIA", "RM99085");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppFornecedores", b =>
                {
                    b.Property<decimal>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER")
                        .HasColumnName("FORNECEDOR_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("FornecedorId"));

                    b.Property<DateTime?>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasColumnName("DATA_CADASTRO")
                        .HasDefaultValueSql("SYSDATE\n");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(100)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Endereco")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(200)")
                        .HasColumnName("ENDERECO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(100)")
                        .HasColumnName("NOME");

                    b.Property<string>("SenhaHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(255)")
                        .HasColumnName("SENHA_HASH");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(20)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("FornecedorId")
                        .HasName("SYS_C004025181");

                    b.HasIndex(new[] { "Email" }, "SYS_C004025182")
                        .IsUnique();

                    b.ToTable("TB_APP_FORNECEDORES", "RM99085");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppTransacao", b =>
                {
                    b.Property<decimal>("TransacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER")
                        .HasColumnName("TRANSACAO_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("TransacaoId"));

                    b.Property<string>("BlockchainHash")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(255)")
                        .HasColumnName("BLOCKCHAIN_HASH");

                    b.Property<decimal?>("ClienteId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("CLIENTE_ID");

                    b.Property<DateTime?>("DataTransacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasColumnName("DATA_TRANSACAO")
                        .HasDefaultValueSql("SYSDATE");

                    b.Property<decimal?>("EnergiaId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("ENERGIA_ID");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("NUMBER")
                        .HasColumnName("QUANTIDADE");

                    b.Property<string>("StatusBlockchain")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(20)")
                        .HasColumnName("STATUS_BLOCKCHAIN")
                        .HasDefaultValueSql("'Pendente'");

                    b.Property<string>("TipoTransacao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(20)")
                        .HasColumnName("TIPO_TRANSACAO");

                    b.Property<decimal?>("ValorTotal")
                        .HasColumnType("NUMBER(10,2)")
                        .HasColumnName("VALOR_TOTAL");

                    b.HasKey("TransacaoId")
                        .HasName("SYS_C004025199");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EnergiaId");

                    b.ToTable("TB_APP_TRANSACAO", "RM99085");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAuditLog", b =>
                {
                    b.Property<decimal>("AuditId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("AUDIT_ID");

                    b.Property<DateTime?>("ActionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasColumnName("ACTION_DATE")
                        .HasDefaultValueSql("SYSDATE");

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(10)")
                        .HasColumnName("ACTION_TYPE");

                    b.Property<decimal>("RecordId")
                        .HasColumnType("NUMBER")
                        .HasColumnName("RECORD_ID");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(50)")
                        .HasColumnName("TABLE_NAME");

                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("VARCHAR2(50)")
                        .HasColumnName("USER_NAME")
                        .HasDefaultValueSql("USER -- Nome do usuÃ¡rio que realizou a aÃ§Ã£o\n");

                    b.HasKey("AuditId")
                        .HasName("SYS_C004025205");

                    b.ToTable("TB_AUDIT_LOG", "RM99085");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppEnergia", b =>
                {
                    b.HasOne("EnergyTech_NET.Models.TbAppFornecedores", "Fornecedor")
                        .WithMany("TbAppEnergia")
                        .HasForeignKey("FornecedorId")
                        .HasConstraintName("SYS_C004025191");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppEstoqueEnergia", b =>
                {
                    b.HasOne("EnergyTech_NET.Models.TbAppEnergia", "Energia")
                        .WithMany("TbAppEstoqueenergia")
                        .HasForeignKey("EnergiaId")
                        .HasConstraintName("SYS_C004025196");

                    b.Navigation("Energia");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppTransacao", b =>
                {
                    b.HasOne("EnergyTech_NET.Models.TbAppCliente", "Cliente")
                        .WithMany("TbAppTransacaos")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("SYS_C004025200");

                    b.HasOne("EnergyTech_NET.Models.TbAppEnergia", "Energia")
                        .WithMany("TbAppTransacaos")
                        .HasForeignKey("EnergiaId")
                        .HasConstraintName("SYS_C004025201");

                    b.Navigation("Cliente");

                    b.Navigation("Energia");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppCliente", b =>
                {
                    b.Navigation("TbAppTransacaos");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppEnergia", b =>
                {
                    b.Navigation("TbAppEstoqueenergia");

                    b.Navigation("TbAppTransacaos");
                });

            modelBuilder.Entity("EnergyTech_NET.Models.TbAppFornecedores", b =>
                {
                    b.Navigation("TbAppEnergia");
                });
#pragma warning restore 612, 618
        }
    }
}
