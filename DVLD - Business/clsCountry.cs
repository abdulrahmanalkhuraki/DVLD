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
        private enMode Mode;
        public int CountryID { get; private set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            Mode = enMode.ADD;
            CountryID = -1;
            CountryName = String.Empty;
        }
        public clsCountry(int CountryId,string CountryName)
        {
            Mode = enMode.UPDATE;
            CountryID = CountryId;
            this.CountryName = CountryName;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

        public static clsCountry FindCountry(int CountryId)
        {
            string CountryName = string.Empty;


            if (clsCountryData.GetCountryByID(CountryId, ref CountryName))
            {
                return new clsCountry(CountryId, CountryName);
            }
            else
            {
                return null;
            }
        }
    }
}
