
using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string MobileNumber { get; set; }
        


        public HttpPostedFileBase ImageFile { get; set; }
        public string IME { get => iME; set => iME = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Warranty { get => warranty; set => warranty = value; }
        public string Model { get => model; set => model = value; }
        public string Picture { get => picture; set => picture = value; }
        public string Used { get => used; set => used = value; }
    }
}