using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace RentCarUnapec.Core.Models
{
    public class Vehicle : BaseModel
    {
        [Required]
        [Column(Order = 1)]
        [DisplayName("Modelo Vehiculo")]
        public int ModelId { get; set; }

        [Required]
        [Column(Order = 2)]
        [DisplayName("Color")]
        public int ColorId { get; set; }

        [Required]
        [Column(Order = 3)]
        [DisplayName("Tipo Combustible")]
        public int FuelTypeId { get; set; }

        [Required]
        [Column(Order = 4)]
        [DisplayName("Tipo Vehiculo")]
        public int VehicleTypeId { get; set; }
        [Required]
        [Column(Order = 5)]
        [Display(Name = "Estado")]
        public int VehicleStateId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(Order = 6)]
        [DisplayName("No. Chasis")]
        public string ChassisNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(Order = 7)]
        [DisplayName("No. Motor")]
        public string EngineNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(Order = 8)]
        [DisplayName("No. Placa")]
        public string PlateNumber { get; set; }

        [Required]
        [Column(Order = 9)]
        [DisplayName("Tipo Transmision")]
        public int TransmissionTypeId { get; set; }

        public virtual Model Model { get; set; }
        public virtual VehicleColor Color { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual VehicleState VehicleState { get; set; }
        public virtual TransmissionType TransmissionType { get; set; }
        public virtual IList<CarRentInformation> CarRentInformations { get; set; }
        [DisplayName("Nombre")]
        public virtual string VehicleFullName
        {
            get
            {
                return $"{Model?.Manufacturer?.Description} {Model?.Description}";
            }
        }
        [DisplayName("Tipo")]
        public virtual string TypeName
        {
            get
            {
                return VehicleType?.Description;
            }
        }
        [DisplayName("Color")]
        public virtual string ColorName
        {
            get
            {
                return Color?.Description;
            }
        }

    }
}