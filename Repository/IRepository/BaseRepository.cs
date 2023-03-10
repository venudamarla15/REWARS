using Microsoft.EntityFrameworkCore;

namespace RewardPoints.Repository.IRepository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly TransactionDbContext _transactionDbContext;

        protected BaseRepository(TransactionDbContext TransactionDbContext)
        {
            _transactionDbContext = TransactionDbContext;
        }

        public async Task<IEnumerable<T>> GetAllData()
        {
            return await _transactionDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> InsertData(T newEntity)
        {
            _transactionDbContext.Set<T>().Add(newEntity);
            await _transactionDbContext.SaveChangesAsync();
            return newEntity;
        }
    }
}
