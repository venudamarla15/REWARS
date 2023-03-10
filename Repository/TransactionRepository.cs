using RewardPoints.Entities;
using RewardPoints.Repository.IRepository;

namespace RewardPoints.Repository
{
    public class TransactionRepository : BaseRepository<TransactionEntity>, IBaseRepository<TransactionEntity>
    {
        public TransactionRepository(TransactionDbContext managerContext) : base(managerContext)
        {
        }
    }
}
