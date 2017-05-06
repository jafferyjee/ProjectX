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
using System.Web.Http.OData.Query;
namespace ProjectX.Web.Api
{
    public class ItemSubCategoryController : ODataController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IItemSubCategoryService _itemSubCategoryService;

        public ItemSubCategoryController(
                IUnitOfWorkAsync unitOfWorkAsync,
                IItemSubCategoryService itemSubCategoryService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _itemSubCategoryService = itemSubCategoryService;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<ItemSubCategory> Get()
        {
            return _itemSubCategoryService.Queryable();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}