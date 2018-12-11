
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopiphone.Models
{
    public class Secondhandviewmodel
    {
        private string iME;
        private string brand;
        private string price;
        private string description;
        private string warranty;
        private string model;
        private string used;
        private string picture;
        private string name;
        private string cNIC;
        private string mobileNumber;
        public string Bargain;



        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Price should be in Digits")]
        public string IME { get => iME; set => iME = value; }
        public string Brand { get => brand; set => brand = value; }
        [Required]
        [Range(1, 9999, ErrorMessage = "Price should be positive integers.")]
        [RegularExpression(@"^(((\d{1})*))$", ErrorMessage = "Price should be in digits.")]
        public string Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Warranty { get => warranty; set => warranty = value; }
        public string Model { get => model; set => model = value; }
        public string Picture { get => picture; set => picture = value; }
        public string Used { get => used; set => used = value; }
        [Required]

        [StringLength(50, MinimumLength = 2, ErrorMessage = "* A valid name is required.")]

        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Name Should be in Alphabets")]
        public string Name { get => name; set => name = value; }
        [Required]
        [StringLength(13, ErrorMessage = "CNIC must be 13 digits.", MinimumLength = 13)]
        public string CNIC { get => cNIC; set => cNIC = value; }

        [Required]
        [StringLength(11, ErrorMessage = "Phone Number must be 11 digits.", MinimumLength = 11)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone Number should be in Digits")]
        public string MobileNumber { get => mobileNumber; set => mobileNumber = value; }
    }
}