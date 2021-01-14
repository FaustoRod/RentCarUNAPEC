﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Pages.VehicleColor
{
    [Authorize]
    public class EditModel : PageModel
    {

        public EditModel(IVehicleColorService vehicleColorService)
        {
            _vehicleColorService = vehicleColorService;
        }

        [BindProperty]
        public Core.Models.VehicleColor VehicleColor { get; set; }
        public IVehicleColorService _vehicleColorService { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleColor = await _vehicleColorService.GetSingleById(id.Value);

            if (VehicleColor == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _vehicleColorService.Update(VehicleColor);

            return RedirectToPage("./Index");
        }

    }
}
