using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Test.Models.Context
{
    public partial class dbTestSqlServerContext : DbContext
    {        

        public dbTestSqlServerContext(DbContextOptions<dbTestSqlServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }       
        public virtual DbSet<User> Users { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.Editorial)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.EditorialId);
                    //.HasConstraintName("FK_Book_Editorial");
            });

            modelBuilder.Entity<User>(entity =>
            {                
                entity.ToTable("User");

                entity.Property(e => e.UserName).HasMaxLength(32);
                entity.Property(e => e.LastName).HasMaxLength(32);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BookId);
                    //.HasConstraintName("FK_User_Book");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.ToTable("Editorial");

                entity.Property(e => e.Description).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
