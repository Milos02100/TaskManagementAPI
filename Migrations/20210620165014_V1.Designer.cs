﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagmentApi.Models;

namespace TaskManagmentApi.Migrations
{
    [DbContext(typeof(TaskManagmentContext))]
    [Migration("20210620165014_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskManagmentApi.Models.Board", b =>
                {
                    b.Property<int>("BoardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BoardID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Title");

                    b.HasKey("BoardID");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("TaskManagmentApi.Models.Developer", b =>
                {
                    b.Property<int>("DeveloperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DeveloperID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EmailAddress");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Gender");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("DeveloperID");

                    b.ToTable("Developer");
                });

            modelBuilder.Entity("TaskManagmentApi.Models.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TaskID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoardID")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Date");

                    b.Property<int?>("DeveloperID")
                        .HasColumnType("int");

                    b.Property<bool>("Important")
                        .HasColumnType("bit")
                        .HasColumnName("Important");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Note");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.HasKey("TaskID");

                    b.HasIndex("BoardID");

                    b.HasIndex("DeveloperID");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("TaskManagmentApi.Models.Task", b =>
                {
                    b.HasOne("TaskManagmentApi.Models.Board", "Board")
                        .WithMany("Tasks")
                        .HasForeignKey("BoardID");

                    b.HasOne("TaskManagmentApi.Models.Developer", "Developer")
                        .WithMany("Tasks")
                        .HasForeignKey("DeveloperID");

                    b.Navigation("Board");

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("TaskManagmentApi.Models.Board", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskManagmentApi.Models.Developer", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}