using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.Entidades;

public partial class EjerciciosContext : DbContext
{
    public EjerciciosContext(DbContextOptions<EjerciciosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MedicionLuce> MedicionLuces { get; set; }

    public virtual DbSet<PatronLuce> PatronLuces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicionLuce>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MedicionLuces_PK");

            entity.Property(e => e.IncBajaIzq1)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("Inc_Baja_Izq_1");
            entity.Property(e => e.IntBajaDer1)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("Int_Baja_Der_1");
            entity.Property(e => e.IntBajaIzq1)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("Int_Baja_Izq_1");
        });

        modelBuilder.Entity<PatronLuce>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PatronLuces_PK");

            entity.Property(e => e.IncBajaIzq1).HasColumnName("Inc_Baja_Izq_1");
            entity.Property(e => e.IntBajaDer1).HasColumnName("Int_Baja_Der_1");
            entity.Property(e => e.IntBajaIzq1).HasColumnName("Int_Baja_Izq_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
