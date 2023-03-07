using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StyleSphere.Models;

public partial class StyleSphereDbContext : DbContext
{
    public StyleSphereDbContext()
    {
    }

    public StyleSphereDbContext(DbContextOptions<StyleSphereDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ColorMaster> ColorMasters { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrdersDatum> OrdersData { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductMapping> ProductMappings { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<SizesMaster> SizesMasters { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ANUJOLYDEE;Database=StyleSphereDB;Trusted_Connection=True;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
        });

        modelBuilder.Entity<ColorMaster>(entity =>
        {
            entity.HasKey(e => e.ColorId);

            entity.ToTable("ColorMaster");

            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.Color).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ContactNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoritesId);

            entity.Property(e => e.FavoritesId).HasColumnName("FavoritesID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Customers");

            entity.HasOne(d => d.Product).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Products");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId);

            entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.ProductMappingId).HasColumnName("ProductMappingID");
            entity.Property(e => e.Quantity).HasMaxLength(50);
            entity.Property(e => e.Total).HasMaxLength(50);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_OrdersData");

            entity.HasOne(d => d.ProductMapping).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductMappingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_ProductMappings");
        });

        modelBuilder.Entity<OrdersDatum>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.BillingAddress)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.TrackingId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TrackingID");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrdersData)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdersData_Customers");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Image1).IsUnicode(false);
            entity.Property(e => e.Image2).IsUnicode(false);
            entity.Property(e => e.Image3).IsUnicode(false);
            entity.Property(e => e.MfgDate).HasColumnType("date");
            entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");
            entity.Property(e => e.ThumbnailImage).IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Sub_Categories");
        });

        modelBuilder.Entity<ProductMapping>(entity =>
        {
            entity.Property(e => e.ProductMappingId).HasColumnName("ProductMappingID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SizeId).HasColumnName("SizeID");

            entity.HasOne(d => d.Color).WithMany(p => p.ProductMappings)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductMappings_ColorMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductMappings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductMappings_Products");

            entity.HasOne(d => d.Size).WithMany(p => p.ProductMappings)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductMappings_SizesMaster");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.Property(e => e.RatingId).HasColumnName("RatingID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Rating1).HasColumnName("Rating");

            entity.HasOne(d => d.Customer).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ratings_Customers");

            entity.HasOne(d => d.Product).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ratings_Products");
        });

        modelBuilder.Entity<SizesMaster>(entity =>
        {
            entity.HasKey(e => e.SizeId);

            entity.ToTable("SizesMaster");

            entity.Property(e => e.SizeId).HasColumnName("SizeID");
            entity.Property(e => e.Eusize)
                .HasMaxLength(50)
                .HasColumnName("EUSize");
            entity.Property(e => e.Ussize)
                .HasMaxLength(50)
                .HasColumnName("USSize");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId).HasName("PK_Sub Categories");

            entity.ToTable("Sub_Categories");

            entity.Property(e => e.SubCategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SubCategoryID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.SubCategoryName).HasMaxLength(50);

            entity.HasOne(d => d.SubCategoryNavigation).WithOne(p => p.SubCategory)
                .HasForeignKey<SubCategory>(d => d.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sub Categories_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
