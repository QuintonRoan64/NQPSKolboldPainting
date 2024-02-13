using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

[Keyless]
[Table("OwnedPaint")]
public partial class OwnedPaint
{
    [Column("KoboldUserID")]
    public int? KoboldUserId { get; set; }

    [Column("PaintID")]
    public int? PaintId { get; set; }

    [ForeignKey("KoboldUserId")]
    public virtual KoboldUser? KoboldUser { get; set; }

    [ForeignKey("PaintId")]
    public virtual Paint? Paint { get; set; }
}
