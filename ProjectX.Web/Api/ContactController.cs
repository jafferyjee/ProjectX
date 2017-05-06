using ProjectX.Entities.Models;
using ProjectX.Service;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace ProjectX.Web.Api
{
    public class ContactController : ODataController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IContactService _contactService;

        public ContactController(
            IUnitOfWorkAsync unitOfWorkAsync,
            IContactService contactService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _contactService = contactService;
        }

        // GET: odata/Item
        [HttpGet]
        [EnableQuery]
        public IEnumerable<Contact> GetContact()
        {
            return _contactService.Queryable();
        }

        //GET: odata/Item(5)
        [HttpGet]
        public SingleResult<Contact> GetContact([FromODataUri] string key)
        {
            return SingleResult.Create(_contactService.Queryable().Where(c => c.ContactFullCode == key));
        }

    }
}