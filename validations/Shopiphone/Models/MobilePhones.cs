using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace Shopiphone.Models
{
    public class MobilePhones
    {
        private string iME;
        private string brand;
        private string price;
        private string description;
        private string warranty;
        private string model;
        private string picture;
        private string used;

        private int mobileId;
        public HttpPostedFileBase ImageFile { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "IME Number must be 15 digits.", MinimumLength = 15)]

        public string IME { get => iME; set => iME = value; }
        public string Brand { get => brand; set => brand = value; }

        public string Description { get => description; set => description = value; }
        public string Warranty { get => warranty; set => warranty = value; }
        public string Model { get => model; set => model = value; }
        public string Picture { get => picture; set => picture = value; }
        [Required]
       
        
       
        [Range(1, 9999, ErrorMessage = "Price should be positive integers.")]
        [RegularExpression(@"^(((\d{1})*))$", ErrorMessage = "Price should be in digits.")]

        public string Price { get => price; set => price = value; }
        public string Used { get => used; set => used = value; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Mobile Id should be in Digits")]
        public int MobileId { get => mobileId; set => mobileId = value; }
    }
}