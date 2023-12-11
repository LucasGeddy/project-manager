﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task_manager_challenge.Infrastructure;

#nullable disable

namespace project_manager.Infrastructure.Migrations
{
    [DbContext(typeof(TaskManagerDbContext))]
    [Migration("20231210220856_LimitStringSizes_Priority_Status")]
    partial class LimitStringSizes_Priority_Status
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("project_manager.Domain.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.WorkTask", b =>
                {
                    b.Property<int>("WorkTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkTaskId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("WorkTaskId");

                    b.HasIndex("ProjectId");

                    b.ToTable("WorkTasks");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.WorkTaskComment", b =>
                {
                    b.Property<int>("WorkTaskCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkTaskCommentId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WorkTaskId")
                        .HasColumnType("int");

                    b.HasKey("WorkTaskCommentId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkTaskId");

                    b.ToTable("WorkTaskComments");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.WorkTaskUpdateHistory", b =>
                {
                    b.Property<int>("WorkTaskUpdateHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkTaskUpdateHistoryId"));

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WorkTaskId")
                        .HasColumnType("int");

                    b.HasKey("WorkTaskUpdateHistoryId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkTaskId");

                    b.ToTable("WorkTaskUpdateHistories");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.Project", b =>
                {
                    b.HasOne("project_manager.Domain.Entities.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.WorkTask", b =>
                {
                    b.HasOne("project_manager.Domain.Entities.Project", "Project")
                        .WithMany("WorkTasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.WorkTaskComment", b =>
                {
                    b.HasOne("project_manager.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("project_manager.Domain.Entities.WorkTask", "WorkTask")
                        .WithMany("Comments")
                        .HasForeignKey("WorkTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WorkTask");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.WorkTaskUpdateHistory", b =>
                {
                    b.HasOne("project_manager.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("project_manager.Domain.Entities.WorkTask", "WorkTask")
                        .WithMany("UpdateHistory")
                        .HasForeignKey("WorkTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WorkTask");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.Project", b =>
                {
                    b.Navigation("WorkTasks");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.User", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("project_manager.Domain.Entities.WorkTask", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("UpdateHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
