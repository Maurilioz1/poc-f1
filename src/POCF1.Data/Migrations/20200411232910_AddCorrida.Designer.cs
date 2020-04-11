﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POCF1.Data.Context;

namespace POCF1.Data.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20200411232910_AddCorrida")]
    partial class AddCorrida
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("POCF1.Business.Models.Corrida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCorrida")
                        .HasColumnType("datetime");

                    b.Property<string>("NomeCircuito")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Piloto1")
                        .HasColumnType("int");

                    b.Property<int>("Piloto2")
                        .HasColumnType("int");

                    b.Property<int>("Piloto3")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tempo1")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Tempo2")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Tempo3")
                        .HasColumnType("datetime");

                    b.Property<int>("TrajetoTotalCircuito")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Corridas");
                });

            modelBuilder.Entity("POCF1.Business.Models.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AerodinamicaCarro")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("PotenciaCarro")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("POCF1.Business.Models.Piloto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EquipeId");

                    b.Property<int>("NivelExperiencia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PosicaoLargada")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeParadas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.ToTable("Pilotos");
                });

            modelBuilder.Entity("POCF1.Business.Models.Piloto", b =>
                {
                    b.HasOne("POCF1.Business.Models.Equipe", "Equipe")
                        .WithMany("Pilotos")
                        .HasForeignKey("EquipeId");
                });
#pragma warning restore 612, 618
        }
    }
}
