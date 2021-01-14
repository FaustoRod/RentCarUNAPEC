using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCarUnapec.Core.Models
{
    public class VehicleCheck : BaseModel
    {
        [Required]
        [Column(Order = 1)]
        public int EmployeeId { get; set; }
        [Required]
        [Column(Order = 2)]
        [Display(Name = "Vehiculo de Renta")]
        public int CarRentInformationId { get; set; }

        [Required]
        [Column(Order = 3)]
        [Display(Name="Estado de Combustible")]
        public int FuelTankId { get; set; }

        [Column(Order = 4)]
        [Display(Name = "Posee Raguños?")]
        public bool HasScratch { get; set; }

        [Column(Order = 5)]
        [Display(Name = "Posee Goma de Repuesto?")]
        public bool HasSpare { get; set; }

        [Column(Order = 6)]
        [Display(Name = "Posee Gato?")]
        public bool HasJackScrew { get; set; }

        [Column(Order = 7)]
        [Display(Name = "Posee Cristal Roto?")]
        public bool HasBrokenWind { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(Order = 8)]
        [Display(Name = "Estado Goma Delantera Izquierda")]
        public string LeftUpperTire { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(Order = 9)]
        [Display(Name = "Estado Goma Delantera Derecha")]
        public string RightUpperTire { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(Order = 10)]
        [Display(Name = "Estado Goma Trasera Izquierda")]
        public string LeftBottomTire { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(Order = 11)]
        [Display(Name = "Estado Goma Trasera Derecha")]
        public string RightBottomTire { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual FuelTankState FuelTank { get; set; }
        public virtual CarRentInformation CarRentInformation { get; set; }
    }
}