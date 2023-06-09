﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.Data;

#nullable disable

namespace ToDoApp.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230606152307_progressAsDouble")]
    partial class progressAsDouble
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoApp.Data.DTOs.MainTaskDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeadlineDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("PriorityLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Progress")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MainTask");
                });

            modelBuilder.Entity("ToDoApp.Data.DTOs.SubTaskDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MainTaskDTOId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainTaskDTOId");

                    b.ToTable("SubTask");
                });

            modelBuilder.Entity("ToDoApp.Data.DTOs.SubTaskDTO", b =>
                {
                    b.HasOne("ToDoApp.Data.DTOs.MainTaskDTO", null)
                        .WithMany("SubTasks")
                        .HasForeignKey("MainTaskDTOId");
                });

            modelBuilder.Entity("ToDoApp.Data.DTOs.MainTaskDTO", b =>
                {
                    b.Navigation("SubTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
