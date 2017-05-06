using ProjectX.Entities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.Service
{
    public interface IContactCategoryService : IService<ContactCategory>
    {
    }

    public class ContactCategoryService : Service<ContactCategory>, IContactCategoryService
    {
        private readonly IRepositoryAsync<ContactCategory> _repository;

        public ContactCategoryService(IRepositoryAsync<ContactCategory> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
