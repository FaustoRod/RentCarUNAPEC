using Microsoft.AspNetCore.Identity;

namespace RentCarUnapec.Core.Models.Indentity
{
    public class RentCarUser:IdentityUser
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
