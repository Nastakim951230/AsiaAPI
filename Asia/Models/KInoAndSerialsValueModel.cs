using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asia.Models
{
    public class KInoAndSerialsValueModel
    {
        private AsiaDrama_TrifonovaEntities db=new AsiaDrama_TrifonovaEntities();
        public KInoAndSerialsValueModel(KinoAndSerial x)
        {
            IdKinoAndSerial=x.IdKinoAndSerial;
            Name=x.Name;
            idCountry = db.Country.ToList().FirstOrDefault(y => y.IdCountry == x.idCountry).NameCountry;
            YearKinoAndSerial = x.YearKinoAndSerial;
            TimeKinoAndSerial = x.TimeKinoAndSerial;
            OKinoAndSerial = x.OKinoAndSerial;
            PhotoKinoAndSerial = x.PhotoKinoAndSerial;
        }
        public int IdKinoAndSerial { get; set; }
        public string Name { get; set; }
        public string idCountry { get; set; }
        public int YearKinoAndSerial { get; set; }
        public string TimeKinoAndSerial { get; set; }
        public string OKinoAndSerial { get; set; }
        public string PhotoKinoAndSerial { get; set; }

    }
}