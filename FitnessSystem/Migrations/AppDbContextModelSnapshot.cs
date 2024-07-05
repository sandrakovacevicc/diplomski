﻿// <auto-generated />
using System;
using FitnessSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessSystem.Presentation.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.MembershipPackage", b =>
                {
                    b.Property<int>("MembershipPackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembershipPackageId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfMonths")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("MembershipPackageId");

                    b.ToTable("MembershipPackages");
                });

            modelBuilder.Entity("Core.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<string>("ClientJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("ReservationId");

                    b.HasIndex("ClientJMBG");

                    b.HasIndex("SessionId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Core.Entities.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Core.Entities.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SessionId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<string>("TrainerJMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TrainingProgramId")
                        .HasColumnType("int");

                    b.HasKey("SessionId");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.HasIndex("TrainerJMBG");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Core.Entities.TrainingProgram", b =>
                {
                    b.Property<int>("TrainingProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingProgramId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingDurationInMinutes")
                        .HasColumnType("int");

                    b.Property<string>("TrainingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingProgramId");

                    b.ToTable("TrainingPrograms");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JMBG");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Core.Entities.Admin", b =>
                {
                    b.HasBaseType("Core.Entities.User");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.HasBaseType("Core.Entities.User");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MembershipPackageId")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("MembershipPackageId");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Trainer", b =>
                {
                    b.HasBaseType("Core.Entities.User");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Trainers", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Reservation", b =>
                {
                    b.HasOne("Core.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientJMBG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Core.Entities.Session", b =>
                {
                    b.HasOne("Core.Entities.Room", "Room")
                        .WithOne("Session")
                        .HasForeignKey("Core.Entities.Session", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Trainer", "Trainer")
                        .WithMany("Sessions")
                        .HasForeignKey("TrainerJMBG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TrainingProgram", "TrainingProgram")
                        .WithMany("Sessions")
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Trainer");

                    b.Navigation("TrainingProgram");
                });

            modelBuilder.Entity("Core.Entities.Admin", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Core.Entities.Admin", "JMBG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Core.Entities.Client", "JMBG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.MembershipPackage", "MembershipPackage")
                        .WithMany("Clients")
                        .HasForeignKey("MembershipPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipPackage");
                });

            modelBuilder.Entity("Core.Entities.Trainer", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Core.Entities.Trainer", "JMBG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.MembershipPackage", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Core.Entities.Room", b =>
                {
                    b.Navigation("Session")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.TrainingProgram", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Core.Entities.Trainer", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
