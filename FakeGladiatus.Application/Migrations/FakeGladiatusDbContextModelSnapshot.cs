﻿// <auto-generated />
using System;
using FakeGladiatus.Application.Entities.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FakeGladiatus.Application.Migrations
{
    [DbContext(typeof(FakeGladiatusDbContext))]
    partial class FakeGladiatusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FakeGladiatus.Application.Entities.DbEntities.CharacterDbEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Exp")
                        .HasColumnType("int");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("FakeGladiatus.Application.Entities.DbEntities.NotificationDbEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttackerCharId")
                        .HasColumnType("int");

                    b.Property<int?>("AttackerUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FightTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int?>("TargetCharId")
                        .HasColumnType("int");

                    b.Property<int?>("TargetUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttackerCharId");

                    b.HasIndex("AttackerUserId");

                    b.HasIndex("TargetCharId");

                    b.HasIndex("TargetUserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("FakeGladiatus.Application.Entities.DbEntities.UserDbEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FakeGladiatus.Application.Entities.DbEntities.CharacterDbEntity", b =>
                {
                    b.HasOne("FakeGladiatus.Application.Entities.DbEntities.UserDbEntity", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FakeGladiatus.Application.Entities.DbEntities.NotificationDbEntity", b =>
                {
                    b.HasOne("FakeGladiatus.Application.Entities.DbEntities.CharacterDbEntity", "AttackerChar")
                        .WithMany()
                        .HasForeignKey("AttackerCharId");

                    b.HasOne("FakeGladiatus.Application.Entities.DbEntities.UserDbEntity", "AttackerUser")
                        .WithMany()
                        .HasForeignKey("AttackerUserId");

                    b.HasOne("FakeGladiatus.Application.Entities.DbEntities.CharacterDbEntity", "TargetChar")
                        .WithMany()
                        .HasForeignKey("TargetCharId");

                    b.HasOne("FakeGladiatus.Application.Entities.DbEntities.UserDbEntity", "TargetUser")
                        .WithMany()
                        .HasForeignKey("TargetUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
