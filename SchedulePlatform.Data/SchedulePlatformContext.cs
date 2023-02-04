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

        base.OnModelCreating(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<ServiceProvided> Services { get; set; }
    
}
