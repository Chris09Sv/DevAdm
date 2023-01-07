﻿// <auto-generated />
using System;
using DevControl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevControl.Migrations
{
    [DbContext(typeof(DevContext))]
    [Migration("20230106155332_resolve7")]
    partial class resolve7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DevControl.Models.Establecimientos.TbCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbCategorias");
                });

            modelBuilder.Entity("DevControl.Models.Establecimientos.TbEstablecimientos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Activacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Area")
                        .HasColumnType("int");

                    b.Property<int?>("Capacidad")
                        .HasColumnType("int");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Centro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Creacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Distrito")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int?>("IdViepi")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InActivacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Institucion")
                        .HasColumnType("int");

                    b.Property<int>("Laboratorio")
                        .HasColumnType("int");

                    b.Property<int>("Municipio")
                        .HasColumnType("int");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<int>("Provincia")
                        .HasColumnType("int");

                    b.Property<string>("Sat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sector")
                        .HasColumnType("int");

                    b.Property<int>("Subsector")
                        .HasColumnType("int");

                    b.Property<int>("Usuario")
                        .HasColumnType("int");

                    b.Property<int>("prueba")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbEstablecimientos");
                });

            modelBuilder.Entity("DevControl.Models.Establecimientos.TbInstitucion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Institucion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbInstitucion");
                });

            modelBuilder.Entity("DevControl.Models.Establecimientos.TbNivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbNivel");
                });

            modelBuilder.Entity("DevControl.Models.Establecimientos.TbSubsector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Subsector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbSubsectors");
                });

            modelBuilder.Entity("DevControl.Models.Establecimientos.vmEstablecimientos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Centro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distrito")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institucion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Laboratorio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nivel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subsector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Viepi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prueba")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("vmEstablecimientos");
                });

            modelBuilder.Entity("DevControl.Models.TbDistrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("distrito")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("municipio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbDistritos");
                });

            modelBuilder.Entity("DevControl.Models.TbMunicipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("municipio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbMunicipios");
                });

            modelBuilder.Entity("DevControl.Models.TbProvincias", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tbProvincias");
                });

            modelBuilder.Entity("DevControl.Models.TbSector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("barrio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("distrito")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("municipio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbSectores");
                });

            modelBuilder.Entity("DevControl.Models.UsuariosViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Activo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Centro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institucion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsuariosViewModel");
                });
#pragma warning restore 612, 618
        }
    }
}
