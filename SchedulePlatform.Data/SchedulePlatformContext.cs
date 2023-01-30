using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=localhost;Database=SchedulePlatform;User Id=sa;Password=alexNet007;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    
}
