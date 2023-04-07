using System;
using System.Collections.Generic;

namespace KhranitelProDesktop.Models;

public partial class Visitor
{
    public int Id { get; set; }

    public byte[]? Photo { get; set; }

    public int Visitid { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Surname { get; set; }

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public string? Organisation { get; set; }

    public DateTime Birthdate { get; set; }

    public string Passportserial { get; set; } = null!;

    public string Passportnumber { get; set; } = null!;

    public byte[] Passportscan { get; set; } = null!;

    public string? Remark { get; set; }

    public bool Isbanned { get; set; }

    public virtual Visit Visit { get; set; } = null!;
}
