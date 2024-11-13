using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EnergyTech_NET.Models;

[Table("TB_APP_CLIENTES")]
[Index("Email", Name = "SYS_C004025187", IsUnique = true)]
public partial class TbAppCliente
{
    [Key]
    [Column("CLIENTE_ID", TypeName = "NUMBER")]
    public decimal ClienteId { get; set; }

    [Column("NOME")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("SENHA_HASH")]
    [StringLength(255)]
    [Unicode(false)]
    public string SenhaHash { get; set; } = null!;

    [Column("TELEFONE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Telefone { get; set; }

    [Column("ENDERECO")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Endereco { get; set; }

    [Column("DATA_CADASTRO", TypeName = "DATE")]
    public DateTime? DataCadastro { get; set; }

    [InverseProperty("Cliente")]
    [JsonIgnore]
    public virtual ICollection<TbAppTransacao> TbAppTransacaos { get; set; } = new List<TbAppTransacao>();
}
