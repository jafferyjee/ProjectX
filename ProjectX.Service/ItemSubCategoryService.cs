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
    public interface IItemSubCategoryService : IService<ItemSubCategory> 
    {     
    }

    public class ItemSubCategoryService : Service<ItemSubCategory>, IItemSubCategoryService 
    {
        private readonly IRepositoryAsync<ItemSubCategory> _repository;

        public ItemSubCategoryService(IRepositoryAsync<ItemSubCategory> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
