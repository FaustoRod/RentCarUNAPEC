using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Data;

namespace RentCarUnapec.Pages.CarRentInformation
{
    public class DeleteModel : PageModel
    {
        private readonly RentCarUnapec.Data.RentCarDbContext _context;

        public DeleteModel(RentCarUnapec.Data.RentCarDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarRentInformation CarRentInformation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarRentInformation = await _context.CarRentInformation
                .Include(c => c.Client)
                .Include(c => c.Employee)
                .Include(c => c.Vehicle).FirstOrDefaultAsync(m => m.Id == id);

            if (CarRentInformation == null)
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

            CarRentInformation = await _context.CarRentInformation.FindAsync(id);

            if (CarRentInformation != null)
            {
                _context.CarRentInformation.Remove(CarRentInformation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
