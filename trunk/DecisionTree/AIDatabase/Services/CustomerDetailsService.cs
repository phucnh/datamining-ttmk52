using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AIDT.AIDatabase.Services
{
    public class CustomerDetailsService
    {
        public System.Data.DataTable GetByOccupationType(string occupationName)
        {
            using(EntitiesDataContext db = new EntitiesDataContext())
            {
                var _customerDetailsCollection = (from t in db.CustomerDetails
                                              where t.OccupationType.OccupationName.Trim() == occupationName.Trim()
                                              select new
                                              {
                                                  t.CustomerId,
                                                  t.Name,
                                                  t.Birthday,
                                                  t.OccupationType.OccupationName,
                                              });

                DataTable _dataTable = new DataTable();

                _dataTable.Columns.Add("CustomerId");
                _dataTable.Columns.Add("Name");
                _dataTable.Columns.Add("Birthday");
                _dataTable.Columns.Add("OccupationName");

                foreach (var p in _customerDetailsCollection)
                {
                    string[] _tempStr = { p.CustomerId.ToString(), p.Name,p.Birthday.ToString(), p.OccupationName };
                    _dataTable.Rows.Add(_tempStr);
                }

                return _dataTable;
            }
        }

        public IQueryable<CustomerDetail> GetByOccupationTypes(string occupationName)
        {
            EntitiesDataContext db = new EntitiesDataContext();
            
                //List<CustomerDetail> _customerDetailsCollection = new List<CustomerDetail>();

                var _customerDetailsCollection = (from t in db.CustomerDetails
                                                                         where t.OccupationType.OccupationName.Trim() == occupationName.Trim()
                                                                         select t);

                return _customerDetailsCollection;
            
        }

        public DataTable GetByNotOccupationType(string notOccupationName)
        {
            using (EntitiesDataContext db = new EntitiesDataContext())
            {
                var _customerDetailsCollection = (from t in db.CustomerDetails
                                                  where t.OccupationType.OccupationName.Trim() != notOccupationName.Trim()
                                                  select new
                                                  {
                                                      t.CustomerId,
                                                      t.Name,
                                                      t.Birthday,
                                                      t.OccupationType.OccupationName,
                                                  });

                DataTable _dataTable = new DataTable();

                _dataTable.Columns.Add("CustomerId");
                _dataTable.Columns.Add("Name");
                _dataTable.Columns.Add("Birthday");
                _dataTable.Columns.Add("OccupationName");

                foreach (var p in _customerDetailsCollection)
                {
                    string[] _tempStr = { p.CustomerId.ToString(), p.Name,p.Birthday.ToString(), p.OccupationName };
                    _dataTable.Rows.Add(_tempStr);
                }

                return _dataTable;
            }
        }
    }
}
