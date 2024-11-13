using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnergyTech_NET.Models;

[Table("TB_APP_TRANSACAO")]
public partial class TbAppTransacao
{
    [Key]
    [Column("TRANSACAO_ID", TypeName = "NUMBER")]
    public decimal TransacaoId { get; set; }

    [Column("TIPO_TRANSACAO")]
    [StringLength(20)]
    [Unicode(false)]
    public string TipoTransacao { get; set; } = null!;

    [Column("QUANTIDADE", TypeName = "NUMBER")]
    public decimal Quantidade { get; set; }

    [Column("VALOR_TOTAL", TypeName = "NUMBER(10,2)")]
    public decimal? ValorTotal { get; set; }

    [Column("DATA_TRANSACAO", TypeName = "DATE")]
    public DateTime? DataTransacao { get; set; }

    [Column("CLIENTE_ID", TypeName = "NUMBER")]
    public decimal? ClienteId { get; set; }

    [Column("ENERGIA_ID", TypeName = "NUMBER")]
    public decimal? EnergiaId { get; set; }

    [Column("BLOCKCHAIN_HASH")]
    [StringLength(255)]
    [Unicode(false)]
    public string? BlockchainHash { get; set; }

    [Column("STATUS_BLOCKCHAIN")]
    [StringLength(20)]
    [Unicode(false)]
    public string? StatusBlockchain { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("TbAppTransacaos")]
    public virtual TbAppCliente? Cliente { get; set; }

    [ForeignKey("EnergiaId")]
    [InverseProperty("TbAppTransacaos")]
    public virtual TbAppEnergia? Energia { get; set; }
}
