using DeliverySystem.Infrastructure;
using PersonManager.Tools.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManager.Infrastructure
{
    #region Interface

    public interface IUnitOfWork
    {
        Task SaveAllAsync();
    }

    #endregion

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _entities;

        public UnitOfWork(AppDbContext entities)
        {
            _entities = entities;
        }

        public bool IsDisposed { get; private set; }

        public async Task SaveAllAsync()
        {
            using (var transaction = _entities.Database.BeginTransaction())
            {
                var entries = _entities.ChangeTracker.Entries<AggregateRoot>().ToList();

                await _entities.SaveChangesAsync();
                transaction.Commit();
            }
        }

        public void Dispose()
        {
            if (IsDisposed) return;

            _entities.Dispose();

            GC.SuppressFinalize(this);

            IsDisposed = true;
        }
    }
}
