using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace RewardPoints.Entities
{
    [Table("Customer")]
    public class CustomerEntity
    {
        [Key]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }
    }
}
