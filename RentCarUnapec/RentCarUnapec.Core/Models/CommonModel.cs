using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCarUnapec.Core.Models
{
    public class CommonModel : BaseModel
    {
        [Required(ErrorMessage = "Descripcion Requerida")]
        [MaxLength(50)]
        [Column(Order = 1)]
        [DisplayName("Descripcion")]
        public string Description { get; set; }
    }
}
