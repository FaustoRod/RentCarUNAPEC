using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCarUnapec.Core.Models
{
    public class BaseModel
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Fecha Creacion")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Fecha Modificacion")]
        public DateTime UpdateDate { get; set; }

        public bool Active { get; set; }

    }
}
