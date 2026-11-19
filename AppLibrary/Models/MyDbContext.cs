using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppLibrary.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookLoan> BookLoans { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<PublishHouse> PublishHouses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=library_db;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("authors_pkey");

            entity.ToTable("authors");

            entity.HasIndex(e => e.AuthorName, "uq_author_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorName).HasColumnName("author_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("books_pkey");

            entity.ToTable("books");

            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.Annotation).HasColumnName("annotation");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.BookName).HasColumnName("book_name");
            entity.Property(e => e.Copies).HasColumnName("copies");
            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.IdGenre).HasColumnName("id_genre");
            entity.Property(e => e.IdPublish).HasColumnName("id_publish");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.YearPub).HasColumnName("year_pub");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .HasConstraintName("fk_books_to_authors");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdGenre)
                .HasConstraintName("fk_books_to_genres");

            entity.HasOne(d => d.PublishHouse).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdPublish)
                .HasConstraintName("fk_books_to_publish");
        });

        modelBuilder.Entity<BookLoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("book_loans_pkey");

            entity.ToTable("book_loans");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bilet).HasColumnName("bilet");
            entity.Property(e => e.DateBack).HasColumnName("date_back");
            entity.Property(e => e.DateBackPlanned).HasColumnName("date_back_planned");
            entity.Property(e => e.DateIssue).HasColumnName("date_issue");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");

            entity.HasOne(d => d.Status).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("fk_book_loans_to_statuses");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genres_pkey");

            entity.ToTable("genres");

            entity.HasIndex(e => e.GenreName, "uq_genre_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GenreName).HasColumnName("genre_name");
        });

        modelBuilder.Entity<PublishHouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("publish_houses_pkey");

            entity.ToTable("publish_houses");

            entity.HasIndex(e => e.PublishHouseName, "uq_publish_house_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PublishHouseName).HasColumnName("publish_house_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "uq_role_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.HasIndex(e => e.StatuseName, "uq_statuse_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatuseName).HasColumnName("statuse_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Bilet).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "uq_login").IsUnique();

            entity.Property(e => e.Bilet).HasColumnName("bilet");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Surname).HasColumnName("surname");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_to_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
