using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlueFlamePizza.Models
{
    public partial class BlueFlamePizzaDBContext : DbContext
    {
        public BlueFlamePizzaDBContext()
        {
        }

        public BlueFlamePizzaDBContext(DbContextOptions<BlueFlamePizzaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Extras> Extras { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MI9D3RO\\SQLEXPRESS;Initial Catalog=BlueFlamePizzaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .HasColumnName("Cart_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CartCity)
                    .HasColumnName("Cart_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CartContent)
                    .HasColumnName("Cart_Content")
                    .HasColumnType("text");

                entity.Property(e => e.CartCountry)
                    .HasColumnName("Cart_Country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CartCreatedAt)
                    .HasColumnName("Cart_CreatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CartEmail)
                    .HasColumnName("Cart_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CartFirstName)
                    .HasColumnName("Cart_FirstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CartLastName)
                    .HasColumnName("Cart_LastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CartLine1)
                    .HasColumnName("Cart_Line1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CartLine2)
                    .HasColumnName("Cart_Line2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CartPhone)
                    .HasColumnName("Cart_Phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CartSessionId)
                    .HasColumnName("Cart_SessionID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CartStatus)
                    .IsRequired()
                    .HasColumnName("Cart_Status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CartToken)
                    .HasColumnName("Cart_Token")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CartUpdatedAt)
                    .HasColumnName("Cart_UpdatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CartZip)
                    .HasColumnName("Cart_Zip")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Cart_User");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("Cart_Item");

                entity.Property(e => e.CartItemId)
                    .HasColumnName("Cart_Item_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CartId).HasColumnName("Cart_ID");

                entity.Property(e => e.CartItemActive).HasColumnName("Cart_Item_Active");

                entity.Property(e => e.CartItemContent)
                    .HasColumnName("Cart_Item_Content")
                    .HasColumnType("text");

                entity.Property(e => e.CartItemCreatedAt)
                    .HasColumnName("Cart_Item_CreatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CartItemPrice).HasColumnName("Cart_Item_Price");

                entity.Property(e => e.CartItemQuantity).HasColumnName("Cart_Item_Quantity");

                entity.Property(e => e.CartItemSku)
                    .IsRequired()
                    .HasColumnName("Cart_Item_SKU")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CartItemUpdatedAt)
                    .HasColumnName("Cart_Item_UpdatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Item_Cart");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Item_Product");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("Category_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_Name")
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<Extras>(entity =>
            {
                entity.Property(e => e.ExtrasId)
                    .HasColumnName("Extras_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExtrasName)
                    .IsRequired()
                    .HasColumnName("Extras_Name")
                    .HasMaxLength(75);

                entity.Property(e => e.ExtrasPrice).HasColumnName("Extras_Price");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderCity)
                    .HasColumnName("Order_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderContent)
                    .HasColumnName("Order_Content")
                    .HasColumnType("text");

                entity.Property(e => e.OrderCountry)
                    .HasColumnName("Order_Country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderCreatedAt)
                    .HasColumnName("Order_CreatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderEmail)
                    .HasColumnName("Order_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderFirstName)
                    .HasColumnName("Order_FirstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderGrandTotal).HasColumnName("Order_GrandTotal");

                entity.Property(e => e.OrderLastName)
                    .HasColumnName("Order_LastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderLine1)
                    .HasColumnName("Order_Line1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderLine2)
                    .HasColumnName("Order_Line2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderPhone)
                    .HasColumnName("Order_Phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OrderSessionId)
                    .HasColumnName("Order_SessionID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasColumnName("Order_Status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderSubtotal).HasColumnName("Order_Subtotal");

                entity.Property(e => e.OrderTax).HasColumnName("Order_Tax");

                entity.Property(e => e.OrderToken)
                    .HasColumnName("Order_Token")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderUpdatedAt)
                    .HasColumnName("Order_UpdatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderZip)
                    .HasColumnName("Order_Zip")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_Item");

                entity.Property(e => e.OrderItemId)
                    .HasColumnName("Order_Item_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.OrderItemContent)
                    .HasColumnName("Order_Item_Content")
                    .HasColumnType("text");

                entity.Property(e => e.OrderItemCreatedAt)
                    .HasColumnName("Order_Item_CreatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderItemPrice).HasColumnName("Order_Item_Price");

                entity.Property(e => e.OrderItemQuantity).HasColumnName("Order_Item_Quantity");

                entity.Property(e => e.OrderItemSku)
                    .IsRequired()
                    .HasColumnName("Order_Item_SKU")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderItemUpdatedAt)
                    .HasColumnName("Order_Item_UpdatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Item_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Item_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");

                entity.Property(e => e.ProductContent)
                    .HasColumnName("Product_Content")
                    .HasColumnType("text");

                entity.Property(e => e.ProductCreatedAt)
                    .HasColumnName("Product_CreatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");

                entity.Property(e => e.ProductQuantity).HasColumnName("Product_Quantity");

                entity.Property(e => e.ProductSku)
                    .IsRequired()
                    .HasColumnName("Product_SKU")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductTitle)
                    .IsRequired()
                    .HasColumnName("Product_Title")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("Role_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId)
                    .HasColumnName("Transaction_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.TransactionCode)
                    .IsRequired()
                    .HasColumnName("Transaction_Code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionContent)
                    .HasColumnName("Transaction_Content")
                    .HasColumnType("text");

                entity.Property(e => e.TransactionCreatedAt)
                    .HasColumnName("Transaction_CreatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionMode)
                    .IsRequired()
                    .HasColumnName("Transaction_Mode")
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasColumnName("Transaction_Status")
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnName("Transaction_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionUpdatedAt)
                    .HasColumnName("Transaction_UpdatedAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction_Order");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Transaction_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("User_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserFirstName)
                    .HasColumnName("User_FirstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLastLogin)
                    .HasColumnName("User_LastLogin")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserLastName)
                    .HasColumnName("User_LastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPasswordHash)
                    .IsRequired()
                    .HasColumnName("User_PasswordHash")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UserPasswordHint)
                    .HasColumnName("User_PasswordHint")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasColumnName("User_Phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserRegisteredAt)
                    .HasColumnName("User_RegisteredAt")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserRoleId).HasColumnName("User_Role_ID");

                entity.Property(e => e.UserSessionId)
                    .HasColumnName("User_SessionID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
