using InventoryModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Repository
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        IRepository<T> Repository<T>() where T : class;
    }
}
