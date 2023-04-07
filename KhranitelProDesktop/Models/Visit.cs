using System;
using System.Collections.Generic;

namespace KhranitelProDesktop.Models;

public partial class Visit
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public int Targetid { get; set; }

    public int Employeeid { get; set; }

    public int Typeid { get; set; }

    public int Statusid { get; set; }

    public string? Statusreason { get; set; }

    public DateTime? Visitdate { get; set; }

    public string? Groupname { get; set; }

    public TimeOnly? Time { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Visitstatus Status { get; set; } = null!;

    public virtual Visittarget Target { get; set; } = null!;

    public virtual Visittype Type { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Visitor> Visitors { get; } = new List<Visitor>();
}
