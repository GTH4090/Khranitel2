using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace KhranitelProDesktop.Models;

public partial class Employee
{
    public string Name {get{return this.Lastname + " " + this.Firstname + " " + this.Surname;
    }}
}