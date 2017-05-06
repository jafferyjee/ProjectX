using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectX.Entities.Models;
using Repository.Pattern.Repositories;

namespace ProjectX.Service
{
    public interface IExceptionLogService : IService<ExceptionLog>
    {}

    public class ExceptionLogService : Service<ExceptionLog>, IExceptionLogService
    {
        private readonly IRepositoryAsync<ExceptionLog> _repository;

        public ExceptionLogService(IRepositoryAsync<ExceptionLog> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
