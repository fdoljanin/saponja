﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Saponja.Data.Entities;

namespace Saponja.Data.Migrations
{
    [DbContext(typeof(SaponjaDbContext))]
    partial class SaponjaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Saponja.Data.Entities.Models.Adopter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("ConfirmationLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasConfirmedMail")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motivation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oib")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("Adopters");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("HasBeenAdopted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDangerous")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGoodWithCats")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGoodWithChildren")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGoodWithDogs")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequiredExperience")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSterelised")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePhotoLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShelterId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShelterId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.AnimalPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("AnimalPhotos");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasBeenOpened")
                        .HasColumnType("bit");

                    b.Property<string>("Hyperlink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("Role");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Admin", b =>
                {
                    b.HasBaseType("Saponja.Data.Entities.Models.User");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Shelter", b =>
                {
                    b.HasBaseType("Saponja.Data.Entities.Models.User");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentationLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oib")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Adopter", b =>
                {
                    b.HasOne("Saponja.Data.Entities.Models.Animal", "Animal")
                        .WithMany("Adopters")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Animal", b =>
                {
                    b.HasOne("Saponja.Data.Entities.Models.Shelter", "Shelter")
                        .WithMany("Animals")
                        .HasForeignKey("ShelterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Shelter");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.AnimalPhoto", b =>
                {
                    b.HasOne("Saponja.Data.Entities.Models.Animal", "Animal")
                        .WithMany("AnimalPhotos")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Notification", b =>
                {
                    b.HasOne("Saponja.Data.Entities.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Post", b =>
                {
                    b.HasOne("Saponja.Data.Entities.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Shelter", b =>
                {
                    b.OwnsOne("Saponja.Data.Entities.Models.Geolocation", "Geolocation", b1 =>
                        {
                            b1.Property<int>("ShelterId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<float>("Latitude")
                                .HasColumnType("real");

                            b1.Property<float>("Longitude")
                                .HasColumnType("real");

                            b1.HasKey("ShelterId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("ShelterId");
                        });

                    b.Navigation("Geolocation");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Animal", b =>
                {
                    b.Navigation("Adopters");

                    b.Navigation("AnimalPhotos");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.User", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Saponja.Data.Entities.Models.Shelter", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
