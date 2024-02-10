using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

[Keyless]
public partial class Tutorial
{
    [Column("KolboldUserID")]
    public int? KolboldUserId { get; set; }

    [StringLength(500)]
    public string? VideoUrl { get; set; }

    [ForeignKey("KolboldUserId")]
    public virtual KolboldUser? KolboldUser { get; set; }
}
