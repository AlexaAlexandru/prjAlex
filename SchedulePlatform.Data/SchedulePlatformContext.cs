using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Models;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data;

public partial class SchedulePlatformContext : DbContext
{
    public SchedulePlatformContext()
    {
    }

    public SchedulePlatformContext(DbContextOptions<SchedulePlatformContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>();
        modelBuilder.Entity<ServiceProvided>();
        modelBuilder.Entity<Menu>();
        modelBuilder.Entity<Nutritionist>();
        modelBuilder.Entity<NutritionistService>()
            .HasOne(n => n.Nutritionist)
            .WithMany(ns => ns.NutritionistService)
            .HasForeignKey(ns => ns.NutritionistId);
        modelBuilder.Entity<NutritionistService>()
            .HasOne(n => n.Service)
            .WithMany(ns => ns.NutritionistService)
            .HasForeignKey(ns => ns.ServiceId);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Appointment>()
            .HasOne(n => n.Nutritionist)
            .WithMany(ns => ns.Appointments)
            .HasForeignKey(n => n.NutritionistId);
        modelBuilder.Entity<Appointment>()
            .HasOne(n => n.Customer)
            .WithMany(ns => ns.Appointments)
            .HasForeignKey(n => n.CustomerId);
        modelBuilder.Entity<Appointment>()
            .HasOne(n => n.ServiceProvided)
            .WithMany(ns => ns.Appointments)
            .HasForeignKey(n => n.ServiceProvidedId);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<ServiceProvided> Services { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Nutritionist> Nutritionists { get; set; }

    public virtual DbSet<NutritionistService> NutritionistServices { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

}
