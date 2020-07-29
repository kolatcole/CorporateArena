﻿// <auto-generated />
using System;
using CorporateArena.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CorporateArena.Presentation.Core.Migrations
{
    [DbContext(typeof(TContext))]
    [Migration("20200729095257_seed")]
    partial class seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CorporateArena.Domain.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleLikesCount")
                        .HasColumnType("int");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("CorporateArena.Domain.ArticleComment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleID")
                        .HasColumnType("int");

                    b.Property<int>("CommentLikesCount")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArticleID");

                    b.ToTable("ArticleComments");
                });

            modelBuilder.Entity("CorporateArena.Domain.ArticleLike", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleID")
                        .HasColumnType("int");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArticleID");

                    b.ToTable("ArticleLikes");
                });

            modelBuilder.Entity("CorporateArena.Domain.BrainTeaser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Riddle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("BrainTeasers");
                });

            modelBuilder.Entity("CorporateArena.Domain.BrainTeaserAnswer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrainTeaserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BrainTeaserID");

                    b.ToTable("BrainTeaserAnswers");
                });

            modelBuilder.Entity("CorporateArena.Domain.CommentLike", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleCommentID")
                        .HasColumnType("int");

                    b.Property<int>("ArticleID")
                        .HasColumnType("int");

                    b.Property<int>("CommentID")
                        .HasColumnType("int");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArticleCommentID");

                    b.ToTable("CommentLikes");
                });

            modelBuilder.Entity("CorporateArena.Domain.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CorporateArena.Domain.Privilege", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.Property<int?>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int?>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("Privileges");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Action = "act",
                            DateCreated = new DateTime(2020, 7, 29, 10, 52, 56, 443, DateTimeKind.Local).AddTicks(9134),
                            DateModified = new DateTime(2020, 7, 29, 10, 52, 56, 445, DateTimeKind.Local).AddTicks(5659),
                            DisplayName = "test",
                            Entity = "testEnt",
                            Name = "dd",
                            UserCreated = 1,
                            UserModified = 1
                        });
                });

            modelBuilder.Entity("CorporateArena.Domain.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int?>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CorporateArena.Domain.RolePrivilege", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PrivilegeID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("RolePrivileges");
                });

            modelBuilder.Entity("CorporateArena.Domain.TrafficComment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrafficUpdateID")
                        .HasColumnType("int");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TrafficUpdateID");

                    b.ToTable("TrafficComments");
                });

            modelBuilder.Entity("CorporateArena.Domain.TrafficUpdate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("TrafficUpdates");
                });

            modelBuilder.Entity("CorporateArena.Domain.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int?>("UserModified")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("CorporateArena.Domain.UserRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int?>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CorporateArena.Domain.Vacancy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("CorporateArena.Domain.ArticleComment", b =>
                {
                    b.HasOne("CorporateArena.Domain.Article", null)
                        .WithMany("Comments")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CorporateArena.Domain.ArticleLike", b =>
                {
                    b.HasOne("CorporateArena.Domain.Article", null)
                        .WithMany("ArticleLikes")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CorporateArena.Domain.BrainTeaserAnswer", b =>
                {
                    b.HasOne("CorporateArena.Domain.BrainTeaser", null)
                        .WithMany("BrainTeaserAnswers")
                        .HasForeignKey("BrainTeaserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CorporateArena.Domain.CommentLike", b =>
                {
                    b.HasOne("CorporateArena.Domain.ArticleComment", null)
                        .WithMany("CommentLikes")
                        .HasForeignKey("ArticleCommentID");
                });

            modelBuilder.Entity("CorporateArena.Domain.Privilege", b =>
                {
                    b.HasOne("CorporateArena.Domain.Role", null)
                        .WithMany("Privileges")
                        .HasForeignKey("RoleID");
                });

            modelBuilder.Entity("CorporateArena.Domain.TrafficComment", b =>
                {
                    b.HasOne("CorporateArena.Domain.TrafficUpdate", null)
                        .WithMany("TrafficUpdateComments")
                        .HasForeignKey("TrafficUpdateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CorporateArena.Domain.User", b =>
                {
                    b.HasOne("CorporateArena.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
