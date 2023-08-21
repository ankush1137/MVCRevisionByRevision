﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Web.Entities;

namespace Web
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=DropDownDb;Integrated Security=True");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<City>(entity =>
        //    {
        //        //entity.HasOne(d => d.State)
        //        //    .WithMany(p => p.Cities)
        //        //    .HasForeignKey(d => d.StateId)
        //        //    .OnDelete(DeleteBehavior.SetNull)
        //        //    .HasConstraintName("FK__Cities__StateId__7A672E12");
        //    });

        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.Property(e => e.JoiningDate).HasDefaultValueSql("(getdate())");

        //        entity.Property(e => e.Mobile).IsFixedLength();

        //        //entity.HasOne(d => d.Cities)
        //        //    .WithMany(p => p.Employees)
        //        //    .HasForeignKey(d => d.CitiesId)
        //        //    .OnDelete(DeleteBehavior.SetNull)
        //        //    .HasConstraintName("FK__Employee__Cities__00200768");

        //        //entity.HasOne(d => d.Image)
        //        //    .WithMany(p => p.Employees)
        //        //    .HasForeignKey(d => d.ImageId)
        //        //    .OnDelete(DeleteBehavior.SetNull)
        //        //    .HasConstraintName("FK__Employee__ImageI__01142BA1");

        //        //entity.HasOne(d => d.State)
        //        //    .WithMany(p => p.Employees)
        //        //    .HasForeignKey(d => d.StateId)
        //        //    .OnDelete(DeleteBehavior.SetNull)
        //        //    .HasConstraintName("FK__Employee__StateI__7F2BE32F");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}