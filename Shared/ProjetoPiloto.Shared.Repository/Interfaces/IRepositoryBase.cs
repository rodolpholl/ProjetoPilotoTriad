using ProjetoPiloto.Shared.Interfaces;

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
