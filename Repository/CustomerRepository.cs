using RewardPoints.Entities;
using RewardPoints.Repository.IRepository;

namespace RewardPoints.Repository
{
    public class CustomerRepository : BaseRepository<CustomerEntity>, IBaseRepository<CustomerEntity>
    {
        public CustomerRepository(TransactionDbContext managerContext) : base(managerContext)
        {
        }
    }
}
