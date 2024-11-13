using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnergyTech_NET.Models;

[Table("TB_APP_ESTOQUEENERGIA")]
[Index("DispositivoId", Name = "SYS_C004025195", IsUnique = true)]
public partial class TbAppEstoqueEnergia
{
    [Key]
    [Column("ESTOQUE_ID", TypeName = "NUMBER")]
    public decimal EstoqueId { get; set; }

    [Column("ENERGIA_ID", TypeName = "NUMBER")]
    public decimal? EnergiaId { get; set; }

    [Column("DISPOSITIVO_ID")]
    [StringLength(100)]
    [Unicode(false)]
    public string DispositivoId { get; set; } = null!;

    [Column("QUANTIDADE_ARMAZENADA", TypeName = "NUMBER")]
    public decimal QuantidadeArmazenada { get; set; }

    [Column("DATA_ATUALIZACAO", TypeName = "DATE")]
    public DateTime? DataAtualizacao { get; set; }

    [ForeignKey("EnergiaId")]
    [InverseProperty("TbAppEstoqueenergia")]
    public virtual TbAppEnergia? Energia { get; set; }
}
