using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EnergyTech_NET.Models;

namespace EnergyTech_NET.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAppCliente> Clientes { get; set; }

    public virtual DbSet<TbAppEnergia> Energia { get; set; }

    public virtual DbSet<TbAppEstoqueEnergia> EstoqueEnergia { get; set; }

    public virtual DbSet<TbAppFornecedores> Fornecedores { get; set; }

    public virtual DbSet<TbAppTransacao> Transacoes { get; set; }

    public virtual DbSet<TbAuditLog> AuditLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=oracle.fiap.com.br:1521/orcl;User Id=RM99085;Password=170297;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("RM99085")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<TbAppCliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("SYS_C004025186");

            entity.Property(e => e.ClienteId).ValueGeneratedOnAdd();
            entity.Property(e => e.DataCadastro).HasDefaultValueSql("SYSDATE\n");
        });

        modelBuilder.Entity<TbAppEnergia>(entity =>
        {
            entity.HasKey(e => e.EnergiaId).HasName("SYS_C004025190");

            entity.Property(e => e.EnergiaId).ValueGeneratedOnAdd();
            entity.Property(e => e.DataGeracao).HasDefaultValueSql("SYSDATE");

            entity.HasOne(d => d.Fornecedor).WithMany(p => p.TbAppEnergia).HasConstraintName("SYS_C004025191");
        });

        modelBuilder.Entity<TbAppEstoqueEnergia>(entity =>
        {
            entity.HasKey(e => e.EstoqueId).HasName("SYS_C004025194");

            entity.Property(e => e.EstoqueId).ValueGeneratedOnAdd();
            entity.Property(e => e.DataAtualizacao).HasDefaultValueSql("SYSDATE");

            entity.HasOne(d => d.Energia).WithMany(p => p.TbAppEstoqueenergia).HasConstraintName("SYS_C004025196");
        });

        modelBuilder.Entity<TbAppFornecedores>(entity =>
        {
            entity.HasKey(e => e.FornecedorId).HasName("SYS_C004025181");

            entity.Property(e => e.FornecedorId).ValueGeneratedOnAdd();
            entity.Property(e => e.DataCadastro).HasDefaultValueSql("SYSDATE\n");
        });

        modelBuilder.Entity<TbAppTransacao>(entity =>
        {
            entity.HasKey(e => e.TransacaoId).HasName("SYS_C004025199");

            entity.Property(e => e.TransacaoId).ValueGeneratedOnAdd();
            entity.Property(e => e.DataTransacao).HasDefaultValueSql("SYSDATE");
            entity.Property(e => e.StatusBlockchain).HasDefaultValueSql("'Pendente'");

            entity.HasOne(d => d.Cliente).WithMany(p => p.TbAppTransacaos).HasConstraintName("SYS_C004025200");

            entity.HasOne(d => d.Energia).WithMany(p => p.TbAppTransacaos).HasConstraintName("SYS_C004025201");
        });

        modelBuilder.Entity<TbAuditLog>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("SYS_C004025205");

            entity.Property(e => e.ActionDate).HasDefaultValueSql("SYSDATE");
            entity.Property(e => e.UserName).HasDefaultValueSql("USER -- Nome do usuÃ¡rio que realizou a aÃ§Ã£o\n");
        });
        modelBuilder.HasSequence("TB_APP_CLIENTES_SEQ");
        modelBuilder.HasSequence("TB_APP_ENERGIA_SEQ");
        modelBuilder.HasSequence("TB_APP_ESTOQUEENERGIA_SEQ");
        modelBuilder.HasSequence("TB_APP_FORNECEDORES_SEQ");
        modelBuilder.HasSequence("TB_APP_TRANSACAO_SEQ");
        modelBuilder.HasSequence("TB_AUDIT_LOG_SEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
