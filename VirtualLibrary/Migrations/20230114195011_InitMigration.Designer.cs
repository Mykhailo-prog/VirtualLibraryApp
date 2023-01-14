﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtualLibrary.Models;

#nullable disable

namespace VirtualLibrary.Migrations
{
    [DbContext(typeof(VirtualLibraryDbContext))]
    [Migration("20230114195011_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VirtualLibrary.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Articles__3214EC07F069ECEC");

                    b.HasIndex("ItemId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("VirtualLibrary.Models.ArticleCopy", b =>
                {
                    b.Property<int>("CopyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CopyId"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.HasKey("CopyId")
                        .HasName("PK__ArticleC__C26CCCC5323192A0");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleCopies");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Isbn")
                        .HasColumnType("int")
                        .HasColumnName("ISBN");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Books__3214EC07B825115C");

                    b.HasIndex("ItemId");

                    b.HasIndex(new[] { "Isbn" }, "UQ__Books__447D36EA8D7D3A38")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("VirtualLibrary.Models.BookCopy", b =>
                {
                    b.Property<int>("CopyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CopyId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("CopyId")
                        .HasName("PK__BookCopi__C26CCCC5E76261AA");

                    b.HasIndex("BookId");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PublishDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Items__3214EC0717C528A5");

                    b.HasIndex("PublisherId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Magazine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IssueNumber")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Magazine__3214EC07C71B2932");

                    b.HasIndex("ItemId");

                    b.HasIndex(new[] { "IssueNumber" }, "UQ__Magazine__5703F26CCF0E55B4")
                        .IsUnique();

                    b.ToTable("Magazines");
                });

            modelBuilder.Entity("VirtualLibrary.Models.MagazineArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("MagazineId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Magazine__3214EC078F1EDE53");

                    b.HasIndex("ArticleId");

                    b.HasIndex("MagazineId");

                    b.ToTable("MagazineArticle", (string)null);
                });

            modelBuilder.Entity("VirtualLibrary.Models.MagazineCopy", b =>
                {
                    b.Property<int>("CopyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CopyId"));

                    b.Property<int>("MagazineId")
                        .HasColumnType("int");

                    b.HasKey("CopyId")
                        .HasName("PK__Magazine__C26CCCC58566BDDA");

                    b.HasIndex("MagazineId");

                    b.ToTable("MagazineCopies");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Publishe__3214EC0762B8ED1F");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Article", b =>
                {
                    b.HasOne("VirtualLibrary.Models.Item", "Item")
                        .WithMany("Articles")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Articles__ItemId__403A8C7D");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("VirtualLibrary.Models.ArticleCopy", b =>
                {
                    b.HasOne("VirtualLibrary.Models.Article", "Article")
                        .WithMany("ArticleCopies")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ArticleCo__Artic__4D94879B");

                    b.Navigation("Article");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Book", b =>
                {
                    b.HasOne("VirtualLibrary.Models.Item", "Item")
                        .WithMany("Books")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Books__ItemId__3D5E1FD2");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("VirtualLibrary.Models.BookCopy", b =>
                {
                    b.HasOne("VirtualLibrary.Models.Book", "Book")
                        .WithMany("BookCopies")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__BookCopie__BookI__4AB81AF0");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Item", b =>
                {
                    b.HasOne("VirtualLibrary.Models.Publisher", "Publisher")
                        .WithMany("Items")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Items__Publisher__398D8EEE");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Magazine", b =>
                {
                    b.HasOne("VirtualLibrary.Models.Item", "Item")
                        .WithMany("Magazines")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Magazines__ItemI__440B1D61");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("VirtualLibrary.Models.MagazineArticle", b =>
                {
                    b.HasOne("VirtualLibrary.Models.Article", "Article")
                        .WithMany("MagazineArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__MagazineA__Artic__47DBAE45");

                    b.HasOne("VirtualLibrary.Models.Magazine", "Magazine")
                        .WithMany("MagazineArticles")
                        .HasForeignKey("MagazineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__MagazineA__Magaz__46E78A0C");

                    b.Navigation("Article");

                    b.Navigation("Magazine");
                });

            modelBuilder.Entity("VirtualLibrary.Models.MagazineCopy", b =>
                {
                    b.HasOne("VirtualLibrary.Models.Magazine", "Magazine")
                        .WithMany("MagazineCopies")
                        .HasForeignKey("MagazineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__MagazineC__Magaz__5070F446");

                    b.Navigation("Magazine");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Article", b =>
                {
                    b.Navigation("ArticleCopies");

                    b.Navigation("MagazineArticles");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Book", b =>
                {
                    b.Navigation("BookCopies");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Item", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Books");

                    b.Navigation("Magazines");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Magazine", b =>
                {
                    b.Navigation("MagazineArticles");

                    b.Navigation("MagazineCopies");
                });

            modelBuilder.Entity("VirtualLibrary.Models.Publisher", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
