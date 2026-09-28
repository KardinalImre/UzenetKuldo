using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UzenetKuldesWCF.models
{
    public class Tablazat
    {
        public string Szoveg { get; set; }
        public DateTime KuldesiIdo { get; set; }
        public string UzenetTipus { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}