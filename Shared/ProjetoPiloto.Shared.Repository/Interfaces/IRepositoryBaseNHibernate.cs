using ProjetoPiloto.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Shared.Repository.Interfaces
{
    public interface IRepositoryBaseNHibernate<TEntity> : IRepositoryBase<TEntity> where TEntity : IEntityBase
    {

        void BeginTransaction();
        void CloseTransaction();
        Task Commit();
        Task Rollback();

    }
}
