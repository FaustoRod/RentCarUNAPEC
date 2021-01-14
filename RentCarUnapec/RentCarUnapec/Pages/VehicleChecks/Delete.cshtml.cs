using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data;

namespace RentCarUnapec.Pages.VehicleChecks
{
    public class DeleteModel : PageModel
    {
        private readonly RentCarUnapec.Data.RentCarDBContext _context;

        public DeleteModel(RentCarUnapec.Data.RentCarDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VehicleCheck VehicleCheck { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleCheck = await _context.VehicleCheck
                .Include(v => v.CarRentInformation)
                .Include(v => v.Employee)
                .Include(v => v.FuelTank).FirstOrDefaultAsync(m => m.Id == id);

            if (VehicleCheck == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleCheck = await _context.VehicleCheck.FindAsync(id);

            if (VehicleCheck != null)
            {
                _context.VehicleCheck.Remove(VehicleCheck);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
