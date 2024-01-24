using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DMAWSExam.Entities
{
    [Table("OrderTbl")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string ItemCode { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public int ItemQty { get; set; }

        [Required]
        public DateTime OrderDelivery { get; set; }

        [Required]
        public string OrderAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

    }
}
