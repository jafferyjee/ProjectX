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
    public interface ISubInventoryService : IService<SubInventory>
    { 
    
    }

    public class SubInventoryService : Service<SubInventory>, ISubInventoryService
    {
        private readonly IRepositoryAsync<SubInventory> _repository;

        public SubInventoryService(IRepositoryAsync<SubInventory> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
