using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIDT.AIDatabase.Services
{
    public class CustomerDetailsService
    {
        public List<CustomerDetail> GetByOccupationType(string occupationName)
        {
            using(EntitiesDataContext db = new EntitiesDataContext())
            {
                List<CustomerDetail> _customerDetailsCollection = new List<CustomerDetail>();

                _customerDetailsCollection = (from t in db.CustomerDetails 
                                             where t.OccupationType.OccupationName.Trim() == occupationName.Trim() 
                                             select t).ToList();

                return _customerDetailsCollection;
            }
        }

        public List<CustomerDetail> GetByNotOccupationType(string notOccupationName)
        {
            using (EntitiesDataContext db = new EntitiesDataContext())
            {
                List<CustomerDetail> _customerDetailsCollection = new List<CustomerDetail>();

                _customerDetailsCollection = (from t in db.CustomerDetails
                                              where t.OccupationType.OccupationName.Trim() != notOccupationName.Trim()
                                              select t).ToList();

                return _customerDetailsCollection;
            }
        }
    }
}
