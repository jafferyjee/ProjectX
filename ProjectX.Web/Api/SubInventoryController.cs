using ProjectX.Entities.Models;
using ProjectX.Service;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace ProjectX.Web.Api
{
    public class SubInventoryController : ODataController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly ISubInventoryService _subInventoryService;

        public SubInventoryController(
                IUnitOfWorkAsync unitOfWorkAsync,
                ISubInventoryService subInventoryService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _subInventoryService = subInventoryService;
        }

        // GET: odata/subinventory
        [HttpGet]
        [EnableQuery]
        public IEnumerable<SubInventory> Get()
        {
            return _subInventoryService.Queryable().OrderBy(s => s.SubInvCode);
        }

        //GET: odata/subinventory(5)
        [EnableQuery]
        public SingleResult<SubInventory> Get([FromODataUri] string key)
        {
            return SingleResult.Create(_subInventoryService.Queryable().Where(i => i.SubInvCode == key));
        }

        // PUT: odata/subinventory(5)
        public async Task<IHttpActionResult> Put(string key, SubInventory subinventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (key != subinventory.SubInvCode)
                return BadRequest();

            subinventory.ObjectState = ObjectState.Modified;
            _subInventoryService.Update(subinventory);

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

            return Updated(subinventory);
        }

        // POST: odata/subinventory
        public async Task<IHttpActionResult> Post(SubInventory subinventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            subinventory.ObjectState = ObjectState.Added;
            _subInventoryService.Insert(subinventory);

            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(subinventory.SubInvCode))
                    return Conflict();

                throw;
            }

            return Created(subinventory);
        }

        // DELETE: odata/subinventory(5)
        public async Task<IHttpActionResult> Delete(string key)
        {
            SubInventory subinventory = await _subInventoryService.FindAsync(key);

            if (subinventory == null)
                return NotFound();

            subinventory.ObjectState = ObjectState.Deleted;

            _subInventoryService.Delete(subinventory);

            await _unitOfWorkAsync.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool ItemExists(string key)
        {
            return _subInventoryService.Query(i => i.SubInvCode == key).Select().Any();
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