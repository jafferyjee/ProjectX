using ProjectX.Entities.Models;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectX.Repository.Models;

namespace ProjectX.Repository.Repositories
{
    public static class ItemRepository
    {
        public static IEnumerable<Item> GetTransactionItems(this IRepositoryAsync<Item> repository) 
        {
            return repository
                .Query()
                .Include(i => i.SubInventory)
                .Include(c => c.Contact)                
                .OrderBy(q => q
                    .OrderBy(i => i.ItemFullCode))                
                .Select();
        }

        //public static IQueryable<Item> GetMainCategories(this IRepositoryAsync<Item> repository) 
        //{
        //    return repository
        //        .Queryable()
        //        .Where(i => i.IsTransaction == false && i.LevelItemFullCode == null)
        //        .OrderBy(o => o.ItemFullCode)
        //        .AsQueryable();
        //}

        //public static IQueryable<Item> GetSubCategories(this IRepositoryAsync<Item> repository) 
        //{
        //    return repository
        //        .Queryable()
        //        .Where(i => i.IsTransaction == false && i.LevelItemFullCode != null)
        //        .OrderBy(o => o.ItemFullCode)
        //        .AsQueryable();
        //}

        //public static IQueryable<Item> GetAllTransactionItems(this IRepositoryAsync<Item> repository) 
        //{
        //    return repository
        //        .Queryable()
        //        .Where(i => i.IsTransaction == true)
        //        .OrderBy(i => i.ItemFullCode)
        //        .AsQueryable();
        //}

        //public static IQueryable<ItemDetail> GetAllTransactionItemsDetail(this IRepositoryAsync<Item> repository) 
        //{
        //    var query =
        //            from i in repository.GetRepository<Item>().Queryable()
        //                where i.IsTransaction == true
        //            join m in repository.GetRepository<Item>().Queryable() on i.LevelItemFullCode equals m.ItemFullCode
        //            join c in repository.GetRepository<Item>().Queryable() on m.LevelItemFullCode equals c.ItemFullCode
        //            orderby i.ItemFullCode 
        //            select new ItemDetail { 
        //                ItemFullCode = i.ItemFullCode,
        //                ItemCode = i.ItemCode,
        //                ItemName = i.ItemName,
        //                ItemShortCode = i.ItemShortCode,
        //                LevelItemFullCode = i.LevelItemFullCode,
        //                SupplierCode = i.SupplierCode,
        //                SubInvCode = i.SubInvCode,
        //                PurchasePrice = i.PurchasePrice,
        //                SalePrice = i.SalePrice,
        //                ArrivalDate = i.ArrivalDate,
        //                RefCode = i.RefCode,
        //                TColumn = i.TColumn,
        //                TColumnByAmt = i.TColumnByAmt,
        //                IsGiftItem = i.IsGiftItem,
        //                IsTransaction = i.IsTransaction,
        //                IsActive = i.IsActive,
        //                CreatedBy = i.CreatedBy,
        //                CreatedDate = i.CreatedDate,
        //                ModifiedBy = i.ModifiedBy,
        //                ModifiedDate = i.ModifiedDate,
        //                SupplierName = i.Contact.ContactName,
        //                SubInvName = i.SubInventory.SubInvName,
        //                MasterCategoryFullCode = m.ItemFullCode,
        //                MasterCategoryName = m.ItemName,
        //                CategoryFullCode = c.ItemFullCode,
        //                CategoryName = c.ItemName
        //            };

        //    return query.AsQueryable();
        //}

    }
}
