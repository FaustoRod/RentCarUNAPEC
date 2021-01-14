using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Core.Models.Indentity;

namespace RentCarUnapec.Data
{
    public class RentCarDbContext:IdentityDbContext<RentCarUser>
    {
        public static readonly ILoggerFactory _LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        public RentCarDbContext(DbContextOptions<RentCarDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Seed Data
            modelBuilder.Entity<FuelType>().HasData(
                    new FuelType { Id = 1, Description = "Gasolina", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new FuelType { Id = 2, Description = "Diesel", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new FuelType { Id = 3, Description = "GLP", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );

            modelBuilder.Entity<VehicleState>().HasData(
                    new VehicleState { Id = 1, Description = "Disponible", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new VehicleState { Id = 2, Description = "En Espera de Chequeo", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new VehicleState { Id = 3, Description = "Chequeo Completado", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new VehicleState { Id = 4, Description = "Rentado", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new VehicleState { Id = 5, Description = "En Espera de Entrega", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );

            modelBuilder.Entity<RentState>().HasData(
                    new RentState { Id = 1, Description = "Activo", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new RentState { Id = 2, Description = "En Espera de Chequeo", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new RentState { Id = 3, Description = "En Espera de Entrega", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new RentState { Id = 4, Description = "Entregado", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new RentState { Id = 5, Description = "Cancelado", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new RentState { Id = 6, Description = "Chequeado", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );

            modelBuilder.Entity<ClientType>().HasData(
                    new ClientType { Id = 1, Description = "Persona", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new ClientType { Id = 2, Description = "Empresa", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );

            modelBuilder.Entity<FuelTankState>().HasData(
                    new FuelTankState { Id = 1, Description = "Full", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new FuelTankState { Id = 2, Description = "Medio", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new FuelTankState { Id = 3, Description = "Vacio", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );

            modelBuilder.Entity<IdentificationType>().HasData(
                    new IdentificationType { Id = 1, Description = "Cedula", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new IdentificationType { Id = 2, Description = "RNC", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new IdentificationType { Id = 3, Description = "Pasaporte", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = false }
                );

            modelBuilder.Entity<ShiftType>().HasData(
                    new ShiftType { Id = 1, Description = "Matutino", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true, TimeDescription = "8:00 - 12:00" },
                    new ShiftType { Id = 2, Description = "Tarde", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true, TimeDescription = "12:00 - 16:00" }
                );

            modelBuilder.Entity<TransmissionType>().HasData(
                    new TransmissionType { Id = 1, Description = "Manual", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new TransmissionType { Id = 2, Description = "Automatico", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );

            modelBuilder.Entity<VehicleType>().HasData(
                    new VehicleType { Id = 1, Description = "Carro", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new VehicleType { Id = 2, Description = "Motor", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );

            modelBuilder.Entity<VehicleColor>().HasData(
                    new VehicleColor { Id = 1, Description = "Azul", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new VehicleColor { Id = 2, Description = "Negro", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );

            modelBuilder.Entity<Manufacturer>().HasData(
                    new Manufacturer { Id = 1, Description = "Honda", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new Manufacturer { Id = 2, Description = "Toyota", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );

            modelBuilder.Entity<Model>().HasData(
                    new Model { Id = 1, ManufacturerId=1,Description = "Civic", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new Model { Id = 2, ManufacturerId = 1, Description = "Accord", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );

            modelBuilder.Entity<Vehicle>().HasData(
                    new Vehicle
                    { 
                        Id = 1, 
                        ModelId=1,
                        ColorId = 1,
                        FuelTypeId = 1,
                        TransmissionTypeId = 1,
                        ChassisNumber = "XXXX" ,
                        PlateNumber = "XXXXX",
                        VehicleStateId = 1,
                        VehicleTypeId = 1,
                        EngineNumber = "XXXXX",
                        CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true },
                    new Vehicle
                    {
                        Id = 2,
                        ModelId = 2,
                        ColorId = 1,
                        FuelTypeId = 1,
                        TransmissionTypeId = 1,
                        ChassisNumber = "XdXXX",
                        PlateNumber = "XXXdXX",
                        VehicleStateId = 1,
                        VehicleTypeId = 1,
                        EngineNumber = "XXXdXX",
                        CreationDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        Active = true
                    }
                );

            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    { 
                        Id = 1, Name = "JOSE", LastName = "PEREZ",BaseSalary = 50000, Commission = 10,IdentityNumber= "5151515",ShiftTypeId = 1,
                        CreationDate = DateTime.Now, UpdateDate = DateTime.Now, Active = true }
                );


            #endregion

            #region Unique Keys

            #region Vehiculo

            modelBuilder.Entity<Vehicle>().HasIndex(x => new { x.ChassisNumber }).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(x => new { x.EngineNumber }).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(x => new { x.PlateNumber }).IsUnique();

            #endregion

            modelBuilder.Entity<Client>().HasIndex(x => new {x.IdentityNumber}).IsUnique();
            modelBuilder.Entity<Model>().HasIndex(x => new {x.Description,x.ManufacturerId}).IsUnique();
            modelBuilder.Entity<Manufacturer>().HasIndex(x => new {x.Description}).IsUnique();
            modelBuilder.Entity<VehicleColor>().HasIndex(x => new {x.Description}).IsUnique();
            modelBuilder.Entity<VehicleType>().HasIndex(x => new {x.Description}).IsUnique();
            modelBuilder.Entity<VehicleState>().HasIndex(x => new {x.Description}).IsUnique();
            modelBuilder.Entity<TransmissionType>().HasIndex(x => new {x.Description}).IsUnique();
            modelBuilder.Entity<FuelType>().HasIndex(x => new {x.Description}).IsUnique();
            modelBuilder.Entity<FuelTankState>().HasIndex(x => new {x.Description}).IsUnique();
            modelBuilder.Entity<ClientType>().HasIndex(x => new {x.Description}).IsUnique();
            modelBuilder.Entity<IdentificationType>().HasIndex(x => new {x.Description}).IsUnique();

            #endregion
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLoggerFactory(_LoggerFactory);
        //}

        public DbSet<CarRentInformation> CarRentInformation { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FuelTankState> FuelTankStates { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ShiftType> ShiftTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleCheck> VehicleChecks { get; set; }
        public DbSet<VehicleColor> VehicleColors { get; set; }
        public DbSet<VehicleState> VehicleStates { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<RentState> RentStates { get; set; }
        public DbSet<RentReturn> RentReturns { get; set; }
        
    }
}