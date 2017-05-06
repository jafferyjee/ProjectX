﻿#region

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Entities.Models;
using Northwind.Repository.Models;
using Northwind.Repository.Repositories;
using Northwind.Service;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;

#endregion

namespace Northwind.Test.IntegrationTests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private static readonly string MasterConnectionString = ConfigurationManager.ConnectionStrings["MasterDbConnection"].ConnectionString;
        private readonly IRepositoryProvider _repositoryProvider = new RepositoryProvider(new RepositoryFactories());

        readonly bool _databaseCreated;
        public TestContext TestContext { get; set; }
        
        //public CustomerRepositoryTests()
        //{
        //    if (_databaseCreated) return;
        //    var file = new FileInfo("C:\\temp\\instnwnd.sql");
        //    var script = file.OpenText().ReadToEnd();
        //    RunSqlOnMaster(script);
        //    _databaseCreated = true;
        //}

        //[TestInitialize]
        //public void Initialize()
        //{
        //    TestContext.WriteLine("Please ensure Northwind.Test/Sql/instnwnd.sql is copied to C:\\temp\\instnwnd.sql for test to run succesfully");
        //    TestContext.WriteLine("Please verify the the Northwind.Test/app.config connection strings are correct for your environment");
        //    TestContext.WriteLine("TestFixture executing, creating NorthwindTest Db for integration  tests");
        //    TestContext.WriteLine("Loading and parsing create NorthwindTest database Sql script");
        //}

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    // There is a state issue where NorthwindTest exists in the master database, however the actual NorthwindTest Db does not exists
        //    // We can just leave the TestInitialize method which will drop the Db before recreating it for until we figure this out.

        //    //  kill any live transactions
        //    //const string script1 = "ALTER DATABASE NorthwindTest SET READ_ONLY WITH ROLLBACK IMMEDIATE";
        //    //  drop the db and deletes the files on disk
        //    //const string script2 = "DROP DATABASE NorthwindTest;";
        //    //RunSqlOnMaster(script1);
        //    //RunSqlOnMaster(script2);
        //}

        //private static void RunSqlOnMaster(string script)
        //{
        //    using (var connection = new SqlConnection(MasterConnectionString))
        //    {
        //        var server = new Server(new ServerConnection(connection));
        //        server.ConnectionContext.ExecuteNonQuery(script);
        //    }
        //}

        //[TestMethod]
        //public void CreateCustomerTest()
        //{
        //    // Create new customer
        //    using (IDataContextAsync context = new NorthwindContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
        //    {
        //        IRepositoryAsync<Customer> customerRepository = new Repository<Customer>(context, unitOfWork);

        //        var customer = new Customer
        //        {
        //            CustomerID = "LLE37",
        //            CompanyName = "CBRE",
        //            ContactName = "Long Le",
        //            ContactTitle = "App/Dev Architect",
        //            Address = "11111 Sky Ranch",
        //            City = "Dallas",
        //            PostalCode = "75042",
        //            Country = "USA",
        //            Phone ="(222) 222-2222",
        //            Fax = "(333) 333-3333",
        //            ObjectState = ObjectState.Added,
        //        };

        //        customerRepository.Insert(customer);
        //        unitOfWork.SaveChanges();
        //    }

        //    //  Query for newly created customer by ID from a new context, to ensure it's not pulling from cache
        //    using (IDataContextAsync context = new NorthwindContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
        //    {
        //        IRepositoryAsync<Customer> customerRepository = new Repository<Customer>(context, unitOfWork);
        //        var customer = customerRepository.Find("LLE37");
        //        Assert.AreEqual(customer.CustomerID, "LLE37"); 
        //    }
        //}

        //[TestMethod]
        //public void CreateAndUpdateAndDeleteCustomerGraphTest()
        //{
        //    // Create new customer
        //    using (IDataContextAsync context = new NorthwindContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
        //    {
        //        IRepositoryAsync<Customer> customerRepository = new Repository<Customer>(context, unitOfWork);

        //        var customerForInsertGraphTest = new Customer
        //        {
        //            CustomerID = "LLE38",
        //            CompanyName = "CBRE",
        //            ContactName = "Long Le",
        //            ContactTitle = "App/Dev Architect",
        //            Address = "11111 Sky Ranch",
        //            City = "Dallas",
        //            PostalCode = "75042",
        //            Country = "USA",
        //            Phone = "(222) 222-2222",
        //            Fax = "(333) 333-3333",
        //            ObjectState = ObjectState.Added,
        //            Orders = new[]
        //            {
        //                new Order()
        //                {
        //                    CustomerID = "LLE38",
        //                    EmployeeID = 1,
        //                    OrderDate = DateTime.Now,
        //                    ObjectState = ObjectState.Added,
        //                }, 
        //                new Order()
        //                {
        //                    CustomerID = "LLE39",
        //                    EmployeeID = 1,
        //                    OrderDate = DateTime.Now,
        //                    ObjectState = ObjectState.Added
        //                }, 
        //            }
        //        };

        //        customerRepository.InsertOrUpdateGraph(customerForInsertGraphTest);
        //        unitOfWork.SaveChanges();
        //    }

        //    Customer customerForUpdateDeleteGraphTest = null;

        //    //  Query for newly created customer by ID from a new context, to ensure it's not pulling from cache
        //    using (IDataContextAsync context = new NorthwindContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
        //    {
        //        IRepositoryAsync<Customer> customerRepository = new Repository<Customer>(context, unitOfWork);
                
        //         customerForUpdateDeleteGraphTest = customerRepository
        //            .Query(x => x.CustomerID == "LLE38")
        //            .Include(x => x.Orders)
        //            .Select()
        //            .SingleOrDefault();

        //        // Testing that customer was created
        //        Assert.AreEqual(customerForUpdateDeleteGraphTest.CustomerID, "LLE38");

        //        // Testing that orders in customer graph were created
        //        Assert.IsTrue(customerForUpdateDeleteGraphTest.Orders.Count == 2);

        //        // Make changes to the object graph while in this context, will save these 
        //        // changes in another context, testing managing states between and/or while disconnected
        //        // from the orginal DataContext

        //        // Updating the customer in the graph
        //        customerForUpdateDeleteGraphTest.City = "Houston";
        //        customerForUpdateDeleteGraphTest.ObjectState = ObjectState.Modified;

        //        // Updating the order in the graph
        //        var firstOrder = customerForUpdateDeleteGraphTest.Orders.Take(1).Single();
        //        firstOrder.ShipCity = "Houston";
        //        firstOrder.ObjectState = ObjectState.Modified;

        //        // Deleting one of the orders from the graph
        //        var secondOrder = customerForUpdateDeleteGraphTest.Orders.Skip(1).Take(1).Single();
        //        secondOrder.ObjectState = ObjectState.Deleted;
        //    }

        //    //  Query for newly created customer by ID from a new context, to ensure it's not pulling from cache
        //    using (IDataContextAsync context = new NorthwindContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
        //    {
        //        IRepositoryAsync<Customer> customerRepository = new Repository<Customer>(context, unitOfWork);

        //        // Testing changes to graph while disconncted from it's orginal DataContext
        //        // Saving changes while graph was previous DataContext that was already disposed
        //        customerRepository.InsertOrUpdateGraph(customerForUpdateDeleteGraphTest);
        //        unitOfWork.SaveChanges();

        //        customerForUpdateDeleteGraphTest = customerRepository
        //            .Query(x => x.CustomerID == "LLE38")
        //            .Include(x => x.Orders)
        //            .Select()
        //            .SingleOrDefault();

        //        Assert.AreEqual(customerForUpdateDeleteGraphTest.CustomerID, "LLE38");

        //        // Testing for order(2) was deleted from the graph
        //        Assert.IsTrue(customerForUpdateDeleteGraphTest.Orders.Count == 1);

        //        // Testing that customer was updated in the graph
        //        Assert.IsTrue(customerForUpdateDeleteGraphTest.City == "Houston");

        //        // Testing that order was updated in the graph.
        //        Assert.IsTrue(customerForUpdateDeleteGraphTest.Orders.ToArray()[0].ShipCity == "Houston");
        //    }
        //}

        //[TestMethod]
        //public void GetCustomerOrderTest()
        //{
        //    using (IDataContextAsync context = new NorthwindContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
        //    {
        //        IRepositoryAsync<Customer> customerRepository = new Repository<Customer>(context, unitOfWork);
        //        var customerOrders = customerRepository.GetCustomerOrder("USA");
        //        var enumerable = customerOrders as CustomerOrder[] ?? customerOrders.ToArray();
        //        TestContext.WriteLine("Customers found: {0}", enumerable.Count());
        //        Assert.IsTrue(enumerable.Any());
        //    }
        //}

        //[TestMethod]
        //public void FindCustomerById_Test()
        //{
        //    using (IDataContextAsync context = new NorthwindContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
        //    {
        //        IRepositoryAsync<Customer> customerRepository = new Repository<Customer>(context, unitOfWork);
        //        IService<Customer> customerService = new CustomerService(customerRepository);
        //        var customer = customerService.Find("ALFKI");
        //        TestContext.WriteLine("Customers found: {0}", customer.ContactName);
        //        Assert.AreEqual(customer.ContactName, "Maria Anders");
        //    }
        //}

        //[TestMethod]
        //public void CustomerOrderTotalByYear()
        //{
        //    using (IDataContextAsync context = new NorthwindContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
        //    {
        //        IRepositoryAsync<Customer> customerRepository = new Repository<Customer>(context, unitOfWork);
        //        ICustomerService customerService = new CustomerService(customerRepository);
        //        var customerOrderTotalByYear = customerService.CustomerOrderTotalByYear("ALFKI", 1998);
        //        Assert.AreEqual(customerOrderTotalByYear, (decimal)2302.2000);
        //    }
        //}
    }
}