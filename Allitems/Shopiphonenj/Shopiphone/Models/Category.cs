using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopiphone.Models
{
    public class Category
    {
        private string IPhone;
        private string samsung;
        private string vivo;
        private string nokia;
        private string sony;
        private string oppo;
        private string huawei;
        private string qMobile;

        public string iPhone { get => IPhone; set => IPhone = value; }
        public string Samsung { get => samsung; set => samsung = value; }
        public string Vivo { get => vivo; set => vivo = value; }
        public string Nokia { get => nokia; set => nokia = value; }
        public string Sony { get => sony; set => sony = value; }
        public string Oppo { get => oppo; set => oppo = value; }
        public string Huawei { get => huawei; set => huawei = value; }
        public string QMobile { get => qMobile; set => qMobile = value; }
    }
}