using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Shopiphone.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        
        [EmailAddress(ErrorMessage = "Enter in correct Email Fromat")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]

        public string Email { get; set; }

        [Required]
        
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* A valid name is required.")]

        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Name Should be in Alphabets")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "CNIC must be 13 digits.", MinimumLength = 13)]
        [Display(Name = "CNIC")]
        public string CNIC { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "Phone Number must be 11 digits.", MinimumLength = 11)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone Number should be in Digits")]
        [Display(Name = "Phone Number")]
        public string Phoneno { get; set; }

        [Required]
       
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Account Number should be in Digits")]
        [Display(Name = "Account Number")]
        public string Accountno { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Your password must contain at least one Uppercase, one Lowercase and one digit.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
        public string Scanned_CNIC { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Your password must contain at least one Uppercase, one Lowercase and one digit.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
