using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCarUnapec.Core.Models
{
    public class Model : CommonModel
    {

        [Column(Order = 1)]
        [Required]
        [DisplayName("Marca Vehiculo")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual IList<Vehicle> Vehicles { get; set; }
    }
}
