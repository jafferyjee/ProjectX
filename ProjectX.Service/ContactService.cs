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
    public interface IContactService : IService<Contact>
    {     
    }

    public class ContactService : Service<Contact>, IContactService
    {
        private readonly IRepositoryAsync<Contact> _repository;

        public ContactService(IRepositoryAsync<Contact> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
