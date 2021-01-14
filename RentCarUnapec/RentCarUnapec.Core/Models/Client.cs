using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RentCarUnapec.Core.Enums;

namespace RentCarUnapec.Core.Models
{
    public class Client:BaseModel
    {
        [Required]
        [MaxLength(100)]
        [DisplayName("Nombres")]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(15)]
        [DisplayName("No. Identificacion")]
        public string IdentityNumber { get; set; }

        [Required]
        [DisplayName("Tipo Identificacion")]
        public IdentificationTypeEnum IdentificationType { get; set; }

        [Required]
        [MaxLength(16)]
        [DisplayName("No. Tarjeta")]
        public string CreditCardNumber { get; set; }

        [Required]
        [DisplayName("Limite de Credito")]
        [Column(TypeName = "decimal(10,0)")]
        public decimal CreditLimit { get; set; }

        [Required]
        [DisplayName("Tipo Cliente")]
        public ClientTypeEnum ClientType { get; set; }

        public virtual IList<CarRentInformation> CarRentHistory { get; set; }
    }
}