using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

[Keyless]
[Table("PaintsForRecipe")]
public partial class PaintsForRecipe
{
    [Column("RecipeID")]
    public int? RecipeId { get; set; }

    [Column("PaintID")]
    public int? PaintId { get; set; }

    [ForeignKey("PaintId")]
    public virtual Paint? Paint { get; set; }

    [ForeignKey("RecipeId")]
    public virtual PaintRecipe? Recipe { get; set; }
}
