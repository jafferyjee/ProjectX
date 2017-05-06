﻿using System;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Entities.Models;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Northwind.Service;
using Northwind.Repository.Models;

namespace Northwind.Test.IntegrationTests
{
    [TestClass]
    public class ItemRepositoryTest
    {

        private static readonly string MasterConnectionString = ConfigurationManager.ConnectionStrings["MasterDbConnection"].ConnectionString;
        private readonly IRepositoryProvider _repositoryProvider = new RepositoryProvider(new RepositoryFactories());

        public TestContext TestContext { get; set; }

        //[TestInitialize]
        //public void SettingUpNorthwindTestDatabase()
        //{
        //    TestContext.WriteLine("Please ensure Northwind.Test/Sql/instnwnd.sql is copied to C:\\temp\\instnwnd.sql for test to run succesfully");
        //    TestContext.WriteLine("Please verify the the Northwind.Test/app.config connection strings are correct for your environment");

        //    TestContext.WriteLine("TestFixture executing, creating NorthwindTest Db for integration  tests");
        //    TestContext.WriteLine("Loading and parsing create NorthwindTest database Sql script");

        //    var file = new FileInfo("C:\\temp\\instnwnd.sql");
        //    var script = file.OpenText().ReadToEnd();
        //    RunSqlOnMaster(script);
        //    TestContext.WriteLine("NorthwindTest Db created for integration tests");
        //}

        //private static void RunSqlOnMaster(string script)
        //{
        //    using (var connection = new SqlConnection(MasterConnectionString))
        //    {
        //        var server = new Server(new ServerConnection(connection));
        //        server.ConnectionContext.ExecuteNonQuery(script);
        //    }
        //}

        //[TestCleanup]
        //public void Cleanup()
        //{
        //}

        [TestMethod]
        public void GetItems()
        {
            using (IDataContextAsync context = new NorthwindContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
            {
                IRepositoryAsync<Item> itemRepository = new Repository<Item>(context, unitOfWork);
                ItemService itemService = new ItemService(itemRepository);

                var item = itemService.GetTransactionItems().Where(i => i.ItemFullCode == "10-01-01-00004").FirstOrDefault();
                //var item = itemService.GetAllTransactionItems().FirstOrDefault();
                
                Assert.IsNotNull(item.SubInventory);
            }
        }

        [TestMethod]
        public void GetItemsWithDetail()
        {
            using (IDataContextAsync context = new NorthwindContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
            {
                IRepositoryAsync<Item> itemRepository = new Repository<Item>(context, unitOfWork);
                ItemService itemService = new ItemService(itemRepository);

                var items = itemService.GetAllTransactionItemsDetail();

                Assert.IsTrue(items.Count<ItemDetail>() > 0);
            }
        }

    }
}
