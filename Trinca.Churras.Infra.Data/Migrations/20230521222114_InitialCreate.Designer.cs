﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trinca.Churras.Infra.Data;

#nullable disable

namespace Trinca.Churras.Infra.Data.Migrations
{
    [DbContext(typeof(ChurrascoContext))]
    [Migration("20230521222114_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trinca.Churras.Domain.Churrasco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("DataComemorativa")
                        .HasColumnType("date")
                        .HasColumnName("DataComemorativa");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Descricao");

                    b.Property<string>("ObservacaoAdicional")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ObservacaoAdicional");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("UpdatedBy");

                    b.Property<decimal?>("ValorAdicionalBebida")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorAdicionalBebida");

                    b.Property<decimal>("ValorSugeridoPorPessoa")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorSugeridoPorPessoa");

                    b.HasKey("Id");

                    b.ToTable("Churrasco", (string)null);
                });

            modelBuilder.Entity("Trinca.Churras.Domain.ChurrascoParticipante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("ChurrascoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<Guid>("ParticipanteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("ChurrascoId");

                    b.HasIndex("ParticipanteId");

                    b.ToTable("ChurrascoParticipante", (string)null);
                });

            modelBuilder.Entity("Trinca.Churras.Domain.Participante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Nome");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Participante", (string)null);
                });

            modelBuilder.Entity("Trinca.Churras.Domain.ChurrascoParticipante", b =>
                {
                    b.HasOne("Trinca.Churras.Domain.Churrasco", "Churrasco")
                        .WithMany("ChurrascoParticipantes")
                        .HasForeignKey("ChurrascoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trinca.Churras.Domain.Participante", "Participante")
                        .WithMany("ChurrascoParticipantes")
                        .HasForeignKey("ParticipanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Churrasco");

                    b.Navigation("Participante");
                });

            modelBuilder.Entity("Trinca.Churras.Domain.Churrasco", b =>
                {
                    b.Navigation("ChurrascoParticipantes");
                });

            modelBuilder.Entity("Trinca.Churras.Domain.Participante", b =>
                {
                    b.Navigation("ChurrascoParticipantes");
                });
#pragma warning restore 612, 618
        }
    }
}
