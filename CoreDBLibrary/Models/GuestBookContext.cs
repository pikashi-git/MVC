using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreDBLibrary.Models
{
    public partial class GuestBookContext : DbContext
    {
        public GuestBookContext()
        {
        }

        public GuestBookContext(DbContextOptions<GuestBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Guestbook> Guestbooks { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MSFFD0S\\SQLEXPRESS;Initial Catalog=GuestBook;Persist Security Info=True;User ID=guestbook;Password=1234");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__cartSave__CB9A1CDF0CFD4546");

                entity.ToTable("cart");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("userID");

                entity.Property(e => e.CartId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cart_id");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Cart)
                    .HasForeignKey<Cart>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cartSave__userID__208CD6FA");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.ItemId })
                    .HasName("PK__cartBuy__2EF52A274327353D");

                entity.ToTable("cartItem");

                entity.Property(e => e.CartId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cart_id");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cartBuy_item");
            });

            modelBuilder.Entity<Guestbook>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UserId });

                entity.ToTable("guestbook");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Parent).HasColumnName("parent");

                entity.Property(e => e.PostContent).HasColumnName("postContent");

                entity.Property(e => e.Updatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("updatetime");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.RoleName });

                entity.ToTable("roles");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("roleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .HasColumnName("roleName");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Groups)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("groups");

                entity.Property(e => e.RoleDesc)
                    .HasMaxLength(50)
                    .HasColumnName("roleDesc");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Account)
                    .HasMaxLength(100)
                    .HasColumnName("account");

                entity.Property(e => e.Authcode)
                    .HasColumnName("authcode")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("names");

                entity.Property(e => e.Nick)
                    .HasMaxLength(100)
                    .HasColumnName("nick");

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.ValidateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("validateDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
