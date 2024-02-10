using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

public partial class PaintRecipe
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("KolboldUserID")]
    public int? KolboldUserId { get; set; }

    [StringLength(50)]
    public string? RecipeName { get; set; }

    public string? Description { get; set; }

    [ForeignKey("KolboldUserId")]
    [InverseProperty("PaintRecipes")]
    public virtual KolboldUser? KolboldUser { get; set; }
}
