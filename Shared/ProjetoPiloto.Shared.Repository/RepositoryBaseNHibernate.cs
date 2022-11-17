using NHibernate;
using ProjetoPiloto.Shared.Interfaces;
using ProjetoPiloto.Shared.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Shared.Repository
{
    public abstract class RepositoryBaseNHibernate<TEntity> : IRepositoryBaseNHibernate<TEntity> where TEntity : IEntityBase
    {

        private readonly ISession _session;
        private ITransaction _transaction;

        public RepositoryBaseNHibernate(ISession session)
        {
            _session = session;
        }


        public virtual IQueryable<TEntity> Collection => _session.Query<TEntity>();

        public async Task Add(TEntity entity)
        {
            bool openTransaction = !(_transaction == null);

            if (openTransaction)
            {
                _transaction = _session.BeginTransaction();
            }

            await _session.SaveAsync(entity);

            if (openTransaction)
            {
                try
                {
                    await _transaction?.CommitAsync();
                }
                catch
                {
                    await _transaction?.RollbackAsync();
                }
                finally
                {
                    _transaction?.Dispose();
                }
            }

        }

        public virtual void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public virtual void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public virtual async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            await _session.DeleteAsync(entity);
        }
                

        public virtual async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public virtual async Task Save(TEntity entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            bool openTransaction = !(_transaction == null);

            if (openTransaction)
            {
                _transaction = _session.BeginTransaction();
            }

            await _session.UpdateAsync(entity);

            if (openTransaction)
            {
                try
                {
                    await _transaction?.CommitAsync();
                }
                catch
                {
                    await _transaction?.RollbackAsync();
                }
                finally
                {
                    _transaction?.Dispose();
                }
            }
        }
    }
}
