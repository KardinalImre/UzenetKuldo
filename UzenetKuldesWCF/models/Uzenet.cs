using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UzenetKuldesWCF.models
{
    public class Uzenet : Tablazat
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Kuldesi ido: {KuldesiIdo}, Uzenet tipus: {UzenetTipus}, Telefon: {Telefon}, Email: {Email}";
        }
    }
}