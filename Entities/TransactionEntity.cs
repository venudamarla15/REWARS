using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RewardPoints.Entities
{
    [Table("Transaction")]
    public class TransactionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
