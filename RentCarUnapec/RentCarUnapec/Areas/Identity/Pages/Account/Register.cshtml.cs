using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RentCarUnapec.Core.Models;
using RentCarUnapec.Core.Models.Indentity;
using RentCarUnapec.Data.Interfaces;

namespace RentCarUnapec.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<RentCarUser> _signInManager;
        private readonly UserManager<RentCarUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IEmployeeService _employeeService;

        public RegisterModel(
            UserManager<RentCarUser> userManager,
            SignInManager<RentCarUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IEmployeeService employeeService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _employeeService = employeeService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public SelectList EmployeesList { get; set; }
        public class InputModel
        {
            [Required]
            [Display(Name = "Nombre de Usuario")]
            public string UserName { get; set; }
            [Required]
            [Display(Name = "Empleado")]
            public int EmployeeId { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "La {0} debe tener mino {2} y maximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar Contraseña")]
            [Compare("Password", ErrorMessage = "La Contraseña y la Confirmacion no Son Iguales.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            EmployeesList = new SelectList(await _employeeService.GetAll(),nameof(Employee.Id), nameof(Employee.FullName));
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new RentCarUser { UserName = Input.UserName,EmployeeId = Input.EmployeeId};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            EmployeesList = new SelectList(await _employeeService.GetAll(), nameof(Employee.Id), nameof(Employee.FullName));
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
