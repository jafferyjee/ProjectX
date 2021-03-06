﻿using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectX.Entities.Models;
using ProjectX.Service;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;

namespace ProjectX.Test.IntegrationTests
{
    [TestClass]
    public class UnitOfWorkTests
    {
        [TestMethod]
        public void UnitOfWork_Transaction_Test()
        {
            IRepositoryProvider repositoryProvider = new RepositoryProvider(new RepositoryFactories());

            using(IDataContextAsync context = new ProjectXContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, repositoryProvider))
            {
                //IRepositoryAsync<Customer> customerRepository = new Repository<Customer>(context, unitOfWork);
                //IService<Customer> customerService = new CustomerService(customerRepository);

                //try
                //{
                //    unitOfWork.BeginTransaction();
                
                //    customerService.Insert(new Customer { CustomerID = "YODA", CompanyName = "SkyRanch", ObjectState = ObjectState.Added});
                //    customerService.Insert(new Customer { CustomerID = "JEDI", CompanyName = "SkyRanch", ObjectState = ObjectState.Added});

                //    var customer = customerService.Find("YODA");
                //    Assert.AreSame(customer.CustomerID, "YODA");

                //    customer = customerService.Find("JEDI");
                //    Assert.AreSame(customer.CustomerID, "JEDI");

                //    // save
                //    var saveChangesAsync = unitOfWork.SaveChanges();
                //    //Assert.AreSame(saveChangesAsync, 2);

                //    // Will cause an exception, cannot insert customer with the same CustomerId (primary key constraint)
                //    customerService.Insert(new Customer { CustomerID = "JEDI", CompanyName = "SkyRanch", ObjectState = ObjectState.Added });
                //    //save 
                //    unitOfWork.SaveChanges();

                //    unitOfWork.Commit();
                //}
                //catch (Exception e)
                //{
                //    unitOfWork.Rollback();
                //}
            }
        }

        [TestMethod]
        public void UnitOfWork_Dispose_Test()
        {
            IRepositoryProvider repositoryProvider = new RepositoryProvider(new RepositoryFactories());
            IDataContextAsync context = new ProjectXContext();
            IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, repositoryProvider);

            // opening connection
            unitOfWork.BeginTransaction();
            unitOfWork.Commit();

            // calling dispose 1st time
            unitOfWork.Dispose();
            var isDisposed = (bool) GetInstanceField(typeof (UnitOfWork), unitOfWork, "_disposed");
            Assert.IsTrue(isDisposed);

            // calling dispose 2nd time, should not throw any excpetions
            unitOfWork.Dispose();
            context.Dispose();

            // calling dispose 3rd time, should not throw any excpetions
            context.Dispose();
            unitOfWork.Dispose();
        }

        [TestMethod]
        public void IDataContext_Dispose_Test()
        {
            IRepositoryProvider repositoryProvider = new RepositoryProvider(new RepositoryFactories());
            IDataContextAsync context = new ProjectXContext();
            IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, repositoryProvider);

            // opening connection
            unitOfWork.BeginTransaction();
            unitOfWork.Commit();

            // calling dispose 1st time
            context.Dispose();

            var isDisposed = (bool) GetInstanceField(typeof (DataContext), context, "_disposed");
            Assert.IsTrue(isDisposed);

            // calling dispose 2nd time, should not throw any excpetions
            unitOfWork.Dispose();
            context.Dispose();

            // calling dispose 3rd time, should not throw any excpetions
            unitOfWork.Dispose();
            context.Dispose();
        }

        private static object GetInstanceField(Type type, object instance, string fieldName)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var field = type.GetField(fieldName, bindFlags);
            return field != null ? field.GetValue(instance) : null;
        }

        public TestContext TestContext { get; set; }
    }
}