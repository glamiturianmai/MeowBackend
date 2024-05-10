﻿// <auto-generated />
using System;
using MeowBackend.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeowBackend.DataLayer.Migrations
{
    [DbContext(typeof(MeowDBContext))]
    [Migration("20240504103529_AddDogTable")]
    partial class AddDogTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MeowBackend.Core.Dtos.CatDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("CanMeow")
                        .HasColumnType("boolean")
                        .HasColumnName("can_meow");

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cat_name");

                    b.Property<int>("CatType")
                        .HasColumnType("integer")
                        .HasColumnName("cat_type");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("pk_cats");

                    b.HasIndex("OwnerId")
                        .HasDatabaseName("ix_cats_owner_id");

                    b.ToTable("cats", (string)null);
                });

            modelBuilder.Entity("MeowBackend.Core.Dtos.DogDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_dogs");

                    b.ToTable("dogs", (string)null);
                });

            modelBuilder.Entity("MeowBackend.Core.Dtos.PersonDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("CanHaveCat")
                        .HasColumnType("boolean")
                        .HasColumnName("can_have_cat");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_persons");

                    b.ToTable("persons", (string)null);
                });

            modelBuilder.Entity("MeowBackend.Core.Dtos.CatDto", b =>
                {
                    b.HasOne("MeowBackend.Core.Dtos.PersonDto", "Owner")
                        .WithMany("Cats")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("fk_cats_persons_owner_id");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MeowBackend.Core.Dtos.PersonDto", b =>
                {
                    b.Navigation("Cats");
                });
#pragma warning restore 612, 618
        }
    }
}
