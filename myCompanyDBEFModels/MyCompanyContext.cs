using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCIdentity.myCompanyDBEFModels;

public partial class MyCompanyContext : DbContext
{
    public MyCompanyContext()
    {
    }

    public MyCompanyContext(DbContextOptions<MyCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    // STEP 7: Commented out for security so it uses the one in appsettings.json
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("Server=Win11PC;Database=myCompany;Trusted_Connection=True;MultipleActiveResultSets=true; trustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAddress);
            entity.ToTable("address");
            entity.Property(e => e.IdAddress).HasColumnName("idAddress");
            entity.Property(e => e.Description).HasMaxLength(10).IsFixedLength().HasColumnName("description");
            entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");

            // *** ADD THIS CONFIGURATION ***
            entity.HasOne(d => d.Customer)
                  .WithMany(p => p.Adresses)
                  .HasForeignKey(d => d.IdCustomer);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK_customer_1");
            entity.ToTable("customer");
            entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");
            entity.Property(e => e.Name).HasMaxLength(10).IsFixedLength().HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}