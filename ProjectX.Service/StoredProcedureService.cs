using System.Collections.Generic;
using ProjectX.Entities.Models;

namespace ProjectX.Service
{
    public class StoredProcedureService : IStoredProcedureService
    {
        private readonly IProjectXStoredProcedures _storedProcedures;

        public StoredProcedureService(IProjectXStoredProcedures storedProcedures)
        {
            _storedProcedures = storedProcedures;
        }

        public IEnumerable<CustomerOrderHistory> CustomerOrderHistory(string customerID)
        {
            return _storedProcedures.CustomerOrderHistory(customerID);
        }

        public int CustOrdersDetail(int? orderID)
        {
            return _storedProcedures.CustOrdersDetail(orderID);
        }

        public IEnumerable<CustomerOrderDetail> CustomerOrderDetail(string customerID)
        {
            return _storedProcedures.CustomerOrderDetail(customerID);
        }
    }
}