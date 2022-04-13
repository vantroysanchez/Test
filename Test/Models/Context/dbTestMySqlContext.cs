using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Test.Models.Context
{
    public partial class dbTestMySqlContext : DbContext
    {
        public dbTestMySqlContext()
        {
        }

        public dbTestMySqlContext(DbContextOptions<dbTestMySqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.HasIndex(e => e.EditorialId, "EditorialId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Status)
                    .HasColumnType("bit(1)")
                    .HasColumnName("status");

                entity.HasOne(d => d.Editorial)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.EditorialId)
                    .HasConstraintName("book_ibfk_1");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.ToTable("editorial");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Status)
                    .HasColumnType("bit(1)")
                    .HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
