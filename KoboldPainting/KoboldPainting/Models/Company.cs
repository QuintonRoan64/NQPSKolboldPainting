using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

[Table("Company")]
public partial class Company
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string? CompanyName { get; set; }

    [InverseProperty("Company")]
    public virtual ICollection<Paint> Paints { get; set; } = new List<Paint>();
}
