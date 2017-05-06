using ProjectX.Entities.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectX.Repository.Repositories;
using ProjectX.Repository.Models;

namespace ProjectX.Service
{
    public interface IItemService : IService<Item>
    {
        IEnumerable<Item> GetTransactionItems();
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class ItemService : Service<Item>, IItemService
    {
        private readonly IRepositoryAsync<Item> _repository;

        public ItemService(IRepositoryAsync<Item> repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Item> GetTransactionItems() 
        {
            return _repository.GetTransactionItems();
        }

        public override void Insert(Item entity)
        {
            // e.g. add business logic here before inserting
            base.Insert(entity);
        }

        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
        }        
    }
}
