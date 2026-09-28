using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UzenetKuldesWCF.models;

namespace UzenetKuldesWCF.interfaces
{
    public interface ICRUD
    {
        string Create(Tablazat tablazat);
        List<Tablazat> Read();
        string Update(Tablazat tablazat);
        string Delete(int id);
    }
}