#region

using System.Collections.Generic;
using ProjectX.Entities.Models;

#endregion

namespace ProjectX.Service
{
    public interface IStoredProcedureService
    {
        IEnumerable<CustomerOrderHistory> CustomerOrderHistory(string customerID);
        int CustOrdersDetail(int? orderID);
        IEnumerable<CustomerOrderDetail> CustomerOrderDetail(string customerID);
    }
}