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

    [Column("KoboldUserID")]
    public int? KoboldUserId { get; set; }

    [StringLength(50)]
    public string? RecipeName { get; set; }

    public string? Description { get; set; }

    [ForeignKey("KoboldUserId")]
    [InverseProperty("PaintRecipes")]
    public virtual KoboldUser? KoboldUser { get; set; }
}
