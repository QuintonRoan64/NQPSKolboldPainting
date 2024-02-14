using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

public partial class Paint
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(64)]
    public string? PaintName { get; set; }

    [Column("CompanyID")]
    public int? CompanyId { get; set; }

    [Column("PaintTypeID")]
    public int? PaintTypeId { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Paints")]
    public virtual Company? Company { get; set; }

    [ForeignKey("PaintTypeId")]
    [InverseProperty("Paints")]
    public virtual PaintType? PaintType { get; set; }
}
