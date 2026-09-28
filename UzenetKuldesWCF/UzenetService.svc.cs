using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UzenetKuldesWCF.models;
using UzenetKuldesWCF.services;

namespace UzenetKuldesWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IUzenetService
    {
        public string CreateUzenet(Uzenet uzenet)
        {
            return new UzenetKuldesService().Create(uzenet);
        }

        public string DeleteUzenet(int id)
        {
            return new UzenetKuldesService().Delete(id);    
        }
        public List<Uzenet> GetAllUzenet()
        {
            List<Tablazat> tablazatok = new UzenetKuldesService().Read();
            List<Uzenet> uzenetList = new List<Uzenet>();
            foreach (Tablazat item in tablazatok)
            {
                uzenetList.Add(item as Uzenet);
            }
            return uzenetList;
        }

        public string UpdateUzenet(Uzenet uzenet)
        {
            return new UzenetKuldesService().Update(uzenet);
        }
    }
}
