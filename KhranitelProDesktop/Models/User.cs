using System;
using System.Collections.Generic;

namespace KhranitelProDesktop.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
