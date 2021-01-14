using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCarUnapec.Core.Models
{
    public class Employee : BaseModel
    {
        [Required]
        [MaxLength(100)]
        [Column(Order = 1)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(Order = 2)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(15)]
        [Column(Order = 3)]
        [Display(Name = "No. Identificacion")]
        public string IdentityNumber { get; set; }

        [Required]
        [Column(Order = 4)]
        [Display(Name = "Salario Base")]
        public double BaseSalary { get; set; }

        [Required]
        [Column(Order = 5)]
        [Display(Name = "Comision (%)")]
        public double Commission { get; set; }

        [Required]
        [Column(Order = 6)]
        [Display(Name = "Turno")]
        public int ShiftTypeId { get; set; }

        public virtual ShiftType ShiftType { get; set; }
        public virtual string FullName => $"{Name} {LastName}";
    }
}