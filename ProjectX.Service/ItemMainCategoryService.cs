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
    public interface IItemMainCategoryService : IService<ItemMainCategory> 
    {     
    }

    public class ItemMainCategoryService : Service<ItemMainCategory>, IItemMainCategoryService
    {
        private readonly IRepositoryAsync<ItemMainCategory> _repository;

        public ItemMainCategoryService(IRepositoryAsync<ItemMainCategory> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
