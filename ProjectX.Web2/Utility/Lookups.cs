using ProjectX.Core.Caching;
using ProjectX.Entities.Models;
using ProjectX.Service;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.DataContext;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Ef6;
using ProjectX.Web.Areas.Definitions.Models;

namespace ProjectX.Web.Utility
{
    public static class Lookups
    {
        private static readonly string MasterConnectionString = ConfigurationManager.ConnectionStrings["ProjectXContext"].ConnectionString;
        private static readonly IRepositoryProvider _repositoryProvider = new RepositoryProvider(new RepositoryFactories());

        private const string CACHE_SUBINV = "CACHE::SUBINV";

        public static SelectList SubInventoryLookup()
        {
            return CacheHelper.CacheObject<SelectList>(delegate { return new SelectList(GetSubInventory(), "SubInvCode", "SubInvName"); },
                CACHE_SUBINV, CacheLength.GetLongCacheTime, System.Web.Caching.CacheItemPriority.Normal);
        }

        public static System.Collections.IEnumerable GetSubInventory()
        {
            using (IDataContextAsync context = new ProjectXContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context, _repositoryProvider))
            {
                IRepositoryAsync<SubInventory> repo = new Repository<SubInventory>(context, unitOfWork);
                SubInventoryService service = new SubInventoryService(repo);

                return service.Queryable()
                    .Select(s => new SubInventoryModel
                    { 
                        SubInvCode = s.SubInvCode, 
                        SubInvName = s.SubInvName 
                    }).OrderBy(o => o.SubInvCode).ToList();
            }
        }
    }
}