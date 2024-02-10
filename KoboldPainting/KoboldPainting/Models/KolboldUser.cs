using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

[Table("KolboldUser")]
public partial class KolboldUser
{
    [Key]
    public int Id { get; set; }

    [Column("AspNetUserID")]
    [StringLength(500)]
    public string? AspNetUserId { get; set; }

    [StringLength(64)]
    public string? FirstName { get; set; }

    [StringLength(64)]
    public string? LastName { get; set; }

    [InverseProperty("KolboldUser")]
    public virtual ICollection<PaintRecipe> PaintRecipes { get; set; } = new List<PaintRecipe>();
}
