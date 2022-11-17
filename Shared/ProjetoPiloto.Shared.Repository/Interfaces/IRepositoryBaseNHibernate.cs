using ProjetoPiloto.Shared.Interfaces;

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
