using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RewardPoints.Entities;
using RewardPoints.Models;
using RewardPoints.Repository.IRepository;

namespace RewardPoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IBaseRepository<CustomerEntity> _customeRepository;
        private readonly IBaseRepository<TransactionEntity> _transactionRepository;
        public CustomerController(IBaseRepository<CustomerEntity> customeRepository, IBaseRepository<TransactionEntity> transactionRepository)
        {
            _customeRepository = customeRepository ??
                                 throw new ArgumentNullException(nameof(customeRepository));
            _transactionRepository = transactionRepository ??
                                 throw new ArgumentNullException(nameof(transactionRepository));

        }

        [HttpGet]
        [Route("GetAllCustomerTransactions")]
        public async Task<IActionResult> Get()
        {
            var transactionData = await _transactionRepository.GetAllData();
            transactionData = transactionData.Where(i => i.TransactionDate >= DateTime.Now.AddDays(-3)).ToList();
            var customerData = await _customeRepository.GetAllData();

            var result = from c in customerData
                join t in transactionData on c.CustomerId equals t.CustomerId into ctjoin
                from resultData in ctjoin.DefaultIfEmpty()
                select new RewardDetails()
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Amount = resultData?.Amount ?? 0
                };
            result = result.GroupBy(i => new
            {
                i.CustomerId, i.CustomerName
            }).Select(i => new RewardDetails()
            {
                CustomerId = i.Key.CustomerId,
                CustomerName = i.Key.CustomerName,
                Amount = i.Sum(j => j.Amount)
            }).ToList();

            foreach (var item in result)
            {
                item.Amount = CalculateAmount(item.Amount);
            }

            return Ok(result);
        }



        [HttpPost]
        [Route("AddNewTransaction")]
        public async Task<IActionResult> InsertTransactionDetails(int customerId, int amount, DateTime transactionDate)
        {
            var transactionEntity = new TransactionEntity()
            {
                CustomerId = customerId,
                Amount = amount,
                TransactionDate = transactionDate,
                TransactionId = 0
            };
            var result = await _transactionRepository.InsertData(transactionEntity);
            return Ok(true);
        }
        private static int CalculateAmount(int totalAmount)
        {
           

            if (totalAmount < 50)
                return 0;
            if (totalAmount < 100)
                return (totalAmount - 50) * 1;
            return (totalAmount - 50) * 1 + (totalAmount - 100) * 1;
        }
    }
}
