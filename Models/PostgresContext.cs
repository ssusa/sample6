using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sample6.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SampleTable> SampleTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=getthelupin776");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SampleTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sample_table_pkey");

            entity.ToTable("sample_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedColumn1)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_column1");
            entity.Property(e => e.IntColumn1).HasColumnName("int_column1");
            entity.Property(e => e.IntColumn2).HasColumnName("int_column2");
            entity.Property(e => e.ModifyColumn2)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modify_column2");
            entity.Property(e => e.VarcharColumn1)
                .HasMaxLength(255)
                .HasColumnName("varchar_column1");
            entity.Property(e => e.VarcharColumn2)
                .HasMaxLength(255)
                .HasColumnName("varchar_column2");
            entity.Property(e => e.VarcharColumn3).HasColumnName("varchar_column3");
        });
        modelBuilder.HasSequence("sample_table_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
