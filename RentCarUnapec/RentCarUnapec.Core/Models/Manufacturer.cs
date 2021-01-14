using System.Collections.Generic;

namespace RentCarUnapec.Core.Models
{
    public class Manufacturer : CommonModel
    {
        public virtual IList<Model> Models { get; set; }

    }
}