using AplicacionVentas.Shared.DTOs;
using AplicacionVentas.Shared.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionVentas.Server
{
    public class AplicacionVentasContext : IdentityDbContext
    {
        public DbSet<EntidadCliente> Clientes { get; set; }
        public DbSet<EntidadEmpleado> Empleados { get; set; }
        public DbSet<EntidadProducto> Productos { get; set; }
        public DbSet<EntidadProyecto> Proyectos { get; set; }
        public DbSet<EntidadVenta> Ventas { get; set; }
        public DbSet<EntidadEvidencia> Evidencias { get; set; }
        public DbSet<EntidadVentaTotal> VentasTotal { get; set; }

        public AplicacionVentasContext(DbContextOptions<AplicacionVentasContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var rolAdmin = new IdentityRole { Id = "61895af9-efc1-4a0a-b054-7bd9c884c11f", Name = "ADMIN", NormalizedName="ADMIN" };
            modelBuilder.Entity<IdentityRole>().HasData(rolAdmin);

            var rolVendedor = new IdentityRole { Id = "c71df716-43f7-4d8d-9862-bb1e53bdeab5", Name = "VENDEDOR", NormalizedName = "VENDEDOR" };
            modelBuilder.Entity<IdentityRole>().HasData(rolVendedor);

            modelBuilder.Entity<EntidadCliente>().HasData(
                new EntidadCliente { ClienteId = 1, NombreCliente = "Quaker State", Estatus= true }
                );

            modelBuilder.Entity<EntidadProyecto>().HasData(
                new EntidadProyecto { ProyectoId = 1, NombreProyecto = "Promotoria Quaker State - CDMX", Municipio = "Ciudad de Mexico", ClienteId = 1, Estatus = true },
                new EntidadProyecto { ProyectoId = 2, NombreProyecto = "Promotoria Quaker State - Monterrey", Municipio = "Monterrey", ClienteId = 1, Estatus = true }
                );

            modelBuilder.Entity<EntidadEmpleado>().HasData(
                new EntidadEmpleado { EmpleadoId = 1, NombreEmpleado = "ELSA VERONICA", ApPaterno = "BRAVO", ApMaterno = "DURAN", ProyectoId = 1, PuestoEmpleado = "Vendedor", Estatus = true },
                new EntidadEmpleado { EmpleadoId = 2, NombreEmpleado = "NADIA AMAYRANI", ApPaterno = "ALVARADO", ApMaterno = "RODRIGUEZ", ProyectoId = 1, PuestoEmpleado = "Vendedor", Estatus = true },
                new EntidadEmpleado { EmpleadoId = 3, NombreEmpleado = "MARIA DE JESUS", ApPaterno = "CARREON", ApMaterno = "ARELLANO", ProyectoId = 2, PuestoEmpleado = "Vendedor", Estatus = true }
                //new EntidadEmpleado { EmpleadoId = 4, NombreEmpleado = "MARIA DE JESUS", ApPaterno = "CARREON", ApMaterno = "ARELLANO", ProyectoId = 2, PuestoEmpleado = "Vendedor", Estatus = true },
                //new EntidadEmpleado { EmpleadoId = 5, NombreEmpleado = "MARIA DE JESUS", ApPaterno = "CARREON", ApMaterno = "ARELLANO", ProyectoId = 2, PuestoEmpleado = "Vendedor", Estatus = true },
                //new EntidadEmpleado { EmpleadoId = 6, NombreEmpleado = "MARIA DE JESUS", ApPaterno = "CARREON", ApMaterno = "ARELLANO", ProyectoId = 2, PuestoEmpleado = "Vendedor", Estatus = true },
                //new EntidadEmpleado { EmpleadoId = 7, NombreEmpleado = "MARIA DE JESUS", ApPaterno = "CARREON", ApMaterno = "ARELLANO", ProyectoId = 2, PuestoEmpleado = "Vendedor", Estatus = true },
                //new EntidadEmpleado { EmpleadoId = 8, NombreEmpleado = "MARIA DE JESUS", ApPaterno = "CARREON", ApMaterno = "ARELLANO", ProyectoId = 2, PuestoEmpleado = "Vendedor", Estatus = true },
                //new EntidadEmpleado { EmpleadoId = 9, NombreEmpleado = "MARIA DE JESUS", ApPaterno = "CARREON", ApMaterno = "ARELLANO", ProyectoId = 2, PuestoEmpleado = "Vendedor", Estatus = true },
                //new EntidadEmpleado { EmpleadoId = 10, NombreEmpleado = "MARIA DE JESUS", ApPaterno = "CARREON", ApMaterno = "ARELLANO", ProyectoId = 2, PuestoEmpleado = "Vendedor", Estatus = true },
                //new EntidadEmpleado { EmpleadoId = 11, NombreEmpleado = "MARIA DE JESUS", ApPaterno = "CARREON", ApMaterno = "ARELLANO", ProyectoId = 2, PuestoEmpleado = "Vendedor", Estatus = true },
                //new EntidadEmpleado { EmpleadoId = 13, NombreEmpleado = "MARIA DE JESUS", ApPaterno = "CARREON", ApMaterno = "ARELLANO", ProyectoId = 2, PuestoEmpleado = "Vendedor", Estatus = true }
                );

            modelBuilder.Entity<EntidadProducto>().HasData(
                new EntidadProducto { ProductoId = 1, NombreProducto = "QS MAXIMA VISCOSIDAD SAE 25W50 CF4", DescripcionProducto = "25W50", Marca = "Quaker State", Estatus = true },
                new EntidadProducto { ProductoId = 2, NombreProducto = "QS GREEN OIL SAE 140", DescripcionProducto = "GREEN OIL", Marca = "Quaker State", Estatus = true },
                new EntidadProducto { ProductoId = 3, NombreProducto = "ANTICONGELANTE CONCENTRACION IDEAL", DescripcionProducto = "Anticongelante", Marca = "Quaker State", Estatus = true }
                );

            modelBuilder.Entity<EntidadVenta>().HasData(
                new EntidadVenta { VentaId = 1, EmpleadoId = 1, NombreProducto = "QS MAXIMA VISCOSIDAD SAE 25W50 CF4", DescripcionProducto = "25W50", Cantidad = 3, FechaVenta = DateTime.Now, FechaCaptura = DateTime.Now },
                new EntidadVenta { VentaId = 2, EmpleadoId = 2, NombreProducto = "QS GREEN OIL SAE 140", DescripcionProducto = "GREEN OIL", Cantidad = 3, FechaVenta = DateTime.Now, FechaCaptura = DateTime.Now },
                new EntidadVenta { VentaId = 3, EmpleadoId = 3, NombreProducto = "ANTICONGELANTE CONCENTRACION IDEAL", DescripcionProducto = "Anticongelante", Cantidad = 3, FechaVenta = DateTime.Now, FechaCaptura = DateTime.Now }
                );

        }

    }
}
