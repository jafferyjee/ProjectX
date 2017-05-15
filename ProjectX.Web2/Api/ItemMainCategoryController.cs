using ProjectX.Entities.Models;
using ProjectX.Service;
using Repository.Pattern.UnitOfWork;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;

namespace ProjectX.Web.Api
{
    public class ItemMainCategoryController : ODataController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IItemMainCategoryService _itemMainCategoryService;

        public ItemMainCategoryController(
                IUnitOfWorkAsync unitOfWorkAsync,
                IItemMainCategoryService itemMainCategoryService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _itemMainCategoryService = itemMainCategoryService;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<ItemMainCategory> Get()
        {
            return _itemMainCategoryService.Queryable();
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