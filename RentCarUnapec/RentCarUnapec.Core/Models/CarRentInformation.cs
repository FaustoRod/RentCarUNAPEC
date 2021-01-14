using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCarUnapec.Core.Models
{
    public class CarRentInformation : BaseModel
    {
        [Required]
        [MaxLength(100)]
        [Column(Order = 1)]
        [Display(Name = "Codigo")]
        public string RentSequence { get; set; }

        [Required]
        [Column(Order = 2)]
        [Display(Name = "Empleado")]
        public int EmployeeId { get; set; }

        [Required]
        [Column(Order = 3)]
        [Display(Name = "Vehiculo")]
        public int VehicleId { get; set; }

        [Required]
        [Column(Order = 4)]
        [Display(Name = "Cliente")]
        public int ClientId { get; set; }


        [Required]
        [Column(Order = 5)]
        [Display(Name = "Estado")]
        public int RentStateId { get; set; }

        [Required]
        [Column(Order = 6)]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Renta")]
        public DateTime RentDay { get; set; }

        [Required]
        [Column(Order = 7)]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Retorno")]
        public DateTime ReturnDay { get; set; }

        [Required]
        [Column(Order = 8, TypeName = "decimal(6,2)")]
        [Display(Name = "Precio x Dia")]
        public decimal AmountPerDay { get; set; }

        [Required]
        [Column(Order = 9)]
        [Display(Name = "Dias de Renta")]
        public int RentDays { get; set; }

        [MaxLength(200)]
        [Column(Order = 10)]
        [Display(Name = "Comentario")]
        public string Comment { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Client Client { get; set; }
        public virtual RentState RentState { get; set; }
        public virtual VehicleCheck VehicleCheck { get; set; }
        public virtual String VehicleName => Vehicle?.VehicleFullName;
        public virtual String ClienteName => Client?.Name;
        public virtual String TypeName => Vehicle?.TypeName;
        public virtual String RentCode => RentSequence?.Substring(0,5);
    }
}