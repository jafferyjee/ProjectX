using ProjectX.Entities.Models;
using ProjectX.Service;
using Repository.Pattern.UnitOfWork;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;

namespace ProjectX.Web.Api
{
    public class ContactCategoryController : ODataController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IContactCategoryService _contactCategoryService;

        public ContactCategoryController(
                IUnitOfWorkAsync unitOfWorkAsync,
                IContactCategoryService contactCategoryService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _contactCategoryService = contactCategoryService;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<ContactCategory> Get()
        {
            return _contactCategoryService.Queryable();
        }
    }
}