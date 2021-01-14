using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCarUnapec.Core.Models
{
    public class ShiftType : CommonModel
    {
        [Required]
        [Column(Order = 1)]
        [DisplayName("Detalle")]
        public string TimeDescription { get; set; }
    }
}