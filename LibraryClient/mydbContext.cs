using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryClient
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookHasAuthor> BookHasAuthor { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersHasBook> OrdersHasBook { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserHasOrders> UserHasOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=123123;database=mydb", x => x.ServerVersion("8.0.11-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor)
                    .HasName("PRIMARY");

                entity.ToTable("author");

                entity.HasIndex(e => e.Name)
                    .HasName("Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdAuthor)
                    .HasColumnName("idAuthor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.IdBook)
                    .HasName("PRIMARY");

                entity.ToTable("book");

                entity.HasIndex(e => e.IdBook)
                    .HasName("idBook_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdBook)
                    .HasColumnName("idBook")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("int(10)");

                entity.Property(e => e.TotalCount)
                    .HasColumnName("total_count")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<BookHasAuthor>(entity =>
            {
                entity.HasKey(e => new { e.BookIdBook, e.AuthorIdAuthor })
                    .HasName("PRIMARY");

                entity.ToTable("book_has_author");

                entity.HasIndex(e => e.AuthorIdAuthor)
                    .HasName("fk_Book_has_Author_Author1_idx");

                entity.HasIndex(e => e.BookIdBook)
                    .HasName("fk_Book_has_Author_Book_idx");

                entity.Property(e => e.BookIdBook)
                    .HasColumnName("Book_idBook")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AuthorIdAuthor)
                    .HasColumnName("Author_idAuthor")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.AuthorIdAuthorNavigation)
                    .WithMany(p => p.BookHasAuthor)
                    .HasForeignKey(d => d.AuthorIdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Book_has_Author_Author1");

                entity.HasOne(d => d.BookIdBookNavigation)
                    .WithMany(p => p.BookHasAuthor)
                    .HasForeignKey(d => d.BookIdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Book_has_Author_Book");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PRIMARY");

                entity.ToTable("orders");

                entity.Property(e => e.IdOrder)
                    .HasColumnName("idOrder")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderEnd)
                    .HasColumnName("orderEnd")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderStart)
                    .HasColumnName("orderStart")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OrdersHasBook>(entity =>
            {
                entity.HasKey(e => new { e.OrdersIdOrder, e.BookIdBook })
                    .HasName("PRIMARY");

                entity.ToTable("orders_has_book");

                entity.HasIndex(e => e.BookIdBook)
                    .HasName("fk_orders_has_book_book1_idx");

                entity.HasIndex(e => e.OrdersIdOrder)
                    .HasName("fk_orders_has_book_orders1_idx");

                entity.Property(e => e.OrdersIdOrder)
                    .HasColumnName("orders_idOrder")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookIdBook)
                    .HasColumnName("book_idBook")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.BookIdBookNavigation)
                    .WithMany(p => p.OrdersHasBook)
                    .HasForeignKey(d => d.BookIdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orders_has_book_book1");

                entity.HasOne(d => d.OrdersIdOrderNavigation)
                    .WithMany(p => p.OrdersHasBook)
                    .HasForeignKey(d => d.OrdersIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orders_has_book_orders1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasIndex(e => e.Phone)
                    .HasName("phone_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasColumnName("adres")
                    .HasColumnType("varchar(85)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UserHasOrders>(entity =>
            {
                entity.HasKey(e => e.OrdersIdOrder)
                    .HasName("PRIMARY");

                entity.ToTable("user_has_orders");

                entity.HasIndex(e => e.OrdersIdOrder)
                    .HasName("fk_user_has_orders_orders1_idx");

                entity.HasIndex(e => e.UserIdUser)
                    .HasName("fk_user_has_orders_user1_idx");

                entity.Property(e => e.OrdersIdOrder)
                    .HasColumnName("orders_idOrder")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserIdUser)
                    .HasColumnName("user_idUser")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.OrdersIdOrderNavigation)
                    .WithOne(p => p.UserHasOrders)
                    .HasForeignKey<UserHasOrders>(d => d.OrdersIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_has_orders_orders1");

                entity.HasOne(d => d.UserIdUserNavigation)
                    .WithMany(p => p.UserHasOrders)
                    .HasForeignKey(d => d.UserIdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_has_orders_user1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
