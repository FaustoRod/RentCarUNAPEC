using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCarUnapec.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IdentityNumber = table.Column<string>(maxLength: 15, nullable: false),
                    IdentificationType = table.Column<int>(nullable: false),
                    CreditCardNumber = table.Column<string>(maxLength: 16, nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    ClientType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTankStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTankStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    TimeDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleColors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    IdentityNumber = table.Column<string>(maxLength: 15, nullable: false),
                    BaseSalary = table.Column<double>(nullable: false),
                    Commission = table.Column<double>(nullable: false),
                    ShiftTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_ShiftTypes_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalTable: "ShiftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    FuelTypeId = table.Column<int>(nullable: false),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    VehicleStateId = table.Column<int>(nullable: false),
                    ChassisNumber = table.Column<string>(maxLength: 50, nullable: false),
                    EngineNumber = table.Column<string>(maxLength: 50, nullable: false),
                    PlateNumber = table.Column<string>(maxLength: 50, nullable: false),
                    TransmissionTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "VehicleColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_TransmissionTypes_TransmissionTypeId",
                        column: x => x.TransmissionTypeId,
                        principalTable: "TransmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleStates_VehicleStateId",
                        column: x => x.VehicleStateId,
                        principalTable: "VehicleStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarRentInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RentSequence = table.Column<string>(maxLength: 100, nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    RentStateId = table.Column<int>(nullable: false),
                    RentDay = table.Column<DateTime>(nullable: false),
                    ReturnDay = table.Column<DateTime>(nullable: false),
                    AmountPerDay = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    RentDays = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarRentInformation_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentInformation_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentInformation_RentStates_RentStateId",
                        column: x => x.RentStateId,
                        principalTable: "RentStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentInformation_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentReturns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CarRentInformationId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentReturns_CarRentInformation_CarRentInformationId",
                        column: x => x.CarRentInformationId,
                        principalTable: "CarRentInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentReturns_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VehicleChecks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    CarRentInformationId = table.Column<int>(nullable: false),
                    FuelTankId = table.Column<int>(nullable: false),
                    HasScratch = table.Column<bool>(nullable: false),
                    HasSpare = table.Column<bool>(nullable: false),
                    HasJackScrew = table.Column<bool>(nullable: false),
                    HasBrokenWind = table.Column<bool>(nullable: false),
                    LeftUpperTire = table.Column<string>(maxLength: 250, nullable: false),
                    RightUpperTire = table.Column<string>(maxLength: 250, nullable: false),
                    LeftBottomTire = table.Column<string>(maxLength: 250, nullable: false),
                    RightBottomTire = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleChecks_CarRentInformation_CarRentInformationId",
                        column: x => x.CarRentInformationId,
                        principalTable: "CarRentInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleChecks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VehicleChecks_FuelTankStates_FuelTankId",
                        column: x => x.FuelTankId,
                        principalTable: "FuelTankStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientTypes",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9982), "Persona", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9983) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(2), "Empresa", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(3) }
                });

            migrationBuilder.InsertData(
                table: "FuelTankStates",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(613), "Full", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(614) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(631), "Medio", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(632) },
                    { 3, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(635), "Vacio", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(636) }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 290, DateTimeKind.Local).AddTicks(6663), "Gasolina", new DateTime(2020, 6, 28, 15, 13, 5, 290, DateTimeKind.Local).AddTicks(7171) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 290, DateTimeKind.Local).AddTicks(8092), "Diesel", new DateTime(2020, 6, 28, 15, 13, 5, 290, DateTimeKind.Local).AddTicks(8100) },
                    { 3, true, new DateTime(2020, 6, 28, 15, 13, 5, 290, DateTimeKind.Local).AddTicks(8121), "GLP", new DateTime(2020, 6, 28, 15, 13, 5, 290, DateTimeKind.Local).AddTicks(8122) }
                });

            migrationBuilder.InsertData(
                table: "IdentificationTypes",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(1303), "Cedula", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(1304) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(1319), "RNC", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(1320) },
                    { 3, false, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(1323), "Pasaporte", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(1324) }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(4831), "Honda", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(4832) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(4846), "Toyota", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(4847) }
                });

            migrationBuilder.InsertData(
                table: "RentStates",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 6, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9342), "Chequeado", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9342) },
                    { 5, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9339), "Cancelado", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9339) },
                    { 4, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9335), "Entregado", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9336) },
                    { 3, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9332), "En Espera de Entrega", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9333) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9329), "En Espera de Chequeo", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9330) },
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9313), "Activo", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(9314) }
                });

            migrationBuilder.InsertData(
                table: "ShiftTypes",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "TimeDescription", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(1917), "Matutino", "8:00 - 12:00", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(1918) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(2406), "Tarde", "12:00 - 16:00", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(2408) }
                });

            migrationBuilder.InsertData(
                table: "TransmissionTypes",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(3049), "Manual", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(3050) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(3064), "Automatico", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(3065) }
                });

            migrationBuilder.InsertData(
                table: "VehicleColors",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(4242), "Azul", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(4243) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(4257), "Negro", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(4258) }
                });

            migrationBuilder.InsertData(
                table: "VehicleStates",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(8551), "Disponible", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(8552) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(8570), "En Espera de Chequeo", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(8571) },
                    { 3, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(8574), "Chequeo Completado", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(8575) },
                    { 4, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(8577), "Rentado", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(8578) },
                    { 5, true, new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(8580), "En Espera de Entrega", new DateTime(2020, 6, 28, 15, 13, 5, 291, DateTimeKind.Local).AddTicks(8581) }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(3650), "Carro", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(3651) },
                    { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(3666), "Motor", new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(3667) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "BaseSalary", "Commission", "CreationDate", "IdentityNumber", "LastName", "Name", "ShiftTypeId", "UpdateDate" },
                values: new object[] { 1, true, 50000.0, 10.0, new DateTime(2020, 6, 28, 15, 13, 5, 293, DateTimeKind.Local).AddTicks(3217), "5151515", "PEREZ", "JOSE", 1, new DateTime(2020, 6, 28, 15, 13, 5, 293, DateTimeKind.Local).AddTicks(3222) });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "ManufacturerId", "UpdateDate" },
                values: new object[] { 2, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(5982), "Accord", 1, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(5983) });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Active", "CreationDate", "Description", "ManufacturerId", "UpdateDate" },
                values: new object[] { 1, true, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(5945), "Civic", 1, new DateTime(2020, 6, 28, 15, 13, 5, 292, DateTimeKind.Local).AddTicks(5949) });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Active", "ChassisNumber", "ColorId", "CreationDate", "EngineNumber", "FuelTypeId", "ModelId", "PlateNumber", "TransmissionTypeId", "UpdateDate", "VehicleStateId", "VehicleTypeId" },
                values: new object[] { 1, true, "XXXX", 1, new DateTime(2020, 6, 28, 15, 13, 5, 293, DateTimeKind.Local).AddTicks(129), "XXXXX", 1, 1, "XXXXX", 1, new DateTime(2020, 6, 28, 15, 13, 5, 293, DateTimeKind.Local).AddTicks(134), 1, 1 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Active", "ChassisNumber", "ColorId", "CreationDate", "EngineNumber", "FuelTypeId", "ModelId", "PlateNumber", "TransmissionTypeId", "UpdateDate", "VehicleStateId", "VehicleTypeId" },
                values: new object[] { 2, true, "XdXXX", 1, new DateTime(2020, 6, 28, 15, 13, 5, 293, DateTimeKind.Local).AddTicks(210), "XXXdXX", 1, 2, "XXXdXX", 1, new DateTime(2020, 6, 28, 15, 13, 5, 293, DateTimeKind.Local).AddTicks(211), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentInformation_ClientId",
                table: "CarRentInformation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentInformation_EmployeeId",
                table: "CarRentInformation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentInformation_RentStateId",
                table: "CarRentInformation",
                column: "RentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentInformation_VehicleId",
                table: "CarRentInformation",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdentityNumber",
                table: "Clients",
                column: "IdentityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientTypes_Description",
                table: "ClientTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShiftTypeId",
                table: "Employees",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelTankStates_Description",
                table: "FuelTankStates",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuelTypes_Description",
                table: "FuelTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentificationTypes_Description",
                table: "IdentificationTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Description",
                table: "Manufacturers",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerId",
                table: "Models",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Description_ManufacturerId",
                table: "Models",
                columns: new[] { "Description", "ManufacturerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentReturns_CarRentInformationId",
                table: "RentReturns",
                column: "CarRentInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_RentReturns_EmployeeId",
                table: "RentReturns",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransmissionTypes_Description",
                table: "TransmissionTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleChecks_CarRentInformationId",
                table: "VehicleChecks",
                column: "CarRentInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleChecks_EmployeeId",
                table: "VehicleChecks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleChecks_FuelTankId",
                table: "VehicleChecks",
                column: "FuelTankId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleColors_Description",
                table: "VehicleColors",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ChassisNumber",
                table: "Vehicles",
                column: "ChassisNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ColorId",
                table: "Vehicles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EngineNumber",
                table: "Vehicles",
                column: "EngineNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FuelTypeId",
                table: "Vehicles",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PlateNumber",
                table: "Vehicles",
                column: "PlateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TransmissionTypeId",
                table: "Vehicles",
                column: "TransmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleStateId",
                table: "Vehicles",
                column: "VehicleStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleStates_Description",
                table: "VehicleStates",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_Description",
                table: "VehicleTypes",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClientTypes");

            migrationBuilder.DropTable(
                name: "IdentificationTypes");

            migrationBuilder.DropTable(
                name: "RentReturns");

            migrationBuilder.DropTable(
                name: "VehicleChecks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CarRentInformation");

            migrationBuilder.DropTable(
                name: "FuelTankStates");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RentStates");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "ShiftTypes");

            migrationBuilder.DropTable(
                name: "VehicleColors");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "TransmissionTypes");

            migrationBuilder.DropTable(
                name: "VehicleStates");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
