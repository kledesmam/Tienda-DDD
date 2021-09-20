﻿// <auto-generated />
using System;
using Infraestructura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructura.Migrations
{
    [DbContext(typeof(EvertecContext))]
    [Migration("20210919211751_InsertRowsPasarela")]
    partial class InsertRowsPasarela
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entidades.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Celular")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("IdParametroDetalle")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("NumeroIdentificacion")
                        .HasColumnType("float");

                    b.HasKey("IdCliente");

                    b.HasIndex("IdParametroDetalle");

                    b.ToTable("Cliente");

                    b.HasData(
                        new
                        {
                            IdCliente = 1,
                            Apellido = "Ledesma",
                            Celular = "3002211445",
                            Email = "ingcaledesma@gmail.com",
                            IdParametroDetalle = 1,
                            Nombre = "Carlos",
                            NumeroIdentificacion = 94557038.0
                        });
                });

            modelBuilder.Entity("Domain.Entidades.Orden", b =>
                {
                    b.Property<int>("IdOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdParametroDetalle")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<string>("ReferenciaPago")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RequestId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UrlPago")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("IdOrden");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdParametroDetalle");

                    b.HasIndex("IdProducto");

                    b.ToTable("Orden");
                });

            modelBuilder.Entity("Domain.Entidades.OrdenLog", b =>
                {
                    b.Property<int>("IdOrdenLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdOrden")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciaPago")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RequestId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UrlPago")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdOrdenLog");

                    b.HasIndex("IdOrden");

                    b.ToTable("OrdenLog");
                });

            modelBuilder.Entity("Domain.Entidades.Parametro", b =>
                {
                    b.Property<int>("IdParametro")
                        .HasColumnType("int");

                    b.Property<string>("Etiqueta")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdParametro");

                    b.ToTable("Parametro");

                    b.HasData(
                        new
                        {
                            IdParametro = 1,
                            Etiqueta = "TIPOS-DOCUMENTOS",
                            Nombre = "Tipos de Documento de identidad"
                        },
                        new
                        {
                            IdParametro = 2,
                            Etiqueta = "ESTADOS-ORDEN",
                            Nombre = "Estado Orden"
                        },
                        new
                        {
                            IdParametro = 3,
                            Etiqueta = "PASARELA-PAGOS",
                            Nombre = "Parametros pasarela pagos"
                        });
                });

            modelBuilder.Entity("Domain.Entidades.ParametroDetalle", b =>
                {
                    b.Property<int>("IdParametroDetalle")
                        .HasColumnType("int");

                    b.Property<string>("Etiqueta")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdParametro")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ValorExterno")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdParametroDetalle");

                    b.HasIndex("IdParametro");

                    b.ToTable("ParametroDetalle");

                    b.HasData(
                        new
                        {
                            IdParametroDetalle = 1,
                            Etiqueta = "CC",
                            IdParametro = 1,
                            Valor = "Cédula Ciudadanía",
                            ValorExterno = "CC"
                        },
                        new
                        {
                            IdParametroDetalle = 2,
                            Etiqueta = "CE",
                            IdParametro = 1,
                            Valor = "Cédula Extranjería",
                            ValorExterno = "CE"
                        },
                        new
                        {
                            IdParametroDetalle = 3,
                            Etiqueta = "TI",
                            IdParametro = 1,
                            Valor = "Tarjeta de Identidad",
                            ValorExterno = "TI"
                        },
                        new
                        {
                            IdParametroDetalle = 4,
                            Etiqueta = "NIT",
                            IdParametro = 1,
                            Valor = "Número de Identificación Tributaria",
                            ValorExterno = "TI"
                        },
                        new
                        {
                            IdParametroDetalle = 5,
                            Etiqueta = "ESTADO-CREATED",
                            IdParametro = 2,
                            Valor = "CREATED",
                            ValorExterno = "CREATED"
                        },
                        new
                        {
                            IdParametroDetalle = 6,
                            Etiqueta = "ESTADO-PAYED",
                            IdParametro = 2,
                            Valor = "PAYED",
                            ValorExterno = "PAYED"
                        },
                        new
                        {
                            IdParametroDetalle = 7,
                            Etiqueta = "ESTADO-REJECTED",
                            IdParametro = 2,
                            Valor = "REJECTED",
                            ValorExterno = "REJECTED"
                        },
                        new
                        {
                            IdParametroDetalle = 8,
                            Etiqueta = "PASARELA-LOGIN",
                            IdParametro = 3,
                            Valor = "6dd490faf9cb87a9862245da41170ff2",
                            ValorExterno = ""
                        },
                        new
                        {
                            IdParametroDetalle = 9,
                            Etiqueta = "PASARELA-TRANKEY",
                            IdParametro = 3,
                            Valor = " 024h1IlD",
                            ValorExterno = ""
                        },
                        new
                        {
                            IdParametroDetalle = 10,
                            Etiqueta = "PASARELA-URL-BASE",
                            IdParametro = 3,
                            Valor = "https://test.placetopay.com/redirection/api/session/",
                            ValorExterno = ""
                        },
                        new
                        {
                            IdParametroDetalle = 11,
                            Etiqueta = "PASARELA-LOCALE",
                            IdParametro = 3,
                            Valor = "en_CO",
                            ValorExterno = ""
                        },
                        new
                        {
                            IdParametroDetalle = 12,
                            Etiqueta = "PASARELA-CURRENCY",
                            IdParametro = 3,
                            Valor = "COP",
                            ValorExterno = ""
                        },
                        new
                        {
                            IdParametroDetalle = 13,
                            Etiqueta = "PASARELA-DIAS-EXPIRA",
                            IdParametro = 3,
                            Valor = "5",
                            ValorExterno = ""
                        },
                        new
                        {
                            IdParametroDetalle = 14,
                            Etiqueta = "PASARELA-AGENTE",
                            IdParametro = 3,
                            Valor = "PlacetoPay Sandbox",
                            ValorExterno = ""
                        },
                        new
                        {
                            IdParametroDetalle = 15,
                            Etiqueta = "PASARELA-URL-RETORNO",
                            IdParametro = 3,
                            Valor = "https://localhost:44342/api/orden",
                            ValorExterno = ""
                        });
                });

            modelBuilder.Entity("Domain.Entidades.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.HasKey("IdProducto");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            IdProducto = 1,
                            Codigo = "001",
                            Nombre = "Producto Pruebas",
                            ValorUnitario = 180000.0
                        });
                });

            modelBuilder.Entity("Domain.Entidades.Cliente", b =>
                {
                    b.HasOne("Domain.Entidades.ParametroDetalle", "TipoIdentificacion")
                        .WithMany()
                        .HasForeignKey("IdParametroDetalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoIdentificacion");
                });

            modelBuilder.Entity("Domain.Entidades.Orden", b =>
                {
                    b.HasOne("Domain.Entidades.Cliente", "Cliente")
                        .WithMany("Ordens")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.ParametroDetalle", "Estado")
                        .WithMany()
                        .HasForeignKey("IdParametroDetalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Producto", "Producto")
                        .WithMany("Ordens")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Estado");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Domain.Entidades.OrdenLog", b =>
                {
                    b.HasOne("Domain.Entidades.Orden", "Orden")
                        .WithMany("OrdenLogs")
                        .HasForeignKey("IdOrden")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orden");
                });

            modelBuilder.Entity("Domain.Entidades.ParametroDetalle", b =>
                {
                    b.HasOne("Domain.Entidades.Parametro", "Parametro")
                        .WithMany("parametroDetalles")
                        .HasForeignKey("IdParametro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parametro");
                });

            modelBuilder.Entity("Domain.Entidades.Cliente", b =>
                {
                    b.Navigation("Ordens");
                });

            modelBuilder.Entity("Domain.Entidades.Orden", b =>
                {
                    b.Navigation("OrdenLogs");
                });

            modelBuilder.Entity("Domain.Entidades.Parametro", b =>
                {
                    b.Navigation("parametroDetalles");
                });

            modelBuilder.Entity("Domain.Entidades.Producto", b =>
                {
                    b.Navigation("Ordens");
                });
#pragma warning restore 612, 618
        }
    }
}
