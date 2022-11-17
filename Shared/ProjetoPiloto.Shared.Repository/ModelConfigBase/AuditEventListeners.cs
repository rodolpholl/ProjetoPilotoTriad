using NHibernate.Event;
using NHibernate.Persister.Entity;
using ProjetoPiloto.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Shared.Repository.ModelConfigBase
{
    public class AuditEventListeners : IPreInsertEventListener, IPreUpdateEventListener
    {
        public bool OnPreInsert(PreInsertEvent @event)
        {

            var audit = @event.Entity as IEntityBase;
            if (audit == null)
                return false;

            var _now = DateTime.Now;

            Set(@event.Persister, @event.State, "CreateDateTime", _now);
            Set(@event.Persister, @event.State, "UpdateDateTime", _now);

            audit.CreateDateTime = _now;
            audit.CreateDateTime = _now;

            return false;

        }


        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return OnPreInsert(@event);
            });
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var audit = @event.Entity as IEntityBase;
            if (audit == null)
                return false;

            var _now = DateTime.Now;


            Set(@event.Persister, @event.State, "UpdateDateTime", _now);

            audit.UpdateDateTime = _now;

            return false;
        }

        public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return OnPreUpdate(@event);
            });
        }

        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }
    }
}
