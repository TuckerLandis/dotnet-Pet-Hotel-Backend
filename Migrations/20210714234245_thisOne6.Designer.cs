﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using pet_hotel.Models;

namespace dotnet_bakery.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210714234245_thisOne6")]
    partial class thisOne6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("pet_hotel.Pet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PetOwnerid")
                        .HasColumnType("integer");

                    b.Property<int>("breed")
                        .HasColumnType("integer");

                    b.Property<DateTime>("checkedinAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("PetOwnerid");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("pet_hotel.PetOwner", b =>
                {
                    b.Property<int>("petOwnerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("emailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("petOwnerid");

                    b.ToTable("PetOwners");
                });

            modelBuilder.Entity("pet_hotel.Pet", b =>
                {
                    b.HasOne("pet_hotel.PetOwner", "petOwner")
                        .WithMany("PetListForOwner")
                        .HasForeignKey("PetOwnerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("petOwner");
                });

            modelBuilder.Entity("pet_hotel.PetOwner", b =>
                {
                    b.Navigation("PetListForOwner");
                });
#pragma warning restore 612, 618
        }
    }
}
