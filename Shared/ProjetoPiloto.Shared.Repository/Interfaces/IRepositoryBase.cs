using ProjetoPiloto.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Shared.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : IEntityBase
    {
       
        Task Save(TEntity entity);
        Task Delete(TEntity entity);
        Task Add(TEntity entity);
        Task Update(TEntity entity);

        IQueryable<TEntity> Collection { get; }
    }
}
