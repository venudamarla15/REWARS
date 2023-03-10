using Microsoft.EntityFrameworkCore;
using RewardPoints.Entities;

namespace RewardPoints
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options) { }

        public DbSet<CustomerEntity> Customers { get; set; }

        public DbSet<TransactionEntity> Transactions { get; set; }

    }
}
