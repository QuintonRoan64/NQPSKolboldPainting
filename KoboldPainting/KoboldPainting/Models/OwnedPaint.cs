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
    [Column("KolboldUserID")]
    public int? KolboldUserId { get; set; }

    [Column("PaintID")]
    public int? PaintId { get; set; }

    [ForeignKey("KolboldUserId")]
    public virtual KolboldUser? KolboldUser { get; set; }

    [ForeignKey("PaintId")]
    public virtual Paint? Paint { get; set; }
}
