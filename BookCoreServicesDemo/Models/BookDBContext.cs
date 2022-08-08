using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookCoreServicesDemo.Models
{
    public partial class BookDBContext : DbContext
    {
        public BookDBContext()
        {
        }

        public BookDBContext(DbContextOptions<BookDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CourseTab> CourseTabs { get; set; } = null!;
        public virtual DbSet<MasterBook> MasterBooks { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=W10FT4QN53\\SQLEXPRESS;Initial Catalog=BookDB;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTab>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("CourseTab");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MasterBook>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.ToTable("MasterBook");

                entity.Property(e => e.BookAuthor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
