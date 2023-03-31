using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class EthernetShopContext : DbContext
{
    public EthernetShopContext()
    {
    }

    public EthernetShopContext(DbContextOptions<EthernetShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buy> Buys { get; set; }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<PurchaseContent> PurchaseContents { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buy>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK_Покупки");

            entity.Property(e => e.PurchaseId)
                .ValueGeneratedNever()
                .HasColumnName("Purchase_id");
            entity.Property(e => e.BuyerId).HasColumnName("Buyer_id");
            entity.Property(e => e.DeliveryType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Delivery_type");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("date")
                .HasColumnName("Purchase_date");
            entity.Property(e => e.SellerId).HasColumnName("Seller_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('InProcess')");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Buys)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK_Покупки_Покупатель");

            entity.HasOne(d => d.Seller).WithMany(p => p.Buys)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_Покупки_Продавец");
        });

        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.HasKey(e => e.BuyerId).HasName("PK_Покупатели");

            entity.Property(e => e.BuyerId)
                .ValueGeneratedNever()
                .HasColumnName("Buyer_id");
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Home_address");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasColumnName("Phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Товар");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("Product_id");
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.QuanityInStock).HasColumnName("Quanity_in_stock");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Категории_Товар");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_Категории");

            entity.ToTable("Product_categories");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("Category_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ParentCategotyId).HasColumnName("Parent_categoty_id");

            entity.HasOne(d => d.ParentCategoty).WithMany(p => p.InverseParentCategoty)
                .HasForeignKey(d => d.ParentCategotyId)
                .HasConstraintName("FK_Product_categories_Product_categories");
        });

        modelBuilder.Entity<PurchaseContent>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.PurchaseId }).HasName("PK_Содержание");

            entity.ToTable("Purchase_content");

            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.PurchaseId).HasColumnName("Purchase_id");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseContents)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Содержание_Товар");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseContents)
                .HasForeignKey(d => d.PurchaseId)
                .HasConstraintName("FK_Содержимое_Покупки");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.SellerId).HasName("PK_Продавцы");

            entity.Property(e => e.SellerId)
                .ValueGeneratedNever()
                .HasColumnName("Seller_id");
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Home_address");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Job_title");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasColumnName("Phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
