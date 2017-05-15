using ProjectX.Entities.Models;
using ProjectX.Service;
using ProjectX.Web.Utility;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace ProjectX.Web.Api
{
    public class ItemController : ODataController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IItemService _itemService;

        public ItemController(
                IUnitOfWorkAsync unitOfWorkAsync,
                IItemService itemService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _itemService = itemService;
        }

        // GET: odata/Item
        [HttpGet]
        [EnableQuery]
        public IEnumerable<Item> GetItem()
        {
            return _itemService.GetTransactionItems();
        }

        //GET: odata/Item(5)
        [EnableQuery]
        public SingleResult<Item> GetItem([FromODataUri] string key)
        {
            return SingleResult.Create(_itemService.Queryable().Where(i => i.ItemFullCode == key));
        }

        //GET: odata/Item(5)/SubInventory
        [EnableQuery]
        public SingleResult<SubInventory> GetSubInventory([FromODataUri] string key)
        {
            return SingleResult.Create(_itemService.Queryable().Where(i => i.ItemFullCode == key).Select(s => s.SubInventory));
        }

        //GET: odata/Item(5)/Supplier
        [EnableQuery]
        public SingleResult<Contact> GetSupplier([FromODataUri] string key)
        {
            return SingleResult.Create(_itemService.Queryable().Where(i => i.ItemFullCode == key).Select(c => c.Contact));
        }

        //GET: odata/Item(5)/Colors
        [EnableQuery]
        public IQueryable<ICollection<ItemColorSize>> GetColorSizes([FromODataUri] string key)
        {
            return _itemService.Queryable().Where(i => i.ItemFullCode == key).Select(c => c.ItemColorSizes);
        }
        
        // PUT: odata/item(5)
        public async Task<IHttpActionResult> Put(string key, Item item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (key != item.ItemFullCode)
                return BadRequest();

            item.ObjectState = ObjectState.Modified;
            _itemService.Update(item);

            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(key))
                    return NotFound();

                throw;
            }

            return Updated(item);
        }

        // POST: odata/item
        public async Task<IHttpActionResult> Post(Item item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PopulateFields(item);

            item.ObjectState = ObjectState.Added;
            _itemService.Insert(item);

            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(item.ItemFullCode))
                    return Conflict();

                throw;
            }

            return Created(item);
        }        

        // DELETE: odata/item(5)
        public async Task<IHttpActionResult> Delete(string key)
        {
            Item item = await _itemService.FindAsync(key);

            if (item == null)
                return NotFound();

            item.ObjectState = ObjectState.Deleted;

            _itemService.Delete(item);

            await _unitOfWorkAsync.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        #region Actions

        //[HttpPost]
        //public IQueryable<Item> MainCategories(ODataQueryOptions opts)
        //{
        //    // Validate the query options.
        //    var settings = new ODataValidationSettings()
        //    {
        //        AllowedQueryOptions = AllowedQueryOptions.All
        //    };
        //    opts.Validate(settings);

        //    return opts.ApplyTo(_itemService.GetMainCategories()) as IQueryable<Item>;
        //}

        //[HttpPost]
        //public IQueryable<Item> SubCategories(ODataQueryOptions opts)
        //{
        //    // Validate the query options.
        //    var settings = new ODataValidationSettings()
        //    {
        //        AllowedQueryOptions = AllowedQueryOptions.All
        //    };
        //    opts.Validate(settings);

        //    return opts.ApplyTo(_itemService.GetSubCategories()) as IQueryable<Item>;
        //}

        #endregion

        private bool ItemExists(string key)
        {
            return _itemService.Query(i => i.ItemFullCode == key).Select().Any();
        }

        private void PopulateFields(Item item)
        {
            string lastSegment = item.SubCategoryCode.Substring(item.SubCategoryCode.LastIndexOf("-") + 1);
            string itemFullCode = item.SubCategoryCode.Substring(0, item.SubCategoryCode.LastIndexOf("-") + 1) + item.ItemShortCode.PadLeft(lastSegment.Length, '0');
            item.ItemFullCode = itemFullCode;
            item.CreatedBy = Util.CurrentUser;
            item.CreatedDate = System.DateTime.Now;
            item.ModifiedBy = Util.CurrentUser;
            item.ModifiedDate = System.DateTime.Now;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWorkAsync.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}