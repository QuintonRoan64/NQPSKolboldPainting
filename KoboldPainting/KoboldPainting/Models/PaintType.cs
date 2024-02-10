using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

[Table("PaintType")]
public partial class PaintType
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string? TypeOfPaint { get; set; }

    [InverseProperty("PaintType")]
    public virtual ICollection<Paint> Paints { get; set; } = new List<Paint>();
}
