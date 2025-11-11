using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StolyarovaDemo.Models;

public partial class Db521Context : DbContext
{
    public Db521Context()
    {
    }

    public Db521Context(DbContextOptions<Db521Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SpecMaterial> SpecMaterials { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=lorksipt.ru;Port=5432;Database=db521;Username=user521;Password=03854");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomId).HasName("customers_pkey");

            entity.ToTable("customers");

            entity.Property(e => e.CustomId).HasColumnName("custom_id");
            entity.Property(e => e.CustomAddress).HasColumnName("custom_address");
            entity.Property(e => e.CustomBuyer).HasColumnName("custom_buyer");
            entity.Property(e => e.CustomInn).HasColumnName("custom_inn");
            entity.Property(e => e.CustomName).HasColumnName("custom_name");
            entity.Property(e => e.CustomPhone).HasColumnName("custom_phone");
            entity.Property(e => e.CustomSalesman).HasColumnName("custom_salesman");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MatId).HasName("materials_pkey");

            entity.ToTable("materials");

            entity.Property(e => e.MatId).HasColumnName("mat_id");
            entity.Property(e => e.MatName).HasColumnName("mat_name");
            entity.Property(e => e.MatPrice)
                .HasPrecision(5, 2)
                .HasColumnName("mat_price");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdId).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.OrdId).HasColumnName("ord_id");
            entity.Property(e => e.CustomIdBuyer).HasColumnName("custom_id_buyer");
            entity.Property(e => e.CustomIdSalesman).HasColumnName("custom_id_salesman");
            entity.Property(e => e.OrdFullprice)
                .HasPrecision(8, 2)
                .HasColumnName("ord_fullprice");

            entity.HasOne(d => d.CustomIdBuyerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomIdBuyer)
                .HasConstraintName("orders_custom_id_buyer_fkey");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrdId, e.PrId }).HasName("order_products_pkey");

            entity.ToTable("order_products");

            entity.Property(e => e.OrdId).HasColumnName("ord_id");
            entity.Property(e => e.PrId).HasColumnName("pr_id");
            entity.Property(e => e.OrdprdCount).HasColumnName("ordprd_count");
            entity.Property(e => e.OrdprdSummPrice)
                .HasPrecision(8, 2)
                .HasColumnName("ordprd_summ_price");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.Ord).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_products_ord_id_fkey");

            entity.HasOne(d => d.Pr).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.PrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_products_prmat_id_fkey");

            entity.HasOne(d => d.Unit).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("order_products_unit_id_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PrId).HasName("products_materials_pkey");

            entity.ToTable("products");

            entity.Property(e => e.PrId)
                .HasDefaultValueSql("nextval('products_materials_prmat_id_seq'::regclass)")
                .HasColumnName("pr_id");
            entity.Property(e => e.PrName).HasColumnName("pr_name");
            entity.Property(e => e.PrPrice)
                .HasPrecision(5, 2)
                .HasColumnName("pr_price");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<SpecMaterial>(entity =>
        {
            entity.HasKey(e => new { e.SpecId, e.MatId }).HasName("spec_mat_pkey");

            entity.ToTable("spec_materials");

            entity.Property(e => e.SpecId).HasColumnName("spec_id");
            entity.Property(e => e.MatId).HasColumnName("mat_id");
            entity.Property(e => e.SpmatCount)
                .HasPrecision(4, 3)
                .HasColumnName("spmat_count");
            entity.Property(e => e.SpmatUnits).HasColumnName("spmat_units");

            entity.HasOne(d => d.Mat).WithMany(p => p.SpecMaterials)
                .HasForeignKey(d => d.MatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("spec_materials_mat_id_fkey");

            entity.HasOne(d => d.Spec).WithMany(p => p.SpecMaterials)
                .HasForeignKey(d => d.SpecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("spec_materials_spec_id_fkey");

            entity.HasOne(d => d.SpmatUnitsNavigation).WithMany(p => p.SpecMaterials)
                .HasForeignKey(d => d.SpmatUnits)
                .HasConstraintName("spec_materials_spmat_units_fkey");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.HasKey(e => e.SpecId).HasName("specifications_pkey");

            entity.ToTable("specifications");

            entity.Property(e => e.SpecId).HasColumnName("spec_id");
            entity.Property(e => e.CustomIdProducer).HasColumnName("custom_id_producer");
            entity.Property(e => e.PrId).HasColumnName("pr_id");
            entity.Property(e => e.SpecCount).HasColumnName("spec_count");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.Pr).WithMany(p => p.Specifications)
                .HasForeignKey(d => d.PrId)
                .HasConstraintName("specifications_pr_id_fkey");

            entity.HasOne(d => d.Unit).WithMany(p => p.Specifications)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("specifications_unit_id_fkey");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("units_pkey");

            entity.ToTable("units");

            entity.Property(e => e.UnitId)
                .ValueGeneratedNever()
                .HasColumnName("unit_id");
            entity.Property(e => e.UnitName).HasColumnName("unit_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UroleId).HasColumnName("urole_id");
            entity.Property(e => e.UserLogin).HasColumnName("user_login");
            entity.Property(e => e.UserName).HasColumnName("user_name");
            entity.Property(e => e.UserPassword).HasColumnName("user_password");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("users_role_id_fkey");

            entity.HasOne(d => d.Urole).WithMany(p => p.UserUroles)
                .HasForeignKey(d => d.UroleId)
                .HasConstraintName("users_urole_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
