using System;
using System.Collections.Generic;

namespace KhranitelProDesktop.Models;

public partial class Employee
{
    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int? Divisionid { get; set; }

    public int? Departmentid { get; set; }

    public string Code { get; set; } = null!;

    public int Ident { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Division? Division { get; set; }

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
