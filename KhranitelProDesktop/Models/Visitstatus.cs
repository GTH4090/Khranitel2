using System;
using System.Collections.Generic;

namespace KhranitelProDesktop.Models;

public partial class Visitstatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
