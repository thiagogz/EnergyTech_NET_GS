using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EnergyTech_NET.Models;

[Table("TB_APP_ENERGIA")]
public partial class TbAppEnergia
{
    [Key]
    [Column("ENERGIA_ID", TypeName = "NUMBER")]
    public decimal EnergiaId { get; set; }

    [Column("TIPO_ENERGIA")]
    [StringLength(50)]
    [Unicode(false)]
    public string TipoEnergia { get; set; } = null!;

    [Column("QUANTIDADE_DISPONIVEL", TypeName = "NUMBER")]
    public decimal QuantidadeDisponivel { get; set; }

    [Column("PRECO_UNITARIO", TypeName = "NUMBER(10,2)")]
    public decimal? PrecoUnitario { get; set; }

    [Column("DATA_GERACAO", TypeName = "DATE")]
    public DateTime? DataGeracao { get; set; }

    [Column("FORNECEDOR_ID", TypeName = "NUMBER")]
    public decimal? FornecedorId { get; set; }
   
    [ForeignKey("FornecedorId")]
    [InverseProperty("TbAppEnergia")]
    public virtual TbAppFornecedores? Fornecedor { get; set; }

    [JsonIgnore]
    [InverseProperty("Energia")]
    public virtual ICollection<TbAppEstoqueEnergia> TbAppEstoqueenergia { get; set; } = new List<TbAppEstoqueEnergia>();

    [JsonIgnore]
    [InverseProperty("Energia")]
    public virtual ICollection<TbAppTransacao> TbAppTransacaos { get; set; } = new List<TbAppTransacao>();
}
