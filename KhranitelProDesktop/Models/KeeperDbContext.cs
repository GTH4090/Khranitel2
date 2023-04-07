using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KhranitelProDesktop.Models;

public partial class KeeperDbContext : DbContext
{
    public KeeperDbContext()
    {
    }

    public KeeperDbContext(DbContextOptions<KeeperDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    public virtual DbSet<Visitstatus> Visitstatuses { get; set; }

    public virtual DbSet<Visittarget> Visittargets { get; set; }

    public virtual DbSet<Visittype> Visittypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User Id=postgres;Password=12345;Host=localhost;Port=5432;Database=KeeperDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("department_pk");

            entity.ToTable("department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("division_pk");

            entity.ToTable("division");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Ident).HasName("employee_pk");

            entity.ToTable("employee");

            entity.Property(e => e.Ident).HasColumnName("ident");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Divisionid).HasColumnName("divisionid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Departmentid)
                .HasConstraintName("employer_fk_1");

            entity.HasOne(d => d.Division).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Divisionid)
                .HasConstraintName("employer_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visit_pk");

            entity.ToTable("visit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Enddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddate");
            entity.Property(e => e.Groupname)
                .HasMaxLength(50)
                .HasColumnName("groupname");
            entity.Property(e => e.Startdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Statusreason)
                .HasMaxLength(50)
                .HasColumnName("statusreason");
            entity.Property(e => e.Targetid).HasColumnName("targetid");
            entity.Property(e => e.Typeid).HasColumnName("typeid");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Visitdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("visitdate");

            entity.HasOne(d => d.Employee).WithMany(p => p.Visits)
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visit_fk_4");

            entity.HasOne(d => d.Status).WithMany(p => p.Visits)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visit_fk_3");

            entity.HasOne(d => d.Target).WithMany(p => p.Visits)
                .HasForeignKey(d => d.Targetid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visit_fk12");

            entity.HasOne(d => d.Type).WithMany(p => p.Visits)
                .HasForeignKey(d => d.Typeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visit_fk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Visits)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visit_fk_1");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visitor_pk");

            entity.ToTable("visitor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Organisation)
                .HasMaxLength(50)
                .HasColumnName("organisation");
            entity.Property(e => e.Passportnumber)
                .HasMaxLength(50)
                .HasColumnName("passportnumber");
            entity.Property(e => e.Passportscan).HasColumnName("passportscan");
            entity.Property(e => e.Passportserial)
                .HasMaxLength(50)
                .HasColumnName("passportserial");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Remark)
                .HasMaxLength(50)
                .HasColumnName("remark");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
            entity.Property(e => e.Visitid).HasColumnName("visitid");

            entity.HasOne(d => d.Visit).WithMany(p => p.Visitors)
                .HasForeignKey(d => d.Visitid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visitor_fk");
        });

        modelBuilder.Entity<Visitstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visitstatus_pk");

            entity.ToTable("visitstatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Visittarget>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visittarget_pk");

            entity.ToTable("visittarget");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Visittype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visittype_pk");

            entity.ToTable("visittype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
