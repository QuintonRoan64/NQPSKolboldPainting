using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

[Keyless]
public partial class Tutorial
{
    [Column("KoboldUserID")]
    public int? KoboldUserId { get; set; }

    [StringLength(500)]
    public string? VideoUrl { get; set; }

    [ForeignKey("KoboldUserId")]
    public virtual KoboldUser? KoboldUser { get; set; }
}
