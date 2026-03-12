using DVLD___Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD___Business
{
    public class clsCountry
    {
        public enum Mode { ADD,UPDATE }
        public int CountryID { get; private set; }
        public string CountryName { get; set; }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }
    }
}
