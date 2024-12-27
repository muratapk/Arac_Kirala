﻿// <auto-generated />
using System;
using Arac_Kirala.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Arac_Kirala.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Arac_Kirala.Models.Araclar", b =>
                {
                    b.Property<int>("AracId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AracId"));

                    b.Property<string>("AracName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Depozito")
                        .HasColumnType("int");

                    b.Property<int?>("KmLimit")
                        .HasColumnType("int");

                    b.Property<int?>("Koltuk")
                        .HasColumnType("int");

                    b.Property<string>("Konum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MarkaId")
                        .HasColumnType("int");

                    b.Property<int?>("MarkalarMarkaId")
                        .HasColumnType("int");

                    b.Property<int?>("ModellerId")
                        .HasColumnType("int");

                    b.Property<string>("Resim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VitesId")
                        .HasColumnType("int");

                    b.Property<int?>("YakitId")
                        .HasColumnType("int");

                    b.HasKey("AracId");

                    b.HasIndex("MarkalarMarkaId");

                    b.HasIndex("ModellerId");

                    b.HasIndex("VitesId");

                    b.HasIndex("YakitId");

                    b.ToTable("Araclars");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Markalar", b =>
                {
                    b.Property<int>("MarkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkaId"));

                    b.Property<string>("MarkaAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarkaId");

                    b.ToTable("Markalar");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Modeller", b =>
                {
                    b.Property<int>("ModellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModellerId"));

                    b.Property<string>("ModellerAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModellerId");

                    b.ToTable("Modellers");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Musteriler", b =>
                {
                    b.Property<int>("MusteriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MusteriId"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CepTel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusterAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusteriKul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusteriSifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusteriId");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Odemeler", b =>
                {
                    b.Property<int>("OdemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OdemeId"));

                    b.Property<int>("AracId")
                        .HasColumnType("int");

                    b.Property<int?>("AraclarAracId")
                        .HasColumnType("int");

                    b.Property<int>("MusteriId")
                        .HasColumnType("int");

                    b.Property<int?>("MusterilerMusteriId")
                        .HasColumnType("int");

                    b.Property<int>("RezervasyonId")
                        .HasColumnType("int");

                    b.HasKey("OdemeId");

                    b.HasIndex("AraclarAracId");

                    b.HasIndex("MusterilerMusteriId");

                    b.HasIndex("RezervasyonId");

                    b.ToTable("Odemeler");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Rezervasyon", b =>
                {
                    b.Property<int>("RezervasyonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RezervasyonId"));

                    b.Property<string>("AlisSaati")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlisTarihi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirakSaati")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirakTarih")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RezervasyonId");

                    b.ToTable("Rezervasyons");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Vites", b =>
                {
                    b.Property<int>("VitesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VitesId"));

                    b.Property<string>("VitesAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VitesId");

                    b.ToTable("Vites");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Yakit", b =>
                {
                    b.Property<int>("YakitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YakitId"));

                    b.Property<string>("YakitAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YakitId");

                    b.ToTable("Yakit");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Araclar", b =>
                {
                    b.HasOne("Arac_Kirala.Models.Markalar", "Markalar")
                        .WithMany("Araclars")
                        .HasForeignKey("MarkalarMarkaId");

                    b.HasOne("Arac_Kirala.Models.Modeller", "Modeller")
                        .WithMany("Araclars")
                        .HasForeignKey("ModellerId");

                    b.HasOne("Arac_Kirala.Models.Vites", "Vites")
                        .WithMany("Araclars")
                        .HasForeignKey("VitesId");

                    b.HasOne("Arac_Kirala.Models.Yakit", "Yakit")
                        .WithMany("Araclars")
                        .HasForeignKey("YakitId");

                    b.Navigation("Markalar");

                    b.Navigation("Modeller");

                    b.Navigation("Vites");

                    b.Navigation("Yakit");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Odemeler", b =>
                {
                    b.HasOne("Arac_Kirala.Models.Araclar", "Araclar")
                        .WithMany("Odemelers")
                        .HasForeignKey("AraclarAracId");

                    b.HasOne("Arac_Kirala.Models.Musteriler", "Musteriler")
                        .WithMany("Odemelers")
                        .HasForeignKey("MusterilerMusteriId");

                    b.HasOne("Arac_Kirala.Models.Rezervasyon", "Rezervasyon")
                        .WithMany("Odemelers")
                        .HasForeignKey("RezervasyonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Araclar");

                    b.Navigation("Musteriler");

                    b.Navigation("Rezervasyon");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Araclar", b =>
                {
                    b.Navigation("Odemelers");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Markalar", b =>
                {
                    b.Navigation("Araclars");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Modeller", b =>
                {
                    b.Navigation("Araclars");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Musteriler", b =>
                {
                    b.Navigation("Odemelers");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Rezervasyon", b =>
                {
                    b.Navigation("Odemelers");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Vites", b =>
                {
                    b.Navigation("Araclars");
                });

            modelBuilder.Entity("Arac_Kirala.Models.Yakit", b =>
                {
                    b.Navigation("Araclars");
                });
#pragma warning restore 612, 618
        }
    }
}