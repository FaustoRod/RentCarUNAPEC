using System.ComponentModel.DataAnnotations;

namespace RentCarUnapec.Core.Models
{
    public class RentReturn:BaseModel
    {
        public int CarRentInformationId { get; set; }
        public int EmployeeId { get; set; }
        [MaxLength(100)]
        public string Comment { get; set; }
        public virtual CarRentInformation CarRentInformation { get; set; }
        public virtual Employee Employee { get; set; }
    }
}