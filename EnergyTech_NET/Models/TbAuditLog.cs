using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnergyTech_NET.Models;

[Table("TB_AUDIT_LOG")]
public partial class TbAuditLog
{
    [Key]
    [Column("AUDIT_ID", TypeName = "NUMBER")]
    public decimal AuditId { get; set; }

    [Column("TABLE_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string TableName { get; set; } = null!;

    [Column("ACTION_TYPE")]
    [StringLength(10)]
    [Unicode(false)]
    public string ActionType { get; set; } = null!;

    [Column("RECORD_ID", TypeName = "NUMBER")]
    public decimal RecordId { get; set; }

    [Column("ACTION_DATE", TypeName = "DATE")]
    public DateTime? ActionDate { get; set; }

    [Column("USER_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UserName { get; set; }
}
