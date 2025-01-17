﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGE.Infra.Data.Contexto;

#nullable disable

namespace SGE.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250105172112_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SGE.Dominio.Entidades.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Enderecos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bairro = "Centro",
                            Cep = "12345-678",
                            Cidade = "Cidade Exemplo",
                            Complemento = "Apto 101",
                            Logradouro = "Rua Principal",
                            Numero = "100",
                            Uf = "SP",
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            Bairro = "Bairro Exemplo",
                            Cep = "98765-432",
                            Cidade = "Cidade Exemplo",
                            Complemento = "Casa 20",
                            Logradouro = "Avenida Secundária",
                            Numero = "200",
                            Uf = "RJ",
                            UsuarioId = 2
                        });
                });

            modelBuilder.Entity("SGE.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UsuarioLogin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataCadastro = new DateTime(2025, 1, 5, 17, 21, 11, 4, DateTimeKind.Utc).AddTicks(470),
                            Nome = "Elias Santos",
                            Senha = "123456",
                            UsuarioLogin = "EliasS"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataCadastro = new DateTime(2025, 1, 5, 17, 21, 11, 4, DateTimeKind.Utc).AddTicks(1197),
                            Nome = "Nilton Santos",
                            Senha = "654321",
                            UsuarioLogin = "NiltonP"
                        });
                });

            modelBuilder.Entity("SGE.Dominio.Entidades.Endereco", b =>
                {
                    b.HasOne("SGE.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("Enderecos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SGE.Dominio.Entidades.Usuario", b =>
                {
                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
