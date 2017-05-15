using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Repositories;
using ProjectX.Service;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6.Factories;
using ProjectX.Entities.Models;
using Repository.Pattern.Ef6;

namespace ProjectX.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container
                .RegisterType<IDataContextAsync, ProjectXContext>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryProvider, RepositoryProvider>(
                    new PerRequestLifetimeManager(),
                    new InjectionConstructor(new object[] { new RepositoryFactories() })
                    )
                //repo
                .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
                .RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryAsync<Item>, Repository<Item>>()
                .RegisterType<IRepositoryAsync<ItemMainCategory>, Repository<ItemMainCategory>>()
                .RegisterType<IRepositoryAsync<ItemSubCategory>, Repository<ItemSubCategory>>()
                .RegisterType<IRepositoryAsync<SubInventory>, Repository<SubInventory>>()
                .RegisterType<IRepositoryAsync<Contact>, Repository<Contact>>()
                .RegisterType<IRepositoryAsync<ContactCategory>, Repository<ContactCategory>>()
                .RegisterType<IRepositoryAsync<Photo>, Repository<Photo>>()
                .RegisterType<IRepositoryAsync<ExceptionLog>, Repository<ExceptionLog>>()
                //service
                .RegisterType<IItemService, ItemService>()
                .RegisterType<IItemMainCategoryService, ItemMainCategoryService>()
                .RegisterType<IItemSubCategoryService, ItemSubCategoryService>()
                .RegisterType<ISubInventoryService, SubInventoryService>()
                .RegisterType<IContactService, ContactService>()
                .RegisterType<IContactCategoryService, ContactCategoryService>()
                .RegisterType<IPhotoService, PhotoService>()
                .RegisterType<IExceptionLogService, ExceptionLogService>()
                .RegisterType<IProjectXStoredProcedures, ProjectXContext>(new PerRequestLifetimeManager())
                .RegisterType<IStoredProcedureService, StoredProcedureService>();
        }
    }
}
