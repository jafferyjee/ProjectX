using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
public interface IProjectXStoredProcedures
{
    IEnumerable<CustomerOrderHistory> CustomerOrderHistory(string customerID);
    int CustOrdersDetail(int? orderID);
    IEnumerable<CustomerOrderDetail> CustomerOrderDetail(string customerID);
    int EmployeeSalesByCountry(DateTime? beginningDate, DateTime? endingDate);
    int SalesByCategory(string categoryName, string ordYear);
    int SalesByYear(DateTime? beginningDate, DateTime? endingDate);
}
}