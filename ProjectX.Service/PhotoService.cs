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
    public interface IPhotoService : IService<Photo>
    { }

    public class PhotoService : Service<Photo>, IPhotoService
    {
        private readonly IRepositoryAsync<Photo> _repository;

        public PhotoService(IRepositoryAsync<Photo> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
