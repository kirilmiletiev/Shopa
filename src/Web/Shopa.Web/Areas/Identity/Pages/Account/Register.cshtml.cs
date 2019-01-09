using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shopa.Data.Models;

namespace Shopa.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ShopaUser> _signInManager;
        private readonly UserManager<ShopaUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<ShopaUser> userManager,
            SignInManager<ShopaUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Address")]
            [StringLength(250, ErrorMessage = "The address must be at least 6 and at max 250 characters long.", MinimumLength = 6)]
            public string Address { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ShopaUser { UserName = Input.Email, Email = Input.Email, Address = Input.Address, PhoneNumber = Input.PhoneNumber };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //set Role
                    await SetRoleToUser(user);

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        // Add Role to every User
        private async Task SetRoleToUser(ShopaUser user)
        {
            var x = await _roleManager.RoleExistsAsync("Admin");
            if (!x)
            {
                // first we create Admin role of FirstUser (TEST)    
                var roleAdmin = new IdentityRole("Admin");
                await _roleManager.CreateAsync(roleAdmin);
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                //then in second registration we seed other roles
                var y = await _roleManager.RoleExistsAsync("Seller");
                if (!y)
                {
                    var role = new IdentityRole("Seller");
                    await _roleManager.CreateAsync(role);
                }


                var z = await _roleManager.RoleExistsAsync("User");
                if (!z)
                {
                    var role = new IdentityRole("User");
                    await _roleManager.CreateAsync(role);
                }

                if (user.Products.Count > 5 && !this.User.IsInRole("Admin"))
                {
                    await _userManager.AddToRoleAsync(user, "Seller");
                }
                else if (!this.User.IsInRole("Admin"))
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}
