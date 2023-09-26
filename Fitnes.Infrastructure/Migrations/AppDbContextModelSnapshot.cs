﻿// <auto-generated />
using System;
using Fitnes.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Fitnes.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Fitnes.Domain.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 25, 14, 51, 39, 114, DateTimeKind.Utc).AddTicks(573),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ConsumerId1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("ConsumerId1");

                    b.HasIndex("ProductId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Consumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("JoinedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Consumer");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.ConsumerService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsumerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ConsumerId1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Days")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("ServicePrice")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("ConsumerId1");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ConsumerId1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MsgOrPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("ConsumerId1");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ConsumerId1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsSubmitted")
                        .HasColumnType("boolean");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("ConsumerId1");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("ProductType")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Days")
                        .HasColumnType("integer");

                    b.Property<DateTime>("JoinedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDay")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDay = new DateOnly(2002, 3, 16),
                            CreatedDate = new DateTime(2023, 9, 25, 14, 51, 39, 111, DateTimeKind.Utc).AddTicks(3745),
                            Email = "abduqodirovsarvar.2002@gmail.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            PasswordHash = "73l8gRjwLftklgfdXT+MdiMEjJwGPVMsyVxe16iYpk8=",
                            Phone = "+998932340316"
                        });
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Admin", b =>
                {
                    b.HasOne("Fitnes.Domain.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("Fitnes.Domain.Entities.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Card", b =>
                {
                    b.HasOne("Fitnes.Domain.Entities.Consumer", null)
                        .WithMany("Cards")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fitnes.Domain.Entities.Consumer", "Consumer")
                        .WithMany()
                        .HasForeignKey("ConsumerId1");

                    b.HasOne("Fitnes.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consumer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Consumer", b =>
                {
                    b.HasOne("Fitnes.Domain.Entities.Teacher", "Teacher")
                        .WithMany("Consumers")
                        .HasForeignKey("TeacherId");

                    b.HasOne("Fitnes.Domain.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("Fitnes.Domain.Entities.Consumer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.ConsumerService", b =>
                {
                    b.HasOne("Fitnes.Domain.Entities.Consumer", null)
                        .WithMany("Services")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fitnes.Domain.Entities.Consumer", "Consumer")
                        .WithMany()
                        .HasForeignKey("ConsumerId1");

                    b.Navigation("Consumer");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Message", b =>
                {
                    b.HasOne("Fitnes.Domain.Entities.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fitnes.Domain.Entities.Consumer", null)
                        .WithMany("Messages")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fitnes.Domain.Entities.Consumer", "Consumer")
                        .WithMany()
                        .HasForeignKey("ConsumerId1");

                    b.Navigation("Admin");

                    b.Navigation("Consumer");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Order", b =>
                {
                    b.HasOne("Fitnes.Domain.Entities.Consumer", null)
                        .WithMany("Orders")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fitnes.Domain.Entities.Consumer", "Consumer")
                        .WithMany()
                        .HasForeignKey("ConsumerId1");

                    b.HasOne("Fitnes.Domain.Entities.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consumer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Teacher", b =>
                {
                    b.HasOne("Fitnes.Domain.Entities.User", "UserTeacher")
                        .WithOne()
                        .HasForeignKey("Fitnes.Domain.Entities.Teacher", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserTeacher");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Consumer", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Messages");

                    b.Navigation("Orders");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Fitnes.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("Consumers");
                });
#pragma warning restore 612, 618
        }
    }
}
